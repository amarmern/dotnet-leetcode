public interface IprocessPayment
{
    Task<string> GetPaymentStatusAsync(string paymentId);
}
//step 3 Service Implementation

public class ProcessPayment : IprocessPayment
{
    private readonly HttpClient _httpClient;

    public ProcessPayment(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetPaymentStatusAsync(string paymentId)
    {
        var response = await _httpClient.GetAsync($"https://paymentgateway.com/api/paymentStatus/{paymentId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsByteArrayAsync();

    }
}

