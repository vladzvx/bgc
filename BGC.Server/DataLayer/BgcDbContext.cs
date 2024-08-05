using BGC.Server.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BGC.Server.DataLayer
{
    public class BgcDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<RatingType> Ratings { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<GameOwner> GameOwners { get; set; }
        public BgcDbContext(DbContextOptions<BgcDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e1 => e1.Id);
                entity
                    .HasMany(e => e.Themes)
                    .WithMany(e => e.Games)
                    .UsingEntity<GameTheme>();

                entity
                    .HasMany(e => e.Genres)
                    .WithMany(e => e.Games)
                    .UsingEntity<GameGenre>();
                entity
                    .HasMany(e => e.Authors)
                    .WithMany(e => e.Games)
                    .UsingEntity<GameAuthor>();
                entity
                    .HasMany(e => e.Owners)
                    .WithMany(e => e.Games)
                    .UsingEntity<GameOwner>();
            });

            modelBuilder.Entity<GameOwner>(entity =>
            {
                entity.HasKey(e1 => new { e1.GameId, e1.OwnerId });
                entity.HasOne(e => e.Game).WithMany(e => e.GameOwners);
                entity.HasOne(e => e.Owner).WithMany(e => e.GameOwners);
            });

            modelBuilder.Entity<GameAuthor>(entity =>
            {
                entity.HasKey(e1 => new { e1.GameId, e1.AuthorId });
                entity.HasOne(e => e.Game).WithMany(e => e.GameAuthors);
                entity.HasOne(e => e.Author).WithMany(e => e.GameAuthors);
            });

            modelBuilder.Entity<GameTheme>(entity =>
            {
                entity.HasKey(e1 => new { e1.GameId, e1.ThemeId });
                entity.HasOne(e => e.Game).WithMany(e => e.GameThemes);
                entity.HasOne(e => e.Theme).WithMany(e => e.GameThemes);
            });

            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.HasKey(e1 => new { e1.GameId, e1.GenreId });
                entity.HasOne(e => e.Game).WithMany(e => e.GameGenres);
                entity.HasOne(e => e.Genre).WithMany(e => e.GameGenres);
            });

            modelBuilder.Entity<GameRating>(entity =>
            {
                entity.HasKey(e1 => new { e1.GameId, e1.RatingTypeId });
                entity.HasOne(e => e.Game).WithMany(e => e.GameRatings);
                entity.HasOne(e => e.RatingType).WithMany(e => e.GameRatings);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e1 => e1.Id);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e1 => e1.Id);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e1 => e1.Id);
                entity
                    .HasMany(e => e.Games)
                    .WithMany(e => e.Owners)
                    .UsingEntity<GameOwner>();
            });

            modelBuilder.Entity<RatingType>(entity =>
            {
                entity.HasKey(e1 => e1.Id);
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.HasKey(e1 => e1.Id);
            });
        }
    }
}
