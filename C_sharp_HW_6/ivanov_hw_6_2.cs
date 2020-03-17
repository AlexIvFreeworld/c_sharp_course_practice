using System;
using static System.Console;
namespace HW_6_2
{
class MyEx : Exception{
public override string Message {
get {return $"Bunkrupt!!! : negative nuber in rubles";}
}
}
class Money{
public Money(){}
public Money(string str){
string[] temp = str.Split('.');
Ruble = Int32.Parse(temp[0]);
Penny = Int32.Parse(temp[1]);
}
public int Ruble{set; get;}
public int Penny{set; get;}
public override string ToString(){
	if(Penny >= 10)
return $"{Ruble}.{Penny}";
	else
return $"{Ruble}.0{Penny}";
}
public static Money operator+ (Money M1, Money M2){
	int rub, pen;
	if(M1.Penny + M2.Penny >= 100){
        pen =  M1.Penny + M2.Penny - 100;    
	rub = M1.Ruble + M2.Ruble + 1;
	}
	else{
        rub = M1.Ruble + M2.Ruble;
	pen = M1.Penny + M2.Penny;
	}
return new Money{Ruble = rub, Penny = pen};
}
public static Money operator- (Money M1, Money M2){
	int rub, pen;
	if(M1.Penny - M2.Penny < 0){
        pen =  M1.Penny - M2.Penny + 100;    
	rub = M1.Ruble - M2.Ruble - 1;
	}
	else{
        rub = M1.Ruble - M2.Ruble;
	pen = M1.Penny - M2.Penny;
	}
	if(rub < 0) throw new MyEx();
return new Money{Ruble = rub, Penny = pen};
}
public static Money operator/ (Money M1, int x){
	int rub, pen;
        rub = M1.Ruble / x;
	pen = M1.Penny / x;
return new Money{Ruble = rub, Penny = pen};
}
public static Money operator* (Money M1, int x){
	int rub, pen;
	if(M1.Penny * x >= 100){
        pen = (M1.Penny * x)%100;    
	rub = M1.Ruble * x + (M1.Penny * x)/100;
	}
	else{
        rub = M1.Ruble * x;
	pen = M1.Penny * x;
	}
return new Money{Ruble = rub, Penny = pen};
}
public static Money operator++ (Money M1){
	int rub, pen;
	if(M1.Penny + 1 >= 100){
        pen =  M1.Penny + 1 - 100;    
	rub = M1.Ruble  + 1;
	}
	else{
        rub = M1.Ruble;
	pen = M1.Penny + 1;
	}
return new Money{Ruble = rub, Penny = pen};
}
public static Money operator-- (Money M1){
	int rub, pen;
	if(M1.Penny - 1 < 0){
        pen =  M1.Penny - 1 + 100;    
	rub = M1.Ruble  - 1;
	}
	else{
        rub = M1.Ruble;
	pen = M1.Penny - 1;
	}
	if(rub < 0) throw new MyEx();
return new Money{Ruble = rub, Penny = pen};
}
public static bool operator> (Money M1, Money M2){
	if(M1.Ruble * 100 + M1.Penny > M2.Ruble * 100 + M2.Penny){
		return true;
	}
	else{
		return false;
	}
}
public static bool operator< (Money M1, Money M2){
	if(M1.Ruble * 100 + M1.Penny < M2.Ruble * 100 + M2.Penny){
		return true;
	}
	else{
		return false;
	}
}
public static bool operator== (Money M1, Money M2){
	if(M1.Ruble * 100 + M1.Penny == M2.Ruble * 100 + M2.Penny){
		return true;
	}
	else{
		return false;
	}
}
public static bool operator!= (Money M1, Money M2){
	if(M1.Ruble * 100 + M1.Penny != M2.Ruble * 100 + M2.Penny){
		return true;
	}
	else{
		return false;
	}
}
public override int GetHashCode()
{
return this.ToString().GetHashCode();
}
public override bool Equals(object obj)
{
return this.ToString() == obj.ToString();
}
}
class Program{
static public void Main(){
bool is_working = true;
string choice, num_1, num_2;
do{
Write("Enter any (+,-,/,*,++,--,<,>,==,!=,exit) : ");
choice = ReadLine();
switch(choice){
case "+":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Write("Enter number_2 (like a 10.10) : ");
num_2 = ReadLine();
Money M_1 = new Money(num_1);
Money M_2 = new Money(num_2);
Money R = M_1 + M_2;
WriteLine($"{M_1} + {M_2} = {R}");
break;
case "-":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Write("Enter number_2 (like a 10.10) : ");
num_2 = ReadLine();
Money M_3 = new Money(num_1);
Money M_4 = new Money(num_2);
try{
Money R_2 = M_3 - M_4;
WriteLine($"{M_3} - {M_4} = {R_2}");
}
catch(MyEx e){
WriteLine(e.Message);
}
break;
case "/":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Write("Enter number_2 (whole number like a 10) : ");
num_2 = ReadLine();
Money M_5 = new Money(num_1);
int x_5 = Int32.Parse(num_2);
Money R_3 = M_5 / x_5;
WriteLine($"{M_5} / {x_5} = {R_3}");
break;
case "*":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Write("Enter number_2 (whole number like a 10) : ");
num_2 = ReadLine();
Money M_6 = new Money(num_1);
int x_6 = Int32.Parse(num_2);
Money R_4 = M_6 * x_6;
WriteLine($"{M_6} * {x_6} = {R_4}");
break;
case "++":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Money M_7 = new Money(num_1);
Write($"{M_7++}++ = ");
WriteLine($"{M_7}");
break;
case "--":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Money M_8 = new Money(num_1);
try{
Write($"{M_8--}-- = ");
WriteLine($"{M_8}");
}
catch(MyEx e){
WriteLine(e.Message);
}
break;
case ">":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Write("Enter number_2 (like a 10.10) : ");
num_2 = ReadLine();
Money M_9 = new Money(num_1);
Money M_10 = new Money(num_2);
WriteLine($"{M_9} > {M_10} = {M_9 > M_10}");
break;
case "<":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Write("Enter number_2 (like a 10.10) : ");
num_2 = ReadLine();
Money M_11 = new Money(num_1);
Money M_12 = new Money(num_2);
WriteLine($"{M_11} < {M_12} = {M_11 < M_12}");
break;
case "==":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Write("Enter number_2 (like a 10.10) : ");
num_2 = ReadLine();
Money M_13 = new Money(num_1);
Money M_14 = new Money(num_2);
WriteLine($"{M_13} == {M_14} = {M_13 == M_14}");
break;
case "!=":
Write("Enter number_1 (like a 10.10) : ");
num_1 = ReadLine();
Write("Enter number_2 (like a 10.10) : ");
num_2 = ReadLine();
Money M_15 = new Money(num_1);
Money M_16 = new Money(num_2);
WriteLine($"{M_15} != {M_16} = {M_15 != M_16}");
break;
case "exit":
is_working = false;
break;
default:
break;
}
}while(is_working);
}
}
}
