namespace FruityAPI.Models
{
    public class Fruit
    {
        public string Name { get; set; } = string.Empty;
        public string Family { get; set; } = string.Empty;
        public string Genus { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public Nutritions Nutritions { get; set; } = new();
        public Dictionary<string, object> Metadata = new();
    }
}
