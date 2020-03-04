using System;
using static System.Console;
namespace hw_5_1
{
class Coeff{
public int A {get; set;}
public int B {get; set;}
static public Coeff Parse(string str){
			Coeff Temp = new Coeff();
string[] arr = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries); 
Temp.A = Int32.Parse(arr[0]);
Temp.B = Int32.Parse(arr[1]);
			return Temp;
}
public override string ToString(){
return $"A = {A}, B = {B}";
}
}
class Program{
public static void Main(){
	Coeff C = new Coeff();
	string str;
WriteLine("Enter two number with ',' like a '2,3'");
	str = ReadLine();
	C = Coeff.Parse(str);
	WriteLine(C);
}
}
}
