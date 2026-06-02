namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un motif d'absence.
    /// </summary>
    public class Motif
    {
        public int IdMotif { get; set; }
        public string Libelle { get; set; }

        public Motif(int idMotif, string libelle)
        {
            IdMotif = idMotif;
            Libelle = libelle;
        }
    }
}