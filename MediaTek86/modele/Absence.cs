using System;

namespace MediaTek86.modele
{
    /// <summary>
    /// Représente une absence d'un personnel.
    /// </summary>
    public class Absence
    {
        public Personnel Personnel { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public Motif Motif { get; set; }

        public Absence(Personnel personnel, DateTime dateDebut, DateTime dateFin, Motif motif)
        {
            Personnel = personnel;
            DateDebut = dateDebut;
            DateFin = dateFin;
            Motif = motif;
        }
    }
}