namespace MediaTek86.modele
{
    public class Service
    {
        public int Idservice { get; set; }
        public string Nom { get; set; }

        public Service(int idservice, string nom)
        {
            Idservice = idservice;
            Nom = nom;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}