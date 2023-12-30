<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webDataSetLocal.aspx.cs" Inherits="prjWebCsAdoDataSet.webDataSetLocal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function valider()
        {
            return window.confirm("Etes vous sur de vouloie supprimer cette equipe ?");
        }
    </script>
    <style type="text/css">
        table{
            margin : auto ; 
            width : 700px;
            border-radius : 10px ; 
            padding : 2px;
            border-spacing : 4px;
            background-color : bisque ; 
            font-weight : bold ; 
            color : saddlebrown ; 
        }
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center">Gestion DataSet statique</h1>
            <hr style ="width:600px"/>
            <table>
                <tr>
                    <td>
                        Choisir une Equipe : <br />
                         <asp:ListBox ID="lstEquipe" runat="server" AutoPostBack="True" ForeColor="Blue" Font-Bold="True" Height="100px" Width="200px" OnSelectedIndexChanged="lstEquipe_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td>
                        
                        <table class="auto-style1">
                            <tr>
                                
                                <td colspan="2">Gestion de Equpe Selectionnee</td>
                                <td rowspan="5">
                                    <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" Font-Bold="True" ForeColor="White" BackColor="Brown" Width="150px" OnClick="btnAjouter_Click" /><br />
                                    <asp:Button ID="btnModifier" runat="server" Text="Modifier" Font-Bold="True" ForeColor="White" BackColor="Brown" Width="150px" OnClick="btnModifier_Click" /><br />
                                    <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" Font-Bold="True" ForeColor="White" BackColor="Brown" Width="150px" OnClientClick="return valider();" OnClick="btnSupprimer_Click" /><br />
                                    <asp:Button ID="btnSauveguarder" runat="server" Text="Sauveguarder" Font-Bold="True" ForeColor="White" BackColor="Brown" Width="150px" OnClick="btnSauveguarder_Click" /><br />
                                    <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" Font-Bold="True" ForeColor="White" BackColor="Brown" Width="150px" OnClick="btnAnnuler_Click" /><br />
                                </td>
                            </tr>
                            <tr>
                                <td>Nom : </td>
                                <td>
                                    <asp:TextBox ID="txtNom" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px"></asp:TextBox></td>
                                
                            </tr>
                            <tr>
                                <td>Ville : </td>
                                <td> <asp:TextBox ID="txtVille" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px"></asp:TextBox></td>
                                
                            </tr>
                            <tr>
                                <td>Budget : </td>
                                <td> <asp:TextBox ID="txtBudget" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px"></asp:TextBox></td>
                                
                            </tr>
                            <tr>
                                <td>Coach : </td>
                                <td> <asp:TextBox ID="txtCoach" runat="server" Font-Bold="True" ForeColor="Blue" Width="200px"></asp:TextBox></td>
                                
                            </tr>
                            
                        </table>
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gridJoueurs" runat="server" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                           
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            
        </div>
        <div>
    
</div>
    </form>
</body>
</html>
