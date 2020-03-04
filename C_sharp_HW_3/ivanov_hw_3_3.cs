using System;
using static System.Console;
namespace USA 
{
class Washington {
static public string Name {
get {return "Washington";}
}	
static public int Population {
get {return 650000;}
}
}
}
namespace Germany 
{
class Berlin {
static public string Name {
get {return "Berlin";}
}	
static public int Population {
get {return 3750000;}
}
}
}
namespace Russia 
{
class Moscow {
static public string Name {
get {return "Moscow";}
}	
static public int Population {
get {return 12600000;}
}
}
}
namespace diff 
{
	class Program {
static public void Main(){
	string res;
WriteLine("{0} and {1} - population in {2} is larger", USA.Washington.Name, Germany.Berlin.Name, res = USA.Washington.Population > Germany.Berlin.Population ? USA.Washington.Name: Germany.Berlin.Name); 
WriteLine("{0} and {1} - population in {2} is larger", USA.Washington.Name, Russia.Moscow.Name, res = USA.Washington.Population > Russia.Moscow.Population ? USA.Washington.Name: Russia.Moscow.Name); 
WriteLine("{0} and {1} - population in {2} is larger", Russia.Moscow.Name, Germany.Berlin.Name, res = Russia.Moscow.Population > Germany.Berlin.Population ? Russia.Moscow.Name: Germany.Berlin.Name); 
}
}
}
