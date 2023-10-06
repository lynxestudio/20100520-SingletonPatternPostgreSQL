//04/10
//Clase que utiliza la conexión a una base de datos
//con el patrón Singleton
//xomalli@gmail.com
using System;
using System.Data;
using Npgsql;

namespace PostSingleton
{
public class DataBase2
{
static DataBase2 Instance = null;
static NpgsqlConnection _conn = null;
private DataBase2(){  }
private static void CreateInstance(){
    if(Instance == null)
    { Instance = new DataBase2();}
    }
    public static DataBase2 GetInstance(string conStr){
    if(Instance == null){
    CreateInstance();
    Instance.ConnectionString = conStr;
    Instance.GetConnection();}
    return Instance;
    }
    void GetConnection(){
    try{
    _conn = new NpgsqlConnection();
    _conn.ConnectionString = ConnectionString;
    _conn.Open();
    IsOpen = true;
	Info = String.Format(" {0}|{1}| {2}| {3}|",GetCurrentState,
    System.DateTime.Now.ToLocalTime(),_conn.DataSource,_conn.Database);
    }
    catch(NpgsqlException x){
        if (_conn.State == System.Data.ConnectionState.Open)
              _conn.Close();
    throw x;
    }
    }
    public void Close(){
		if (_conn.State == System.Data.ConnectionState.Open){
              _conn.Close();
              IsOpen = false;
		}
	}
	string ConnectionString {set;get;}
	public bool IsOpen {set;get;}
	public string Info {set;get;}	
	public string GetCurrentState{ get {return (IsOpen == true ? "Open" : "Closed");}}
}}