namespace MediaTek86.dal
{
    /// <summary>
    /// Classe contenant la chaîne de connexion à la base de données.
    /// </summary>
    public class Access
    {
        private static string chaineConnexion =
            "Server=localhost;" +
            "Database=mediatek86;" +
            "Uid=gestionnaire;" +
            "Pwd=M@th1sPh";

        /// <summary>
        /// Retourne la chaîne de connexion.
        /// </summary>
        public static string GetChaineConnexion()
        {
            return chaineConnexion;
        }
    }
}