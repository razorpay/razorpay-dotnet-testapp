<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="RazorpaySampleApp.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Razorpay .Net Sample App</title>
</head>
<body>
    <form action="Charge.aspx" method="post">
<script
    src="https://checkout.razorpay.com/v1/checkout.js"
    data-key="<YOUR KEY>"
    data-amount="100"
    data-name="Razorpay"
    data-description="Purchase Description"
    data-image="https://razorpay.com/favicon.png"
    data-prefill.name="Harshil Mathur"
    data-prefill.email="support@razorpay.com"
    data-theme.color="#F37254"
></script>
<input type="hidden" value="Hidden Element" name="hidden">
</form>
</body>
</html>
