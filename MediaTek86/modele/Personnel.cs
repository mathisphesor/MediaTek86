namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un membre du personnel.
    /// </summary>
    public class Personnel
    {
        public int IdPersonnel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public Service Service { get; set; }

        public Personnel(int idPersonnel, string nom, string prenom, string tel, string mail, Service service)
        {
            IdPersonnel = idPersonnel;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Mail = mail;
            Service = service;
        }
    }
}