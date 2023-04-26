// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

class Program {
    public static void Main() {
        Clients client = new Clients();

        // List<Dictionary<string, object>> clients = client.findall();
        // foreach(Dictionary<string, object> data in clients) {
        //     Console.WriteLine(data["id"] + " " + data["nom"]);
        // }

        Dictionary<string, object> data = client.findone(1);
        Console.WriteLine(data["id"] + " " + data["nom"]);
        // foreach (KeyValuePair<string, object> kvp in data) {
        //     Console.WriteLine("Clé = {0}, Valeur = {1}", kvp.Key, kvp.Value);
        // }
    }
}
