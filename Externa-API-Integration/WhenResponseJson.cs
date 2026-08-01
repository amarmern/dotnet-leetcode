//If the external API returns JSON
/*
{
    "paymentId": "12345",
    "status": "SUCCESS",
    "amount": 500
}
*/

//create a model

public class PaymentStatusResponse
{
    public string PaymentId { get; set; }

    public string Status { get; set; }

    public decimal Amount { get; set; }
}

//Service

using System.Net.Http.Json;

public async Task<PaymentStatusResponse> GetPaymentStatusAsync(string paymentId)
{
    return await _httpClient.GetFromJsonAsync<PaymentStatusResponse>(
        $"https://paymentgateway.com/api/paymentStatus/{paymentId}");
}

//Interface
Task<PaymentStatusResponse> GetPaymentStatusAsync(string paymentId);

//Controller

