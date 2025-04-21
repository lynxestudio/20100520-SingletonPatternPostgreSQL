using System;
using System.Collections.Generic;
using Npgsql;


List<DataBase> _conns = new List<DataBase>();
List<string> items = new List<string>();
string[] options = {"New connection","See connection"};
string option = null;
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine();
do
{
    Console.Clear();
    Utilities.ShowMenu("PostgreSQL Singleton Example",options);
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
	    Utilities.Pause();
    }
}
while(option != "0");

void New()
{
    Utilities.ShowTitle(" Add new connection string");
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
     if(_conns.Count > 0)
    {
	    foreach(var item in _conns)
	    {
		    items.Add(item.Info);
	    }
    }
    QueryConnections();
}

void QueryConnections()
{
    
    Utilities.ShowTitle("See connections");
    Utilities.ShowGrid(items.ToArray());
    Utilities.Pause();
}

void Exit()
{
    Utilities.ShowTitle("Closing connections...");
    if(_conns.Count > 0)
    {
        items.Clear();
	    foreach(var item in _conns)
	    {
		    item.Close();
		    items.Add(item.Info);
	    }
    }
    QueryConnections();
	Console.WriteLine("Goodbye!");
}
