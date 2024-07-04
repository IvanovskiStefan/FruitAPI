using FruityAPI.Models;

namespace FruityAPI.Dto.Fruit
{
    public class FruitDtos
    {
        public record FruitDto(
            string Name,
            string Family,
            string Order,
            string Genus,
            Nutritions Nutritions,
            Dictionary<string, object>? Metadata
        );

        public record MetadataRequest(
            Dictionary<string, object>? Metadata
        );
    }
}
