using BGC.Common.Catalog;
using BGC.Common.Catalog.Models;
using System.Text;
using System.Text.Json;

namespace BGC.Client.Services
{
    public class CatalogRepositoryHttp : ICatalogRepository
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public CatalogRepositoryHttp(string serverUrl)
        {
            _httpClient = new HttpClient//todo настройка неразрывности соединения
            {
                BaseAddress = new Uri(serverUrl)
            };
        }

        public async Task<DataForSelection> GetDataForSelection()
        {
            var resp = await _httpClient.GetAsync($"Catalog/GetDataForSelection");
            if (resp.IsSuccessStatusCode)
            {
                var stringContent = await resp.Content.ReadAsStringAsync();
                var res = System.Text.Json.JsonSerializer.Deserialize<DataForSelection>(stringContent, jsonSerializerOptions);
                if (res != null)
                {
                    return res;
                }
            }

            return new DataForSelection();
        }

        public async Task<GetFullGameRespone> GetGameFull(long id)
        {
            var resp = await _httpClient.GetAsync($"Catalog/GetGameFull?gameId={id}");
            if (resp.IsSuccessStatusCode)
            {
                var stringContent = await resp.Content.ReadAsStringAsync();
                var res = System.Text.Json.JsonSerializer.Deserialize<GetFullGameRespone>(stringContent, jsonSerializerOptions);
                if (res != null)
                {
                    return res;
                }
            }

            return new GetFullGameRespone();
        }

        public async Task<GetGamesByFilterResponse> GetGamesByFilter(GamesFilter filter)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json");
            var resp = await _httpClient.PostAsync($"Catalog/GetGamesByFilter", content);
            if (resp.IsSuccessStatusCode)
            {
                var stringContent = await resp.Content.ReadAsStringAsync();
                var res = System.Text.Json.JsonSerializer.Deserialize<GetGamesByFilterResponse>(stringContent, jsonSerializerOptions);
                if (res != null)
                {
                    return res;
                }
            }

            return new GetGamesByFilterResponse();
        }

        public async Task<GetFullGameRespone> UpsertGame(GameUpsertingRequest gameFull)
        {
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(gameFull), Encoding.UTF8, "application/json");
            var resp = await _httpClient.PostAsync($"Catalog/UpsertGame", content);
            if (resp.IsSuccessStatusCode)
            {
                var stringContent = await resp.Content.ReadAsStringAsync();
                var res = System.Text.Json.JsonSerializer.Deserialize<GetFullGameRespone>(stringContent, jsonSerializerOptions);
                if (res != null)
                {
                    return res;
                }
            }

            return new GetFullGameRespone();
        }
    }
}
