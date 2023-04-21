using System.Data.SqlClient;

class Database {
    public static SqlConnection db_connection() {
        string dbHost = "localhost";
        string dbName = "KAVY";
        string dbUser = "SA";
        string dbPassword = "";

        return new SqlConnection($"Data Source={dbHost};Initial Catalog={dbName};User Id={dbUser};Password={dbPassword}");
    }
}
