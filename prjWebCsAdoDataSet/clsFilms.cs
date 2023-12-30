using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjWebCsAdoDataSet
{
    public class clsFilms
    {
        private string titre;
        private string genre;
        private int annee;

        public clsFilms(string titre, string genre, int annee)
        {
            this.Titre = titre;
            this.Genre = genre;
            this.Annee = annee;

            object myobj= new object();
            
         
        }

        public string Titre { get => titre; set => titre = value; }
        public string Genre { get => genre; set => genre = value; }
        public int Annee { get => annee; set => annee = value; }
        public override string ToString()
        {
            return "<br />Titre : " + titre + "<br />Genre : " + genre + "<br />Annee : " + annee;
        }
    }
}