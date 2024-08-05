using BGC.Common.Catalog;
using BGC.Common.Catalog.Models;
using BGC.Server.DataLayer;
using BGC.Server.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BGC.Server.Catalog
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly IDbContextFactory<BgcDbContext> _dbContextFactory;

        public CatalogRepository(IDbContextFactory<BgcDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region public
        public async Task<DataForSelection> GetDataForSelection()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var authors = await context.Authors.ToArrayAsync();
            var themes = await context.Themes.ToArrayAsync();
            var genres = await context.Genres.ToArrayAsync();
            var ratings = await context.Ratings.ToArrayAsync();

            return new DataForSelection()
            {
                Authors = authors.Select(Map).ToArray(),
                Themes = themes.Select(Map).ToArray(),
                Genres = genres.Select(Map).ToArray(),
                Ratings = ratings.Select(Map).ToArray(),
            };
        }

        public async Task<GetFullGameRespone> GetGameFull(long id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var g = await context.Games.Where(g => g.Id == id)
                .Include(g => g.Themes)
                .Include(g => g.Genres)
                .Include(g => g.Authors)
                .Include(g => g.Owners)
                .Include(g => g.GameRatings)
                    .ThenInclude(gr => gr.RatingType)
                .FirstOrDefaultAsync();
            return new GetFullGameRespone() { Game = Map(g) };
        }

        public async Task<GetFullGameRespone> UpsertGame(GameUpsertingRequest gameSavingRequest)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var oldGame = await context.Games.FirstOrDefaultAsync(g => g.Id == gameSavingRequest.Id);
            if (oldGame != null)
            {
                oldGame.DeleteDate = DateTime.UtcNow;
            }

            var game = new Game()
            {
                AgeMax = gameSavingRequest.AgeMax,
                AgeMin = gameSavingRequest.AgeMin,
                GameDurationMax = gameSavingRequest.GameDurationMax,
                GameDurationMin = gameSavingRequest.GameDurationMin,
                NameEng = gameSavingRequest.NameEng,
                NameRu = gameSavingRequest.NameRu,
                PlayersMax = gameSavingRequest.PlayersMax,
                PlayersMin = gameSavingRequest.PlayersMin,
            };

            game.Themes = await context.Themes
                .Where(t => gameSavingRequest.ThemesIds.Contains(t.Id))
                .ToArrayAsync();

            game.Authors = await context.Authors
                .Where(t => gameSavingRequest.AuthorsIds.Contains(t.Id))
                .ToArrayAsync();

            game.Owners = await context.Owners
                .Where(t => gameSavingRequest.OwnersIds.Contains(t.Id))
                .ToArrayAsync();

            game.Genres = await context.Genres
                .Where(t => gameSavingRequest.GenresIds.Contains(t.Id))
                .ToArrayAsync();

            var ratings = await context.Ratings
                .Where(t => gameSavingRequest.Ratings.Select(r => r.Id).Contains(t.Id))
                .ToArrayAsync();

            var gameRatings = new GameRating[ratings.Length];

            for (int i = 0; i < ratings.Length; i++)
            {
                gameRatings[i] = new GameRating()
                {
                    RatingType = ratings[i],
                    Game = game,
                    Rating = gameSavingRequest.Ratings.FirstOrDefault(gr => gr.Id == ratings[i].Id)?.Value ?? 0
                };
            }

            game.GameRatings = gameRatings;
            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return new GetFullGameRespone() { Game = Map(game) };
        }

        public async Task<GetGamesByFilterResponse> GetGamesByFilter(GamesFilter filter)
        {

            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var result = new GetGamesByFilterResponse();
            if (filter.OwnerId.HasValue)
            {
                var games = await context.GameOwners
                    .Where(go => go.OwnerId == filter.OwnerId.Value)
                    .Include(go => go.Game)
                    .Select(go => go.Game)
                    .Where(g => g.DeleteDate == null)
                    .ToArrayAsync();
                result.Games = games.Select(MapToReducedGame).ToArray();
            }
            else
            {
                var games = await context.Games
                    .Where(g => g.DeleteDate == null)
                    .ToArrayAsync();
                result.Games = games.Select(MapToReducedGame).ToArray();
            }


            return result;
        }
        #endregion

        #region private mappings
        private static GameReduced MapToReducedGame(Game game)
        {
            return new GameReduced()
            {
                AgeMax = game.AgeMax,
                AgeMin = game.AgeMin,
                GameDurationMax = game.GameDurationMax,
                GameDurationMin = game.GameDurationMin,
                Id = game.Id,
                NameEng = game.NameEng,
                NameRu = game.NameRu,
                PlayersMax = game.PlayersMax,
                PlayersMin = game.PlayersMin,
            };
        }


        private static GameFull? Map(Game? game)
        {
            return game == null ? null : new GameFull()
            {
                AgeMax = game.AgeMax,
                AgeMin = game.AgeMin,
                GameDurationMax = game.GameDurationMax,
                GameDurationMin = game.GameDurationMin,
                Id = game.Id,
                NameEng = game.NameEng,
                NameRu = game.NameRu,
                PlayersMax = game.PlayersMax,
                PlayersMin = game.PlayersMin,
                Authors = game.Authors.Select(Map).ToArray(),
                Genres = game.Genres.Select(Map).ToArray(),
                Ratings = game.GameRatings.Select(Map).ToArray(),
                Themes = game.Themes.Select(Map).ToArray(),
            };
        }

        private static BGC.Common.Catalog.Models.Genre Map(BGC.Server.DataLayer.Entities.Genre genre)
        {
            return new Common.Catalog.Models.Genre()
            {
                Id = genre.Id,
                Name = genre.Name,
            };
        }

        private static BGC.Common.Catalog.Models.Theme Map(BGC.Server.DataLayer.Entities.Theme theme)
        {
            return new Common.Catalog.Models.Theme()
            {
                Id = theme.Id,
                Name = theme.Name,
            };
        }

        private static BGC.Common.Catalog.Models.Author Map(BGC.Server.DataLayer.Entities.Author author)
        {
            return new Common.Catalog.Models.Author()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
        }

        private static BGC.Common.Catalog.Models.Rating Map(BGC.Server.DataLayer.Entities.RatingType ratingType)
        {
            return new Common.Catalog.Models.Rating()
            {
                Id = ratingType.Id,
                Name = ratingType.Name,
                Scale = ratingType.Scale,
            };
        }

        private static BGC.Common.Catalog.Models.Rating Map(BGC.Server.DataLayer.Entities.GameRating gameRating)
        {
            return new Common.Catalog.Models.Rating()
            {
                Id = gameRating.RatingTypeId,
                Name = gameRating.RatingType?.Name,
                Value = gameRating.Rating,
            };
        }
        #endregion
    }
}
