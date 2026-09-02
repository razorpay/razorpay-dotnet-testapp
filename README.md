# Razorpay Test App for .NET

Test App for Razorpay .NET Integration built as an **ASP.NET Core MVC** application targeting **.NET 10**.

## Setup

1. Fill in your Razorpay credentials in `appsettings.json` (set `Razorpay:KeyId` and `Razorpay:KeySecret`).
2. Run the app:

```
dotnet run
## Docker

A multi-stage Linux Dockerfile is included:

```
docker compose up --build
```

The app will be available at `http://localhost:8080/Payment`.

## Structure

- `Controllers/PaymentController.cs` — creates the payment `Order`
- `Controllers/ChargeController.cs` — verifies the payment signature
- `Controllers/PaymentsController.cs` — Previous Payments and Refund Option
- `Views/` — MVC views for the checkout page and verification result

This app uses the [Razorpay NuGet SDK](https://www.nuget.org/packages/Razorpay).