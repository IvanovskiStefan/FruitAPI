using FruityAPI.Models;
using static FruityAPI.Dto.Fruit.FruitDtos;

namespace FruityAPI.Extensions
{
    public static class FruitExtensions
    {
        public static FruitDto FruitToFruitDto(this Fruit fruit) => 
            new FruitDto(fruit.Name, fruit.Family, fruit.Order, fruit.Genus, fruit.Nutritions, fruit.Metadata);
    }
}
