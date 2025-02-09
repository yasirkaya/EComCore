
using System.Net.Http.Json;
using System.Text.Json;
using EComCore.Domain.Services.Shared;

namespace EComCore.Application.Services.Shared;
public class ReviewAnalysisService : IReviewAnalysisService
{
    private readonly HttpClient _httpClient;

    public ReviewAnalysisService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> AnalyzeReviewAsync(string reviewText)
    {
        var request = new { review_text = reviewText };

        var response = await _httpClient.PostAsJsonAsync("http://127.0.0.1:8000/analyze_review", request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("AIFlow API is not responding correctly.");
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<JsonElement>(responseBody);

        return result.GetProperty("result").GetString();
    }
}
