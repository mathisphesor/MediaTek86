using MediaTek86.bddmanager;
using System.Data;

namespace MediaTek86.dal
{
    public class MotifAccess
    {
        private readonly BddManager bdd;

        public MotifAccess()
        {
            bdd = new BddManager(Access.GetChaineConnexion());
        }

        public DataTable GetLesMotifs()
        {
            return bdd.ExecuteSelect("SELECT idmotif, libelle FROM motif ORDER BY libelle");
        }
    }
}