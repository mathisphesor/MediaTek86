using System;

namespace MediaTek86.modele
{
    public class Absence
    {
        public int Idpersonnel { get; set; }
        public DateTime Datedebut { get; set; }
        public DateTime Datefin { get; set; }
        public int Idmotif { get; set; }

        public Absence(int idpersonnel, DateTime datedebut, DateTime datefin, int idmotif)
        {
            Idpersonnel = idpersonnel;
            Datedebut = datedebut;
            Datefin = datefin;
            Idmotif = idmotif;
        }
    }
}