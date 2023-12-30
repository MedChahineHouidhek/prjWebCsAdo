using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjLibChahineBank;
namespace prjWebCsAdoDataSet
{
    public partial class webPageTestDll : System.Web.UI.Page
    {
        static clsListeCompte lesComptes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack==false) 
            { 
                lesComptes = new clsListeCompte();
                clsCompte c1 = new clsCompte("cp001","Cheque",1,2,2000,"Actif",25000);
                lesComptes.Ajouter(c1);
                clsCompte c2 = new clsCompte("cp002", "Epargne", 1, 2, 2005, "Actif", 250050);
                lesComptes.Ajouter(c2);
            }
        }
        protected void btnTrouvez_Click(object sender, EventArgs e)
        {
            clsCompte compteTrouver;
            string num = txtNumero.Text.Trim();
            compteTrouver=lesComptes.Trouver(num);
            if (compteTrouver != null)
            {
                lblInfo.Text = compteTrouver.Consulter().Replace("\n","<br>");
            } 

        }
    }
}