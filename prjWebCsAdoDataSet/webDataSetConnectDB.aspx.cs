using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;///sql server                                                

namespace prjWebCsAdoDataSet
{
    public partial class webDataSetConnectDB : System.Web.UI.Page
    {

        //declaration de variables globales a la page
        static DataSet mySet;
        static string mode;
        static Int32 refEquipe;
        static Int32 nbJoueurs, indice;
        SqlDataAdapter adpEquipe;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                mySet = ouvrirDataset();
                gridJoueurs.DataSource = mySet.Tables["Joueurs"];
                gridJoueurs.DataBind();
                remplireListeEquipe();
                ActiverBoutton(true, false);
            }
        }

        private DataSet ouvrirDataset()
        {
            DataSet setSport= new DataSet();

            //etape 1 : ouvrir laa connexion a la BD 
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportDB;Integrated Security=True";
            myConn.Open();


            //etape 2 : Creer des commandes pour ajouter des tables au dataSet

            string sql = "SELECT * FROM Equipes";
            SqlCommand myCmd = new SqlCommand(sql, myConn);


            // etape 3 : creer un adapter pour remplire le dataset   

            adpEquipe = new SqlDataAdapter(myCmd);
            adpEquipe.Fill(setSport,"Equipes");

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
            refEquipe = Int32.Parse(lstEquipe.SelectedItem.Value);
            // ----- Chercher l'equipe qui a ce numero de refEquipe ----

            // version boucle 
            //foreach (DataRow myrow in mySet.Tables["Equipes"].Rows) 
            //{
            //    if (myrow["RefEquipe"].ToString() == refEquipe.ToString())
            //    {
            //        txtNom.Text = myrow["Nom"].ToString();
            //        txtVille.Text = myrow["Ville"].ToString();
            //        txtBudget.Text = myrow["Budget"].ToString();
            //        txtCoach.Text = myrow["Coach"].ToString();
            //        break; 
            //    }
            //}
            //version poo avec la methode find de rows
            //DataRow myrow=mySet.Tables["Equipes"].Rows.Find(refEquipe);
            //txtNom.Text = myrow["Nom"].ToString();
            //txtVille.Text = myrow["Ville"].ToString();
            //txtBudget.Text = myrow["Budget"].ToString();
            //txtCoach.Text = myrow["Coach"].ToString();


            //version poo avec la methode 
            DataRow[] mesrows = mySet.Tables["Equipes"].Select("RefEquipe =" + refEquipe);
            DataRow myrow = mesrows.First();
            txtNom.Text = myrow["Nom"].ToString();
            txtVille.Text = myrow["Ville"].ToString();
            txtBudget.Text = myrow["Budget"].ToString();
            txtCoach.Text = myrow["Coach"].ToString();

            //---trouvez les joueurs des equipes selectionnee ----

            //methode poo avec select 
            DataRow[] lesJoueurs = mySet.Tables["Joueurs"].Select("ReferEquipe =" + refEquipe);
            nbJoueurs = lesJoueurs.Length;
            if (lesJoueurs.Length != 0)
            {
                gridJoueurs.DataSource = lesJoueurs.CopyToDataTable();
                gridJoueurs.DataBind();
            }
            else
            {
                gridJoueurs.DataSource = null;
                gridJoueurs.DataBind();
            }
            // recuperer l'indice de l'element selectionnee 
            indice = lstEquipe.SelectedIndex;
  
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            mode = "ajout";
            ActiverBoutton(false, true);
            txtBudget.Text = txtNom.Text = txtCoach.Text = txtVille.Text = "";
            txtNom.Focus();
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            ActiverBoutton(false, true);
            mode = "modif";
            txtNom.Focus();
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            // trouber equipe selectionnee
            if (nbJoueurs == 0)
            {
                DataRow myrow = mySet.Tables["Equipes"].Rows.Find(refEquipe);
                myrow.Delete();
                //sauveggarder (ou synchroniser) contenu dataset vers la database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(adpEquipe);
                adpEquipe.Update(mySet, "Equipes");

                // Mise a jour (update) database vers dataset 
                // mySet.Tables.Remove("Equipes"); bonne version 
                mySet.Tables.Clear();//myset=null
                mySet = ouvrirDataset();
                remplireListeEquipe();
                txtBudget.Text = txtNom.Text = txtCoach.Text = txtVille.Text = "";
            }
        }

        protected void btnSauveguarder_Click(object sender, EventArgs e)
        {
            //if (mode == "ajout")
            //{
            //    DataRow myrow = mySet.Tables["Equipes"].NewRow();
            //}
            DataRow myrow;
            if (mode == "ajout")
            {
                DataRow myRow = mySet.Tables["Equipes"].NewRow();
                // remplir le datarow avec les valeurs des textbox
                myRow["RefEquipe"] = mySet.Tables["Equipes"].Rows.Count + 1;
                myRow["Nom"] = txtNom.Text;
                myRow["Ville"] = txtVille.Text;
                myRow["Budget"] = Convert.ToDecimal(txtBudget.Text);
                myRow["Coach"] = txtCoach.Text;


                //    ajouter le datarow dans la table
                mySet.Tables["Equipes"].Rows.Add(myRow);


              


            }

            else if (mode == "modif")
            {
                // Trouver equipe selectionne 
                myrow = mySet.Tables["Equipes"].Rows.Find(refEquipe);
                //remplirle data row avec les textes box
                myrow["Nom"] = txtNom.Text;
                myrow["Ville"] = txtVille.Text;
                myrow["Budget"] = Convert.ToDecimal(txtBudget.Text);
                myrow["Coach"] = txtCoach.Text;

                //Mise a jour  la liste des equipes 


            }
            remplireListeEquipe();
            ActiverBoutton(false, true);
            //sauveggarder (ou synchroniser) contenu dataset vers la database
            SqlCommandBuilder myBuilder = new SqlCommandBuilder(adpEquipe);
            adpEquipe.Update(mySet, "Equipes");

            // Mise a jour (update) database vers dataset 
            // mySet.Tables.Remove("Equipes"); bonne version 
            mySet.Tables.Clear();//myset=null
            mySet = ouvrirDataset();
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (indice == -1)
            {
                indice = 0;

            }
            lstEquipe.SelectedIndex = indice;
            lstEquipe_SelectedIndexChanged(sender, e);
            ActiverBoutton(true, false);
        }

        private void remplireListeEquipe() { 
        //{if (lstEquipe.Items.Count == 0) { //eviter de le remplire plusieurs fois
        //        //version boucle 
        //        //foreach (DataRow myrow in mySet.Tables["Equipes"].Rows)
        //        //{
        //        //    ListItem elem = new ListItem();
        //        //    elem.Text = myrow["Nom"].ToString();
        //        //    elem.Value = myrow["RefEquipe"].ToString();
        //        //    lstEquipe.Items.Add(elem);
        //        //}
        //        //}


                //version dataBiding

                lstEquipe.DataTextField = "Nom";
            lstEquipe.DataValueField = "RefEquipe";
            lstEquipe.DataSource = mySet.Tables["Equipes"];
            lstEquipe.DataBind();


        }
        private void ActiverBoutton(bool AjModSupp, bool SauvAnn)
        {
            btnAjouter.Visible = AjModSupp;
            btnModifier.Visible = AjModSupp;
            btnSupprimer.Visible = AjModSupp;
            btnAnnuler.Visible = SauvAnn;
            btnSauveguarder.Visible = SauvAnn;

        }
    }
}