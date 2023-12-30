using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoDataSet
{
    public partial class webLinqDataSet : System.Web.UI.Page
    {
        static DataSet mySet;
        
        static Int32 refEquipe;
        static Int32 nbJoueurs;
        SqlDataAdapter adpEquipe;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                mySet = ouvrirDataset();
               
                remplireListeEquipe();
                AfficherTousLesJoueurs();
            }
        }

        private void AfficherTousLesJoueurs()
        {
            var tousLesJoueurs = from DataRow jou in mySet.Tables["Joueurs"].Rows
                                 select jou; 
            gridJoueurs.DataSource = tousLesJoueurs.CopyToDataTable();
            gridJoueurs.DataBind();
        }

        private void remplireListeEquipe()
        {
            //linq sur dataSet (dataTable)
            var lesEquipes = from DataRow equip in mySet.Tables["Equipes"].Rows
                             select new { Nom = equip["Nom"], refEquipe = equip["RefEquipe"] };

            //databinding avec linq 
            lstEquipe.DataTextField = "Nom";
            lstEquipe.DataValueField = "RefEquipe";
            lstEquipe.DataSource= lesEquipes;
            lstEquipe.DataBind();
        }

        private DataSet ouvrirDataset()
        {
            DataSet setSport = new DataSet();

            //etape 1 : ouvrir laa connexion a la BD 
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportDB;Integrated Security=True";
            myConn.Open();


            //etape 2 : Creer des commandes pour ajouter des tables au dataSet

            string sql = "SELECT * FROM Equipes";
            SqlCommand myCmd = new SqlCommand(sql, myConn);


            // etape 3 : creer un adapter pour remplire le dataset   

            adpEquipe = new SqlDataAdapter(myCmd);
            adpEquipe.Fill(setSport, "Equipes");

            //creation des Index 
            DataColumn[] cles2 = new DataColumn[1];
            cles2[0] = setSport.Tables["Equipes"].Columns["RefEquipe"];
            setSport.Tables["Equipes"].PrimaryKey = cles2;

            //etape 2 : Creer des commandes pour ajouter des tables au dataSet

            sql = "SELECT * FROM Joueurs";
            SqlCommand myCmd2 = new SqlCommand(sql, myConn);


            // etape 3 : creer un adapter pour remplire le dataset   

            SqlDataAdapter adpJoueurs = new SqlDataAdapter(myCmd2);
            adpJoueurs.Fill(setSport, "Joueurs");




            return setSport;
        }

        protected void lstEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string refEquip = lstEquipe.SelectedItem.Value;
            var equipeTrouvees = from DataRow equip in mySet.Tables["Equipes"].Rows
                                where equip["RefEquipe"].ToString()==refEquip
                                select equip;
            DataRow lequip = equipeTrouvees.First();
            txtNom.Text = lequip["Nom"].ToString();
            txtVille.Text = lequip["Ville"].ToString();
            txtCoach.Text = lequip["Coach"].ToString();
            txtBudget.Text = lequip["Budget"].ToString();

            //trouver tous les joeurs de l'equipe selectionnee 
            var joueurstrouves = from DataRow joueur in mySet.Tables["Joueurs"].Rows
                                where joueur["ReferEquipe"].ToString() == refEquip
                                select joueur;
            if (joueurstrouves.Count() == 0)
            {
                gridJoueurs.DataSource = null;
                gridJoueurs.DataBind();  
            }
            else
            {
                gridJoueurs.DataSource = joueurstrouves.CopyToDataTable();
                gridJoueurs.DataBind();
            }


        }
    }
}