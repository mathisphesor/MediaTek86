using MySql.Data.MySqlClient;
using System.Data;

namespace MediaTek86.bddmanager
{
    public class BddManager
    {
        private MySqlConnection connexion;

        public BddManager(string chaineConnexion)
        {
            connexion = new MySqlConnection(chaineConnexion);
        }

        public DataTable ExecuteSelect(string requete)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(requete, connexion);
            adapter.Fill(table);
            return table;
        }

        public int ExecuteNonQuery(string requete)
        {
            connexion.Open();
            MySqlCommand commande = new MySqlCommand(requete, connexion);
            int result = commande.ExecuteNonQuery();
            connexion.Close();
            return result;
        }
    }
}