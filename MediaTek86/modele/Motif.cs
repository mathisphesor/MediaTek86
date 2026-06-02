namespace MediaTek86.modele
{
    public class Motif
    {
        public int Idmotif { get; set; }
        public string Libelle { get; set; }

        public Motif(int idmotif, string libelle)
        {
            Idmotif = idmotif;
            Libelle = libelle;
        }

        public override string ToString()
        {
            return Libelle;
        }
    }
}