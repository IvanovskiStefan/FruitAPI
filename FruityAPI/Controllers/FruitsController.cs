using FruityAPI.Extensions;
using FruityAPI.Models;
using FruityAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static FruityAPI.Dto.Fruit.FruitDtos;

namespace FruityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly FruitService _fruitService;

        public FruitsController(FruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetFruit(string name)
        {
            try
            {
                var fruit = await _fruitService.GetFruitByNameAsync(name);
                return Ok(fruit);
            }
            catch (HttpRequestException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut("/modifyMetadata")]
        public async Task<IActionResult> ModifyMetadata(string fruitName, MetadataRequest request)
        {
            Fruit fruit = await _fruitService.GetFruitByNameAsync(fruitName);

            await _fruitService.PutMetadata(fruit.FruitToFruitDto() with { Metadata = request.Metadata });

            return Ok(new { Message = $"Metadata modified for fruit: {fruit.Name}" });
        }

        //[HttpPut("/removeMetadata")]
        //public async Task<IActionResult> RemoveMetadata(string name, List<string> metadataToRemove, [FromBody] PutRequest request)
        //{
        //    Fruit fruit = await _fruitService.GetFruitByNameAsync(name);

        //    if (fruit == null) 
        //        return NotFound(new { Message = "Fruit not found" });

        //    foreach (string metadata in metadataToRemove)
        //    {
        //        if (fruit.Metadata.ContainsKey(metadata))
        //            fruit.Metadata.Remove(metadata);
        //    }

        //    await _fruitService.PutMetadata(fruit.FruitToPutRequestDto());

        //    return Ok(new { Message = $"Metadata removed for fruit: {fruit.Name}" });
        //}

        //[HttpPut("/updateMetadata")]
        //public async Task<IActionResult> UpdateMetadata(string name, Dictionary<string, object> metadataToUpdate, [FromBody] PutRequest request)
        //{
        //    Fruit fruit = await _fruitService.GetFruitByNameAsync(name);

        //    if (fruit == null)
        //        return NotFound(new { Message = "Fruit not found" });

        //    foreach (KeyValuePair<string, object> pair in metadataToUpdate)
        //    {
        //        if (fruit.Metadata.ContainsKey(pair.Key))
        //            fruit.Metadata[pair.Key] = pair.Value;
        //    }

        //    await _fruitService.PutMetadata(fruit.FruitToPutRequestDto());

        //    return Ok(new { Message = $"Metadata updated for fruit: {fruit.Name}" });
        //}
    }
}
