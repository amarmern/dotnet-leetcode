
var builder = WebApplication.CreateBuilder(args);

builder.Service.AddControllers();

//Register Hrrp client

builder.Service.AddHttpClient<IProcessPayment, processPaymnet>();