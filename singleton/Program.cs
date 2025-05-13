// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var connection = DbConnection.GetInstance();
var connection2 = DbConnection.GetInstance();
var connection3 = DbConnection.GetInstance();

Console.WriteLine(connection == connection2); // False
Console.WriteLine(connection == connection3); // False
Console.WriteLine(connection2 == connection3); // False



public class DbConnection
{
    private static DbConnection _instance;

    private DbConnection()
    {

    }

    public static DbConnection GetInstance()
    {
        // On First Call
        if(_instance == null)
        {
            _instance = new DbConnection();
        }
        return _instance;
        // return new DbConnection();
    }
}