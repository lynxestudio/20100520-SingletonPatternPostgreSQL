using Npgsql;
using System;
using System.Data;

public class DataBase
{
    static DataBase Instance = null;
    static NpgsqlConnection _conn = null;
    private DataBase()
    {  

    }

    private static void CreateInstance()
    {
        if(Instance == null)
        { 
            Instance = new DataBase();
        }
    }

    public static DataBase GetInstance(string conStr)
    {
        if(Instance == null)
        {
            CreateInstance();
            Instance.ConnectionString = conStr;
            Instance.GetConnection();
        }
        return Instance;
    }

    void GetConnection()
    {
        try
        {
        _conn = new NpgsqlConnection();
        _conn.ConnectionString = ConnectionString;
        _conn.Open();
        IsOpen = true;
    Info = String.Format(" {0}|{1}| {2}| {3}|",GetCurrentState,
        System.DateTime.Now.ToLocalTime(),_conn.DataSource,_conn.Database);
        }
        catch(NpgsqlException x)
        {
        if (_conn.State == System.Data.ConnectionState.Open)
              _conn.Close();
        throw x;
        }
    }

    public void Close()
    {
		if (_conn.State == System.Data.ConnectionState.Open)
        {
              _conn.Close();
       	      IsOpen = false;
    		Info = String.Format(" {0}|{1}| {2}| {3}|",GetCurrentState,
	        System.DateTime.Now.ToLocalTime(),_conn.DataSource,_conn.Database);
		}
	}
	string ConnectionString {set;get;}
	public bool IsOpen {set;get;}
	public string Info {set;get;}	
	public string GetCurrentState
    { 
        get 
        {
            return (IsOpen == true ? "Open" : "Closed");
        }
    }
}
