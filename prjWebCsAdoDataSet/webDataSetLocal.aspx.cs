using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoDataSet
{
    public partial class webDataSetLocal : System.Web.UI.Page
    {
        //declaration de variables globales a la page
        static DataSet mySet;
        static string mode;
        static Int32 refEquipe;
        static Int32 nbJoueurs,indice;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                mySet = CreerDataset();
                gridJoueurs.DataSource = mySet.Tables["Joueurs"];
                gridJoueurs.DataBind();
                remplireListeEquipe();
                ActiverBoutton(true, false);
            }
        }

        private void remplireListeEquipe()
        {
            //version boucle 
            //foreach (DataRow myrow in mySet.Tables["Equipes"].Rows)
            //{
            //    ListItem elem= new ListItem();
            //    elem.Text = myrow["Nom"].ToString();
            //    elem.Value = myrow["RefEquipe"].ToString();
            //    lstEquipe.Items.Add(elem);
            //}

            //version dataBiding 

            lstEquipe.DataTextField = "Nom"; 
            lstEquipe.DataValueField = "RefEquipe";
            lstEquipe.DataSource = mySet.Tables["Equipes"];
            lstEquipe.DataBind();


        }

        private DataSet CreerDataset()
        {
            //creation d'une instance dataset (toujours avec new )
            DataSet setSport = new DataSet();


            //creation table equipe
            DataTable myTb = new DataTable("Equipes");


            //creation du champ RefEquipe
            DataColumn myCol = new DataColumn("RefEquipe", typeof(Int32));
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 0;
            myCol.AutoIncrementStep = 1;
            myTb.Columns.Add(myCol);


            //creation du champ Nom
            myCol = new DataColumn("Nom", typeof(string));
            myCol.MaxLength = 50;
            myTb.Columns.Add(myCol);


            //creation du champ Ville
            myCol = new DataColumn("Ville", typeof(string));
            myCol.MaxLength = 50;
            myTb.Columns.Add(myCol);


            //creation du champ budget
            myCol = new DataColumn("Budget", typeof(decimal));
            myTb.Columns.Add(myCol);


            //creation du champ Coach
            myCol = new DataColumn("Coach", typeof(string));
            myCol.MaxLength = 50;
            myTb.Columns.Add(myCol);


            // Creation des index
            DataColumn[] cles = new DataColumn[1];
            cles[0] = myTb.Columns["RefEquipe"];
            myTb.PrimaryKey = cles;


            setSport.Tables.Add(myTb);


            //creation table joueurs
            myTb = new DataTable("Joueurs");


            //creation du champ RefEquipe
            myCol = new DataColumn("RefJoueur", typeof(Int32));
            myCol.AutoIncrement = true;
            myCol.AutoIncrementSeed = 0;
            myCol.AutoIncrementStep = 1;
            myTb.Columns.Add(myCol);


            //creation du champ Nom
            myCol = new DataColumn("Nom", typeof(string));
            myCol.MaxLength = 50;
            myTb.Columns.Add(myCol);


            //creation du champ Ville
            myCol = new DataColumn("Poste", typeof(string));
            myCol.MaxLength = 50;
            myTb.Columns.Add(myCol);


            //creation du champ budget
            myCol = new DataColumn("Salaire", typeof(decimal));
            myTb.Columns.Add(myCol);


            //creation du champ Coach
            myCol = new DataColumn("ReferEquipe", typeof(Int32));
            myTb.Columns.Add(myCol);


            // Creation des index
            DataColumn[] cles2 = new DataColumn[1];
            cles2[0] = myTb.Columns["RefJoueur"];
            myTb.PrimaryKey = cles2;


            setSport.Tables.Add(myTb);


            //Creation de la relation
            DataRelation myRel = new DataRelation("Equipe_Joueur", setSport.Tables["Equipes"].Columns["RefEquipe"], setSport.Tables["joueurs"].Columns["ReferEquipe"]);
            setSport.Relations.Add(myRel);


            //Remplir la table Equipe
            DataTable tabEquipe = setSport.Tables["Equipes"];
            //1er enregistrement ou datarow
            DataRow myRow = tabEquipe.NewRow();
            //myRow["RefEquipe"] = 1; //Non car c'est AutoNumber
            myRow["Nom"] = "FC-Barca";
            myRow["Ville"] = "Barcelone";
            myRow["Budget"] = "60000";
            myRow["Coach"] = "Xavi";


            tabEquipe.Rows.Add(myRow);


            //2eme enregistrement
            myRow = tabEquipe.NewRow();
            myRow["Nom"] = "Reds Liverpool";
            myRow["Ville"] = "Liverpool";
            myRow["Budget"] = "1000000";
            myRow["Coach"] = "Klopp";


            tabEquipe.Rows.Add(myRow);


            //3eme enregistrement
            myRow = tabEquipe.NewRow();
            //myRow["RefEquipe"] = 1; //Non car c'est AutoNumber
            myRow["Nom"] = "Real-Madrid";
            myRow["Ville"] = "Madrid";
            myRow["Budget"] = "700000";
            myRow["Coach"] = "Ancelotti";


            tabEquipe.Rows.Add(myRow);


            // Remplire table des joueurs 
            DataTable tabJoueur = setSport.Tables["Joueurs"];

            myRow = tabJoueur.NewRow();
            myRow["Nom"] = "Pedri Barca";
            myRow["Poste"] = "Milieu";
            myRow["Salaire"] = "15000";
            myRow["ReferEquipe"] = 0;
            tabJoueur.Rows.Add(myRow);

            myRow = tabJoueur.NewRow();
            myRow["Nom"] = "Poyal Barca";
            myRow["Poste"] = "Defense";
            myRow["Salaire"] = "1500000";
            myRow["ReferEquipe"] = 0;
            tabJoueur.Rows.Add(myRow);

            myRow = tabJoueur.NewRow();
            myRow["Nom"] = "kounde Barca";
            myRow["Poste"] = "Defense";
            myRow["Salaire"] = "1545000";
            myRow["ReferEquipe"] = 0;
            tabJoueur.Rows.Add(myRow);

            myRow = tabJoueur.NewRow();
            myRow["Nom"] = "Vini Real";
            myRow["Poste"] = "Attack";
            myRow["Salaire"] = "500000";
            myRow["ReferEquipe"] = 2;
            tabJoueur.Rows.Add(myRow);

            myRow = tabJoueur.NewRow();
            myRow["Nom"] = "Belingham Real";
            myRow["Poste"] = "milieu";
            myRow["Salaire"] = "8456320";
            myRow["ReferEquipe"] = 2;
            tabJoueur.Rows.Add(myRow);

            myRow = tabJoueur.NewRow();
            myRow["Nom"] = "Militao Real";
            myRow["Poste"] = "Defense";
            myRow["Salaire"] = "15450";
            myRow["ReferEquipe"] = 2;
            tabJoueur.Rows.Add(myRow);

            myRow = tabJoueur.NewRow();
            myRow["Nom"] = "Mo Salah Liverpool";
            myRow["Poste"] = "Attack";
            myRow["Salaire"] = "5612304798";
            myRow["ReferEquipe"] = 1;
            tabJoueur.Rows.Add(myRow);


            return setSport;
        }

        protected void lstEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            refEquipe=Int32.Parse(lstEquipe.SelectedItem.Value);
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
            DataRow[] mesrows= mySet.Tables["Equipes"].Select("RefEquipe =" +refEquipe);
            DataRow myrow = mesrows.First();
            txtNom.Text = myrow["Nom"].ToString();
            txtVille.Text = myrow["Ville"].ToString();
            txtBudget.Text = myrow["Budget"].ToString();
            txtCoach.Text = myrow["Coach"].ToString();

            //---trouvez les joueurs des equipes selectionnee ----

            //methode poo avec select 
            DataRow[] lesJoueurs = mySet.Tables["Joueurs"].Select("ReferEquipe ="+ refEquipe);
            nbJoueurs=lesJoueurs.Length;
            if( lesJoueurs.Length != 0)
            {
                gridJoueurs.DataSource = lesJoueurs.CopyToDataTable();
                gridJoueurs.DataBind();
            }
           else
            {
                gridJoueurs.DataSource=null;
                gridJoueurs.DataBind();
            }
            // recuperer l'indice de l'element selectionnee 
            indice =lstEquipe.SelectedIndex;
        }

        private void ActiverBoutton(bool AjModSupp, bool SauvAnn)
        {
            btnAjouter.Visible = AjModSupp;
            btnModifier.Visible = AjModSupp;
            btnSupprimer.Visible = AjModSupp;
            btnAnnuler.Visible = SauvAnn;
            btnSauveguarder.Visible = SauvAnn;  

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
                remplireListeEquipe();
                txtBudget.Text = txtNom.Text=txtCoach.Text=txtVille.Text="";
            }
        }

        protected void btnSauveguarder_Click(object sender, EventArgs e)
        {
            DataRow myrow;
            if (mode == "ajout") 
            {
                //creer un datarow de la forme de la table equipes

                myrow = mySet.Tables["Equipes"].NewRow();

                //remplirle data row avec les textes box
                myrow["Nom"] = txtNom.Text;
                myrow["Ville"] = txtVille.Text;
                myrow["Budget"] = Convert.ToDecimal(txtBudget.Text);
                myrow["Coach"] = txtCoach.Text;

                //sauveguarder ou ajouter le data row dans la table

                mySet.Tables["Equipes"].Rows.Add(myrow);

                //rmplire la liste des equipes 

                
            }
           
            if (mode=="modif")
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

        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (indice== -1)
            {
                indice = 0; 

            }
            lstEquipe.SelectedIndex = indice;
            lstEquipe_SelectedIndexChanged(sender, e);
            ActiverBoutton(true, false);
        }
    }
}