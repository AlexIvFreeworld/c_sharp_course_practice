using System;
using static System.Console;
namespace hw_5_3
{
class Complex {
	public Complex(){}
	public Complex(int a, int i){
this.A = a;
this.I = i;
	}
public int A {set; get;}
public int I {set; get;}
public static Complex operator+(Complex C1, Complex C2){
Complex Temp = new Complex();
Temp.A = C1.A + C2.A;
Temp.I = C1.I + C2.I;
return Temp;
}
public static Complex operator-(Complex C1, Complex C2){
Complex Temp = new Complex();
Temp.A = C1.A - C2.A;
Temp.I = C1.I - C2.I;
return Temp;
}
public static Complex operator-(Complex C1, int x){
Complex Temp = new Complex();
Temp.A = C1.A - x;
Temp.I = C1.I;
return Temp;
}
public static Complex operator*(Complex C1, Complex C2){
Complex Temp = new Complex();
Temp.A = C1.A * C2.A - C1.I * C2.I;
Temp.I = C1.A * C2.I + C2.A * C1.I;
return Temp;
}
public static Complex operator*(int x, Complex C2){
Complex Temp = new Complex();
Temp.A = x * C2.A;
Temp.I = x * C2.I;
return Temp;
}
public static Complex operator/(Complex C1, Complex C2){
Complex Temp = new Complex();
Complex TempNumer = new Complex();
Complex TempDenumer = new Complex();
TempNumer.A = C1.A * C2.A + C1.I * C2.I;
TempNumer.I = C1.A * C2.I - C2.A * C1.I;
TempDenumer.A = C2.A * C2.A;
TempDenumer.I = C2.I * C2.I;
Temp.A = TempNumer.A / (TempDenumer.A + TempDenumer.I);
Temp.I = TempNumer.I / (TempDenumer.A + TempDenumer.I);
return Temp;
}
public override string ToString(){
return $"{A} + {I}i";
}
}
class Program {
static public void Main(){
Complex z = new Complex(1,1);
 Complex z1;
 z1 = z - (z * z * z - 1) / (3 * z * z);
 Console.WriteLine("z1 = {0}", z1);
}
}
}
