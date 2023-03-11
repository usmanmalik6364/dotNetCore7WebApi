using BlazorFullStackCrud.Client.Pages;
using BlazorFullStackCrud.Shared.Models;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;

        public List<SuperHero> Heroes { get ; set ; } = new List<SuperHero> ();
        public List<Comic> Comics { get; set ; } = new List<Comic> ();
        public SuperHeroService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetComics()
        {
            var results = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (results != null)
            {
                Comics = results;
            }
            throw new Exception("Comics not found");
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var results = await _http.GetFromJsonAsync<SuperHero>($"api/GetSuperhero/{id}");
            if (results != null)
            {
                return results;
            }
            throw new Exception("Hero not found");

        }

        public async Task GetSuperHeroes()
        {
            var results = await _http.GetFromJsonAsync<List<SuperHero>>("api/superHero");
            if(results != null)
            {
                Heroes = results;
            }
        }
    }
}
