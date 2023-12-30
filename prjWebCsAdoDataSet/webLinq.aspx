<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webLinq.aspx.cs" Inherits="prjWebCsAdoDataSet.webLinq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1 style="text-align : center">LINQ sur Tableau</h1>
            <hr style="width : 600px" />
            <asp:GridView ID="gridResultat" runat="server"></asp:GridView>
            <br /> 
            <hr />
            <h1 style="text-align : center">LINQ sur Collection d'objets(Films)</h1>
 <hr style="width : 600px" />
 <asp:GridView ID="GridFilms" runat="server"></asp:GridView>
             
             <asp:GridView ID="GridLinq" runat="server"></asp:GridView>
 <br /> 
 <hr />
           
           <h1 style="text-align : center">Exercice sur Linq</h1>
<hr style="width : 600px" />
            <table>
                <tr>
                    <td>
                        choisir un genre <br />
                        <asp:ListBox ID="lstGenre" style="width : 200px" runat="server" Font-Bold="True" OnSelectedIndexChanged="lstGenre_SelectedIndexChanged"></asp:ListBox>
                        <asp:GridView ID="GridResultFilm" runat="server"></asp:GridView>
                    </td>
                    <td>

                    </td>
                </tr>
                
            </table>

            
            
<br /> 
<hr />
         </div>
    </form>
</body>
</html>
