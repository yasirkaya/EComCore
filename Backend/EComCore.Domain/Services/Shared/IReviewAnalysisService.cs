namespace EComCore.Domain.Services.Shared
{
    public interface IReviewAnalysisService
    {
        Task<string> AnalyzeReviewAsync(string reviewText);
    }
}