using System;
using System.Collections.Generic;
using Npgsql;


List<DataBase> _conns = new List<DataBase>();
string[] options = {"New connection","See connection"};
string option = null;
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine();
do
{
    Console.Clear();
    Utilities.SetTitle("PostgreSQL Singleton Example");
    Utilities.DisplayMenu(options);
    option = Utilities.Scanf("Choose option");
    try
    {
    	switch(option)
    	{
        	case "1":
            		New();
        	break;
        	case "2":
            		QueryConnections();
        	break;
        	case "0":
            		Exit();
        	break;
    	}
    }
    catch(Exception ex)
    {
	    Console.WriteLine(ex.Message);
    }
}
while(option != "0");

void New()
{
    Utilities.SetTitle(" Add new connection string");
    string server = Utilities.Scanf("Server ");
    string database = Utilities.Scanf("Database ");
    string user = Utilities.Scanf("User ");
    string password = Utilities.Scanf("Password ");
    NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
    builder.Host = server;
    builder.Database = database;
    builder.Username = user;
    builder.Password = password;
    Console.WriteLine("Trying...");
    _conns.Add(DataBase.GetInstance(builder.ConnectionString));
    QueryConnections();
}

void QueryConnections()
{
    Utilities.SetTitle("See connections");
    if(_conns.Count > 0)
    {
	    foreach(var item in _conns)
	    {
		    Console.WriteLine($"{item.Info}");
	    }
    }
    Utilities.Pause();
}

void Exit()
{
    Console.WriteLine("Closing connections...");
    if(_conns.Count > 0)
    {
	    foreach(var item in _conns)
	    {
		    item.Close();
		    Console.WriteLine($"{item.Info}");
	    }
    }
	Console.WriteLine("Goodbye!");
}
