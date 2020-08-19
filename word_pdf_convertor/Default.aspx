<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="word_pdf_convertor.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 172px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <h1>PDF Convertor <span> convert PDF files into word documents</span></h1>

<div class="auto-style1">
    <h3>&nbsp;</h3>
    <h3>&nbsp;</h3>
    <h3>&nbsp;</h3>
    <h3>Choose a file to convert:</h3>
  <asp:FileUpload ID="file" runat="server" Height="24px" Width="205px" />
    <br />
    <asp:Label ID="Result" runat="server"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="convert" Width="121px" />
</div>

        </div>
    </form>
</body>
</html>
