using MediaTek86.bddmanager;
using MySql.Data.MySqlClient;
using System.Data;

namespace MediaTek86.dal
{
    public class PersonnelAccess
    {
        private readonly BddManager bdd;

        public PersonnelAccess()
        {
            bdd = new BddManager(Access.GetChaineConnexion());
        }

        public DataTable GetLesPersonnels()
        {
            string req =
                "SELECT p.idpersonnel, p.nom, p.prenom, p.tel, p.mail, s.idservice, s.nom AS service " +
                "FROM personnel p " +
                "INNER JOIN service s ON p.idservice = s.idservice " +
                "ORDER BY p.nom, p.prenom";

            return bdd.ExecuteSelect(req);
        }

        public void AjouterPersonnel(string nom, string prenom, string tel, string mail, int idservice)
        {
            string req =
                "INSERT INTO personnel(nom, prenom, tel, mail, idservice) " +
                "VALUES(@nom, @prenom, @tel, @mail, @idservice)";

            bdd.ExecuteNonQuery(
                req,
                new MySqlParameter("@nom", nom),
                new MySqlParameter("@prenom", prenom),
                new MySqlParameter("@tel", tel),
                new MySqlParameter("@mail", mail),
                new MySqlParameter("@idservice", idservice)
            );
        }

        public void ModifierPersonnel(int idpersonnel, string nom, string prenom, string tel, string mail, int idservice)
        {
            string req =
                "UPDATE personnel SET nom=@nom, prenom=@prenom, tel=@tel, mail=@mail, idservice=@idservice " +
                "WHERE idpersonnel=@idpersonnel";

            bdd.ExecuteNonQuery(
                req,
                new MySqlParameter("@idpersonnel", idpersonnel),
                new MySqlParameter("@nom", nom),
                new MySqlParameter("@prenom", prenom),
                new MySqlParameter("@tel", tel),
                new MySqlParameter("@mail", mail),
                new MySqlParameter("@idservice", idservice)
            );
        }

        public void SupprimerPersonnel(int idpersonnel)
        {
            string req = "DELETE FROM personnel WHERE idpersonnel=@idpersonnel";

            bdd.ExecuteNonQuery(
                req,
                new MySqlParameter("@idpersonnel", idpersonnel)
            );
        }
    }
}