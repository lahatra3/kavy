using System.Data.SqlClient;

class Abonnements {
    public Abonnements() {}

    public void create(int client_id, int liste_id) {
        SqlConnection connection =  Database.db_connection();
        string query = "INSERT INTO listes(client_id, liste_id) VALUES(@ClientId, @ListeId)";

        try {
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", client_id);
            command.Parameters.AddWithValue("@ListeId", liste_id);
            command.ExecuteNonQuery();
        }
        catch(Exception e) {
            Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
        }
        finally {
            connection.Close();
        }
    }
}
