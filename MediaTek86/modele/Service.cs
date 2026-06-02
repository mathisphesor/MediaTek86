namespace MediaTek86.modele
{
    /// <summary>
    /// Représente un service.
    /// </summary>
    public class Service
    {
        public int IdService { get; set; }
        public string Nom { get; set; }

        public Service(int idService, string nom)
        {
            IdService = idService;
            Nom = nom;
        }
    }
}