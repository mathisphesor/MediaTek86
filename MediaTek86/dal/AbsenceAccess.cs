using MediaTek86.bddmanager;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MediaTek86.dal
{
    public class AbsenceAccess
    {
        private readonly BddManager bdd;

        public AbsenceAccess()
        {
            bdd = new BddManager(Access.GetChaineConnexion());
        }

        public DataTable GetLesAbsences(int idpersonnel)
        {
            string req =
                "SELECT a.idpersonnel, a.datedebut, a.datefin, m.idmotif, m.libelle AS motif " +
                "FROM absence a " +
                "INNER JOIN motif m ON a.idmotif = m.idmotif " +
                "WHERE a.idpersonnel=@idpersonnel " +
                "ORDER BY a.datedebut DESC";

            return bdd.ExecuteSelect(
                req,
                new MySqlParameter("@idpersonnel", idpersonnel)
            );
        }

        public void AjouterAbsence(int idpersonnel, DateTime datedebut, DateTime datefin, int idmotif)
        {
            string req =
                "INSERT INTO absence(idpersonnel, datedebut, datefin, idmotif) " +
                "VALUES(@idpersonnel, @datedebut, @datefin, @idmotif)";

            bdd.ExecuteNonQuery(
                req,
                new MySqlParameter("@idpersonnel", idpersonnel),
                new MySqlParameter("@datedebut", datedebut),
                new MySqlParameter("@datefin", datefin),
                new MySqlParameter("@idmotif", idmotif)
            );
        }

        public void ModifierAbsence(int idpersonnel, DateTime ancienneDateDebut, DateTime nouvelleDateDebut, DateTime datefin, int idmotif)
        {
            string req =
                "UPDATE absence SET datedebut=@nouvelleDateDebut, datefin=@datefin, idmotif=@idmotif " +
                "WHERE idpersonnel=@idpersonnel AND datedebut=@ancienneDateDebut";

            bdd.ExecuteNonQuery(
                req,
                new MySqlParameter("@idpersonnel", idpersonnel),
                new MySqlParameter("@ancienneDateDebut", ancienneDateDebut),
                new MySqlParameter("@nouvelleDateDebut", nouvelleDateDebut),
                new MySqlParameter("@datefin", datefin),
                new MySqlParameter("@idmotif", idmotif)
            );
        }

        public void SupprimerAbsence(int idpersonnel, DateTime datedebut)
        {
            string req =
                "DELETE FROM absence WHERE idpersonnel=@idpersonnel AND datedebut=@datedebut";

            bdd.ExecuteNonQuery(
                req,
                new MySqlParameter("@idpersonnel", idpersonnel),
                new MySqlParameter("@datedebut", datedebut)
            );
        }
    }
}