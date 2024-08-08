using System.Text.Json.Serialization;

namespace PokemonApi.Models
{

    public class Pokemon
    {
        public string Name { get; set; }
        public List<AbilityInfo> Abilities { get; set; }
        public List<StatInfo> Stats { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public SpriteInfo Sprites { get; set; }
    }

    public class AbilityInfo
    {
        public AbilityDetailInfo Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }

    public class AbilityDetailInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class StatInfo
    {
        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }
        public StatDetailInfo Stat { get; set; }
    }


    public class StatDetailInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class SpriteInfo
    {
        public string FrontDefault { get; set; }
    }


}
