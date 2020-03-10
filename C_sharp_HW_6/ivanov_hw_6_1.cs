using System;
using static System.Console;
namespace HW_6_1
{
	//enum Color {Red, Green, Blue}
abstract class Figure{
public int Side_1{set; get;}
public int Place_X{set; get;}
public string Color{set; get;}
abstract public void Show();
}	
class Rectangle : Figure {
public int Side_2{set; get;}
public override void Show(){
	switch(Color){
		case "Red":
 Console.ForegroundColor = ConsoleColor.Red;
break;
		case "Green":
 Console.ForegroundColor = ConsoleColor.Green;
break;
		case "Blue":
 Console.ForegroundColor = ConsoleColor.Blue;
break;
	}
for(int i = 0; i < Side_2; i++){
for(int j = 0; j < Place_X; j++){
Write(" ");
}
for(int k = 0; k < Side_1; k++){
Write("*");
}
WriteLine();
}
 Console.ResetColor();
}
}
class Rhombus : Figure {
public override void Show(){
	switch(Color){
		case "Red":
 Console.ForegroundColor = ConsoleColor.Red;
break;
		case "Green":
 Console.ForegroundColor = ConsoleColor.Green;
break;
		case "Blue":
 Console.ForegroundColor = ConsoleColor.Blue;
break;
	}
for(int i = 0; i < Side_1/2+1; i++){
for(int j = 0; j < Place_X; j++){
Write(" ");
}
for(int m = 0; m < Side_1/2 - i; m++){
Write(" ");
}
for(int k = 0; k < i*2+1; k++){
Write("*");
}
WriteLine();
}
for(int i = Side_1/2; i > 0; i-=2){
for(int j = 0; j < Place_X; j++){
Write(" ");
}
for(int m = 0; m < i -1; m++){
Write(" ");
}
for(int k = 0; k < i*2+1; k++){
Write("*");
}
WriteLine();
}
 Console.ResetColor();
}
}
class Program{
static public void Main(){
Figure F_1 = new Rectangle{Side_1 = 3, Place_X = 5, Color = "Red", Side_2 = 6};
F_1.Show();
Figure F_2 = new Rectangle{Side_1 = 5, Place_X = 15, Color = "Green", Side_2 = 3};
F_2.Show();
Figure F_3 = new Rectangle{Side_1 = 10, Place_X = 25, Color = "Blue", Side_2 = 6};
F_3.Show();
Figure F_4 = new Rhombus{Side_1 = 5, Place_X = 35, Color = "Red"};
F_4.Show();

}
}
}
