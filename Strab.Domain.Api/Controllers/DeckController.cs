using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Strab.Domain.Api.Controllers;

[ApiController]
[Route("v1/deck")]
public class DeckController : ControllerBase
{
    record PostShuffleResult(bool success, bool shuffled, string deck_id, int remaining);
    record PostShuffleData(int deck_count);
    record GetShuffleResult(bool success, bool shuffled, string deck_id, int remaining);

    record Cep(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string ddd, string siafi);

    [HttpPost("{deckCount:int}")]
    public async Task<ActionResult<dynamic>> PostShuffle([FromRoute] int deckCount = 1)
    {
        using (var httpClient = new HttpClient())
        {
            var postData = new PostShuffleData(deckCount);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xpto");
            var response = await httpClient.PostAsJsonAsync<PostShuffleData>("http://deckofcardsapi.com/api/deck/new/shuffle", postData);
            var result = await response.Content.ReadFromJsonAsync<PostShuffleResult>();
            return Ok(result);
        }
    }

    [HttpGet("{deckCount:int}")]
    public async Task<ActionResult<dynamic>> GetShuffle([FromRoute] int deckCount = 1)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xpto");
            var result = await httpClient.GetFromJsonAsync<GetShuffleResult>($"http://deckofcardsapi.com/api/deck/new/shuffle/?deck_count={deckCount}");
            return Ok(result);
        }
    }

    [HttpGet]
    [Route("cep")]
    public async Task<ActionResult<dynamic>> GetCEP()
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xpto");
            httpClient.DefaultRequestHeaders.Add("x-pooling", "xpto");
            var response = await httpClient.GetFromJsonAsync<Cep>("https://viacep.com.br/ws/19025000/json/");
            return Ok(response);
        }
    }

}
