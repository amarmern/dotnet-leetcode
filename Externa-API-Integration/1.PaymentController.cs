using Microsoft.AspNetCore.Mvc;

[ApiContoller]
[Route("api/v1/payment")]
public class PaymentController : ControllerBase
{
    private readonly IprocessPayment _processPayment;

    public PaymentController(IProessPayment processPayment)
    {
        _processPayment = processPayment;
    }

    [HttpGet("paymentStatus")]

    public async Task<IActionResult> GetPaymentStatus(string paymentId)
    {
        try
        {
            var response = await _processPayment.GetPaymentStatusAsync(paymentId);
        }
        catch (Exception ex)
        {

            return StatusCode(500, ex.Message);
        }
    }

}