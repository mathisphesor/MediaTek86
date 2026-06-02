using MediaTek86.bddmanager;
using MySql.Data.MySqlClient;

namespace MediaTek86.dal
{
    public class ResponsableAccess
    {
        private readonly BddManager bdd;

        public ResponsableAccess()
        {
            bdd = new BddManager(Access.GetChaineConnexion());
        }

        public bool ControleAuthentification(string login, string pwd)
        {
            string req = "SELECT COUNT(*) FROM responsable WHERE login = @login AND pwd = SHA2(@pwd, 256)";

            object resultat = bdd.ExecuteScalar(
                req,
                new MySqlParameter("@login", login),
                new MySqlParameter("@pwd", pwd)
            );

            return int.Parse(resultat.ToString()) == 1;
        }
    }
}