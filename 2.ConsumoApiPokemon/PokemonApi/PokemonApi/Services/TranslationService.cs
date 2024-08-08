using System.Collections.Generic;
using System.Linq;

namespace PokemonApi.Services
{
    public class TranslationService
    {
        private static readonly Dictionary<string, string> StatTranslations = new Dictionary<string, string>
        {
            { "hp", "Vida" },
            { "attack", "Ataque" },
            { "defense", "Defensa" },
            { "special-attack", "Ataque Especial" },
            { "special-defense", "Defensa Especial" },
            { "speed", "Velocidad" }
        };

        public static string TranslateStatName(string name)
        {
            return StatTranslations.TryGetValue(name, out var translatedName) ? translatedName : name;
        }
    }
}
