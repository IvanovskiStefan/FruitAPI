using FruityAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text.Json;
using static FruityAPI.Controllers.FruitsController;
using static FruityAPI.Dto.Fruit.FruitDtos;

namespace FruityAPI.Services
{
    public class FruitService
    {
        private readonly HttpClient _httpClient;

        public FruitService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Fruit> GetFruitByNameAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://www.fruityvice.com/api/fruit/{name}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Fruit not found or API error.");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Fruit>(content)!;
        }

        public async Task<Fruit> PutMetadata(FruitDto putRequest)
        {
            var response = await _httpClient.PutAsJsonAsync("https://www.fruityvice.com/api/fruit", putRequest);

            return new Fruit();
        } 

        //ZA SO CASH !!!
        //private readonly HttpClient _httpClient;
        //private readonly IMemoryCache _cache;
        //private readonly string _cacheKeyPrefix = "fruit_";

        //public FruitService(HttpClient httpClient, IMemoryCache cache)
        //{
        //    _httpClient = httpClient;
        //    _cache = cache;
        //}

        //public async Task<Fruit> GetFruitByNameAsync(string name)
        //{
        //    string cacheKey = _cacheKeyPrefix + name;

        //    if (!_cache.TryGetValue(cacheKey, out Fruit fruit))
        //    {
        //        var response = await _httpClient.GetAsync($"https://www.fruityvice.com/api/fruit/{name}");

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            throw new HttpRequestException("Fruit not found or API error.");
        //        }

        //        var content = await response.Content.ReadAsStringAsync();
        //        fruit = JsonConvert.DeserializeObject<Fruit>(content);

        //        _cache.Set(cacheKey, fruit, TimeSpan.FromMinutes(5));
        //    }

        //    return fruit;
        //}
    }
}
