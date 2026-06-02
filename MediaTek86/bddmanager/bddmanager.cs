using MySql.Data.MySqlClient;
using System.Data;

namespace MediaTek86.bddmanager
{
    /// <summary>
    /// Classe singleton permettant de gérer la connexion à la base de données.
    /// </summary>
    public class BddManager
    {
        private static BddManager instance;
        private MySqlConnection connexion;

        /// <summary>
        /// Constructeur privé.
        /// </summary>
        private BddManager(string chaineConnexion)
        {
            connexion = new MySqlConnection(chaineConnexion);
        }

        /// <summary>
        /// Retourne l'instance unique de BddManager.
        /// </summary>
        public static BddManager GetInstance(string chaineConnexion)
        {
            if (instance == null)
            {
                instance = new BddManager(chaineConnexion);
            }

            return instance;
        }

        /// <summary>
        /// Ouvre la connexion à la base de données.
        /// </summary>
        public void Open()
        {
            if (connexion.State == ConnectionState.Closed)
            {
                connexion.Open();
            }
        }

        /// <summary>
        /// Ferme la connexion à la base de données.
        /// </summary>
        public void Close()
        {
            if (connexion.State == ConnectionState.Open)
            {
                connexion.Close();
            }
        }

        /// <summary>
        /// Exécute une requête SELECT.
        /// </summary>
        public DataTable ExecuteSelect(string requete)
        {
            DataTable table = new DataTable();

            Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter(requete, connexion);
            adapter.Fill(table);

            Close();

            return table;
        }

        /// <summary>
        /// Exécute une requête INSERT, UPDATE ou DELETE.
        /// </summary>
        public int ExecuteNonQuery(string requete)
        {
            Open();

            MySqlCommand commande = new MySqlCommand(requete, connexion);
            int resultat = commande.ExecuteNonQuery();

            Close();

            return resultat;
        }
    }
}