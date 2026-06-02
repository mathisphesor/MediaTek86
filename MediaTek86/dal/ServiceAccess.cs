using MediaTek86.bddmanager;
using System.Data;

namespace MediaTek86.dal
{
    public class ServiceAccess
    {
        private readonly BddManager bdd;

        public ServiceAccess()
        {
            bdd = new BddManager(Access.GetChaineConnexion());
        }

        public DataTable GetLesServices()
        {
            return bdd.ExecuteSelect("SELECT idservice, nom FROM service ORDER BY nom");
        }
    }
}