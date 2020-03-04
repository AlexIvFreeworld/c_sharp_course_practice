using System;
using static System.Console;
namespace hw_5_2
{
class Syst {
public int X {set; get;}
public int Y {set; get;}
public int A1 {set; get;}
public int B1 {set; get;}
public int A2 {set; get;}
public int B2 {set; get;}
		public void Solve()
		{
			if (((A1 - A2) != 0 && (B2 - B1) == 0) || ((A1 - A2) == 0 && (B2 - B1) != 0))
				WriteLine("System hasn't solve");
			else
			{
				WriteLine($"{A1 - A2}X = {B2 - B1}Y");
			}
		}
//public override string ToString(){
//return $"X = {X}, Y = {Y}";
//}
}
class Program {
static public void Main(){
Syst S = new Syst { A1 = 4, B1 = 4, A2 = 8, B2 = 4};
S.Solve();
//WriteLine(S);
}
}
}
