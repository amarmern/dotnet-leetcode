Client

|
| GET /api/v1/payment/paymentStatus?paymentId=12345
|

PaymentController

|
| await GetPaymentStatusAsync()
|

ProcessPayment Service

|
| HttpClient.GetAsync()
|

External Payment Gateway API

|
| JSON Response
|

ProcessPayment

|
| return response
|

PaymentController

|
| return Ok(response)
