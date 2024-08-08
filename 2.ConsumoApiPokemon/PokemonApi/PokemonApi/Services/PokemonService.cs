using PokemonApi.Models;
using System.Text.Json;

namespace PokemonApi.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> GetPokemonAsync(string nameOrId)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{nameOrId}");
                Console.WriteLine($"Response JSON: {response}");

                var pokemon = JsonSerializer.Deserialize<Pokemon>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Translate stats names
                if (pokemon?.Stats != null)
                {
                    foreach (var stat in pokemon.Stats)
                    {
                        stat.Stat.Name = TranslationService.TranslateStatName(stat.Stat.Name);
                    }
                }

                return pokemon;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                return null;
            }
        }
    }
}
