namespace MediaTek86.modele
{
    public class Personnel
    {
        public int Idpersonnel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public int Idservice { get; set; }

        public Personnel(int idpersonnel, string nom, string prenom, string tel, string mail, int idservice)
        {
            Idpersonnel = idpersonnel;
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            Mail = mail;
            Idservice = idservice;
        }
    }
}