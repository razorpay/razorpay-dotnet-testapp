# Razorpay Test App for .NET
Test App for Razorpay .NET Integration

This app uses nuget package based sdk integration, if you are not using nuget please download 
the sdk from **[here](https://www.nuget.org/packages/Razorpay)** and add the required version
of dll in your project reference.

# Steps for Integration:

1. Make a checkout form using our Checkout Integration
2. Accept the `razorpay_payment_id` parameter in the form submission
3. Run the capture code to capture the payment

Please make sure you do the following while using this:
- Edit the key inside Payment.aspx
- Edit the keyId/keySecret in charge.aspx

This release currently uses the 1.0.0 version of the .NET SDK. Please ensure that you are
using the latest as the test app might lag behind.
