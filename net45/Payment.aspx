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
    data-key="<Enter your Api Key here>"
    data-amount="100"
    data-name="Razorpay"
    data-description="Purchase Description"
    data-order_id="<%=orderId%>"
    data-image="https://razorpay.com/favicon.png"
    data-prefill.name="Gaurav Kumar"
    data-prefill.email="gaurav.kumar@example.com"
    data-prefill.contact="9123456789"
    data-theme.color="#F37254"
></script>
<input type="hidden" value="Hidden Element" name="hidden">
</form>
</body>
</html>
