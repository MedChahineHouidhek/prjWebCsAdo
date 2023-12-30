using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjWebCsAdoDataSet
{
    public partial class webLinq : System.Web.UI.Page
    {
        //variables globales
        static List<clsFilms> tousLesFilms;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                linqToArray();
                linqToCollection();
                RemplireListeGenre();
            }
        }
        private void RemplireListeGenre()
        {
            //foreach(clsFilms film in tousLesFilms)
            //{
            //    ListItem elem = new ListItem(film.Genre, film.Genre);
            //    if (lstGenre.Items.Contains(elem) == false)
            //    {
            //        lstGenre.Items.Add(elem);
            //    }
                
            //}

            //version Linq et DataBinding
            var lesGenres = from film in tousLesFilms

                            select new { Genre=film.Genre};
            lstGenre.DataTextField = "Genre";
            lstGenre.DataValueField = "Genre";
            lstGenre.DataSource = lesGenres.Distinct();
            lstGenre.DataBind();

        }
        private void linqToCollection()
        {
            tousLesFilms = new List<clsFilms>();
            clsFilms flm = new clsFilms("Rambo 4 ", "Action", 1980);
            tousLesFilms.Add(flm);
            tousLesFilms.Add(new clsFilms("Shutter Island", "Drama", 2010));
            tousLesFilms.Add(new clsFilms("21 Jump Street", "Action", 2013));
            tousLesFilms.Add(new clsFilms("22 Jump Street", "Action", 2015));
            tousLesFilms.Add(new clsFilms("The wolf of Wall Street", "Drama", 2008));
            tousLesFilms.Add(new clsFilms("Grown ups", "Comedy", 2011));
            GridFilms.DataSource = tousLesFilms;
            GridFilms.DataBind();
            
            var listeDrama = from film in tousLesFilms
                             where film.Genre=="Drama"
                             select film;
            GridLinq.DataSource = listeDrama;
            GridLinq.DataBind();
        }
        private void linqToArray()
        {

            Single[] tabNotes = { 75, 50, 80, 68, 87, 20, 10, 0, 100, 45 };
            List<Single> colBonnesNotes = new List<Single>();

            //foreach(Single Note in tabNotes)
            //{
            //    if (Note >= 60)
            //    {
            //        colBonnesNotes.Add(Note);   
            //    }
            //}

            //version LINQ  
            var lesBonnesNotes = from note in tabNotes
                                 where note >= 60
                                 select note;


            gridResultat.DataSource = lesBonnesNotes;
            gridResultat.DataBind();
        }

        protected void lstGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string genre = lstGenre.SelectedItem.Text;
            var lesFilms= from film in tousLesFilms
                          where film.Genre == genre
                          select film;
            GridResultFilm.DataSource = lesFilms;
            GridResultFilm.DataBind();
        }
    }
}