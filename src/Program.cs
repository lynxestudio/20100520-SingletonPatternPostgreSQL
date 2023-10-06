using System;
using System.Collections.Generic;
using System.Linq;

namespace PostSingleton
{
public class Program
{
static List<DataBase2> _conns = null;
//static List<DataBase> _conns = null;
public static int Main(string[] args)
{
	 _conns = new List<DataBase2>();
	 string op = null;
	 Console.ForegroundColor = ConsoleColor.Black;
	 do{
	Console.Write("\n");
    Console.WriteLine("+-------------------------------+");
	Console.WriteLine(" Ejemplo del patron singleton para conexiones");
	Console.Write("\n");
	Console.WriteLine("a) Conexión DB");
	Console.WriteLine("b) Ver Conexiones");
	Console.WriteLine("q) Salir");
	Console.Write("\n");
	Console.ForegroundColor = ConsoleColor.Black;
	Console.Write("Elija su opción y pulse <ENTER> : ");
	Console.ForegroundColor = ConsoleColor.Black;
	op = Console.ReadLine().ToLower();
	switch(op){
		case "a":
			ConectarDB();
			break;
		case "b":
			VerConexiones();
			break;
	}
	 }while(op != "q");
	 Console.WriteLine("\nHasta luego");
	Exit();
	return 0;
	
}
static void VerConexiones(){
try{
Console.Clear();
Console.WriteLine("\nListado de conexiones");
Console.Write("\n");
Console.WriteLine("+------------------------------------+");
Console.WriteLine("| CONEXIONES ACTIVAS                 |");
Console.WriteLine("+------------------------------------+\n");
if(_conns.Count > 0){
	/*foreach(DataBase2 c in _conns){
						Console.WriteLine("{0}",c.Info);
					}*/
var q = from c in _conns where c.IsOpen == true select c;
foreach(var i in q){
	Console.WriteLine("{0}",i.Info);
}
				}else Console.WriteLine("NO HAY CONEXIONES ACTIVAS");
}catch(Exception x){ Console.WriteLine("Excepcion " + x.Message); }
}		
static void ConectarDB(){
	try{
	Console.Clear();
	Console.WriteLine("Datos de la cadena de conexion ");
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write("Servidor y pulse <ENTER> : ");
    string server = @Console.ReadLine();
    Console.Write("Base de datos y pulse <ENTER> : ");
    string database = @Console.ReadLine();
    Console.Write("Usuario y pulse <ENTER> : ");
    string user = @Console.ReadLine();
    Console.Write("Password y pulse <ENTER> : ");
    string password = @Console.ReadLine();
	Console.ForegroundColor = ConsoleColor.Black;
	string connStr = String.Format(
    "Server={0};Port=5432;DataBase={1};User ID={2};Password={3};Protocol=3;SSL=false;SsLMode=Disable;",
    server,database,user,password);
    Console.WriteLine("Intentando conexión...");
     //Conexion sin singleton
	//DataBase db = new DataBase(connStr);
    //_conns.Add(db);
    //Conexion usando singleton 
    _conns.Add(DataBase2.GetInstance(connStr));		
	VerConexiones();
}catch(Exception x){
	Console.WriteLine("Excepción " + x.Message);
}
}
static void Exit(){
Environment.Exit(0);
}}}