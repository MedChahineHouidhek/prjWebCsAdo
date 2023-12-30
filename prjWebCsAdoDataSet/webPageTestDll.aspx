<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webPageTestDll.aspx.cs" Inherits="prjWebCsAdoDataSet.webPageTestDll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align : center">Bank Royal</h1>
            <hr />
            Entrez Numero de compte : 
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox> <br />
            <asp:Button ID="btnTrouver" runat="server" Text="Trouvez compte" /> <br />
            <asp:Label ID="lblInfo" runat="server" Text="" Font-Bold="true" ForeColor="Navy"></asp:Label>
        </div>
    </form>
</body>
</html>
