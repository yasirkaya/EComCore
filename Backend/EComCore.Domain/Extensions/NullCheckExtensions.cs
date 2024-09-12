namespace EComCore.Domain.Extensions;

public static class NullCheckExtensions
{
    public static async Task<bool> IsNullAsync<T>(this T obj) where T : class
    {
        return await Task.FromResult(obj == null);
    }

    public static async Task EnsureNotNullAsync<T>(this T obj, string? message = null, int? id = null) where T : class
    {
        if (obj == null)
        {
            string detailedMessage = message ??
                (id.HasValue
                    ? $"{typeof(T).Name} with Id {id} not found"
                    : $"{typeof(T).Name} not found");

            throw new ArgumentNullException(nameof(id), detailedMessage);
        }

        await Task.CompletedTask;
    }

    public static async Task<bool> IsNullOrEmptyAsync<T>(this IEnumerable<T> list) where T : class
    {
        return await Task.FromResult(list is null || !list.Any());
    }

    public static async Task EnsureNotNullOrEmptyAsync<T>(this IEnumerable<T> list, string? message = null, int? id = null)
    {
        if (list is null || !list.Any())
        {
            string detailedMessage = message ??
                (id.HasValue
                    ? $"{typeof(T).Name} with Id {id} not found or is empty"
                    : $"{typeof(T).Name} not found or is empty");

            throw new ArgumentException(nameof(id), detailedMessage);
        }

        await Task.CompletedTask;
    }
}

