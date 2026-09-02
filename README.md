# Razorpay Test App for .NET

Test App for Razorpay .NET Integration built as an **ASP.NET Core MVC** application targeting **.NET 10**.

## Setup

1. Fill in your Razorpay credentials in `appsettings.json` (set `Razorpay:KeyId` and `Razorpay:KeySecret`).
2. Run the app:

```
dotnet run
```

3. Open `http://localhost:5000/Payment`, which creates an order via the Orders API and opens the Razorpay Checkout.
4. `Charge/Verify` validates the `razorpay_signature` on the form post-back using the SDK's `Utils.verifyPaymentSignature`.

## Docker

A multi-stage Linux Dockerfile is included:

```
docker compose up --build
```

The app will be available at `http://localhost:8080/Payment`.

## Structure

- `Controllers/PaymentController.cs` — creates the payment `Order` (amount 100 INR)
- `Controllers/ChargeController.cs` — verifies the payment signature
- `Views/` — MVC views for the checkout page and verification result

This app uses the [Razorpay NuGet SDK](https://www.nuget.org/packages/Razorpay).