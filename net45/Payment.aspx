<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="RazorpaySampleApp.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Razorpay .Net Sample App</title>
</head>
<body>
    <button id="rzp-button1">Pay with Razorpay</button>
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script>
        var options = {
            "name": "DJ Tiesto",
            "description": "Tron Legacy",
            "order_id": "<%=orderId%>",
            "image": "https://s29.postimg.org/r6dj1g85z/daft_punk.jpg",
            "prefill": {
                "name": "Daft Punk",
                "email": "customer@merchant.com",
                "contact": "9999999999",
            },
            "notes": {
                "address": "Hello World",
                "merchant_order_id": "12312321",
            },
            "theme": {
                "color": "#F37254"
            },
            handler: resp => alert(resp.razorpay_payment_id),
        }
        // Boolean whether to show image inside a white frame. (default: true)
        options.theme.image_padding = false;
        options.modal = {
            ondismiss: function () {
                console.log("This code runs when the popup is closed");
            },
            // Boolean indicating whether pressing escape key 
            // should close the checkout form. (default: true)
            escape: true,
            // Boolean indicating whether clicking translucent blank
            // space outside checkout form should close the form. (default: false)
            backdropclose: false
        };
        var rzp = new Razorpay(options);
        document.getElementById('rzp-button1').onclick = function (e) {
            rzp.open();
            e.preventDefault();
        }
    </script>
</body>
</html>
