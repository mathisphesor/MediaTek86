using MySql.Data.MySqlClient;
using System.Data;

namespace MediaTek86.bddmanager
{
    public class BddManager
    {
        private readonly string chaineConnexion;

        public BddManager(string chaineConnexion)
        {
            this.chaineConnexion = chaineConnexion;
        }

        public DataTable ExecuteSelect(string requete, params MySqlParameter[] parametres)
        {
            DataTable table = new DataTable();

            using (MySqlConnection connexion = new MySqlConnection(chaineConnexion))
            {
                connexion.Open();

                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddRange(parametres);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(commande))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        public int ExecuteNonQuery(string requete, params MySqlParameter[] parametres)
        {
            using (MySqlConnection connexion = new MySqlConnection(chaineConnexion))
            {
                connexion.Open();

                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddRange(parametres);
                    return commande.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(string requete, params MySqlParameter[] parametres)
        {
            using (MySqlConnection connexion = new MySqlConnection(chaineConnexion))
            {
                connexion.Open();

                using (MySqlCommand commande = new MySqlCommand(requete, connexion))
                {
                    commande.Parameters.AddRange(parametres);
                    return commande.ExecuteScalar();
                }
            }
        }
    }
}