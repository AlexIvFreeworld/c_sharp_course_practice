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
	if(Side_1%2 == 0) Side_1++;
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
for(int i = Side_1-2; i >= 1; i-=2){
for(int j = 0; j < Place_X; j++){
Write(" ");
}
for(int m = 1; m <= (Side_1 - i)/2; m++){
Write(" ");
}
for(int k = i; k >= 1; k--){
Write("*");
}
WriteLine();
}
 Console.ResetColor();
}
}
class Triangle : Figure {
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
	if(Side_1%2 == 0) Side_1++;
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
 Console.ResetColor();
}
}
class Pyramid : Figure {
public int Side_2 {set; get;}
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
	if(Side_1%2 == 0) Side_1++;
	if(Side_2%2 == 0) Side_2++;
for(int i = 0; i < (Side_1 - Side_2)/2+1; i++){
for(int j = 0; j < Place_X; j++){
Write(" ");
}
for(int k = (Side_1 - (Side_2 + i * 2))/2; k > 0; k--){
Write(" ");
}
for(int m = Side_2+i*2; m >= 1; m--){
Write("*");
}
WriteLine();
}
 Console.ResetColor();
}
}
class MultyAngle : Figure {
public int Side_2 {set; get;}
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
	if(Side_1%2 == 0) Side_1++;
	if(Side_2%2 == 0) Side_2++;
for(int i = 0; i < (Side_1 - Side_2)/2+1; i++){
for(int j = 0; j < Place_X; j++){
Write(" ");
}
for(int k = (Side_1 - (Side_2 + i * 2))/2; k > 0; k--){
Write(" ");
}
for(int m = Side_2+i*2; m >= 1; m--){
Write("*");
}
WriteLine();
}
for(int i = 0; i < Side_2-1; i++){
for(int j = 0; j < Place_X; j++){
Write(" ");
}
for(int m = 0; m < Side_1; m++){
Write("*");
}
WriteLine();
}
for(int i = Side_1-2; i >= 1; i-=2){
for(int j = 0; j < Place_X; j++){
Write(" ");
}
for(int m = 1; m <= (Side_1 - i)/2; m++){
Write(" ");
}
for(int k = i; k >= 1; k--){
Write("*");
}
WriteLine();
}
 Console.ResetColor();
}
}
class CollectionFigure{
public CollectionFigure(){
arrF = new Figure[1];
arrF[0] = null;
count = 0;
}
public Figure[] arrF;
static int count;
public void AddFigure(Figure F){
	if(CollectionFigure.count != 0){
Array.Resize(ref arrF, arrF.Length+1);
	}
arrF[CollectionFigure.count] = F;
CollectionFigure.count++;
}
public void Show() {
foreach(var obj in arrF){
obj.Show();
}
}
}
class Program{
static public void Main(){
//Figure F_1 = new Rectangle{Side_1 = 3, Place_X = 5, Color = "Red", Side_2 = 6};
//F_1.Show();
//Figure F_2 = new Rectangle{Side_1 = 5, Place_X = 15, Color = "Green", Side_2 = 3};
//F_2.Show();
Figure F_3 = new Rectangle{Side_1 = 10, Place_X = 25, Color = "Blue", Side_2 = 6};
//F_3.Show();
Figure F_4 = new Rhombus{Side_1 = 12, Place_X = 35, Color = "Red"};
//F_4.Show();
Figure F_5 = new Triangle{Side_1 = 14, Place_X = 5, Color = "Blue"};
//F_5.Show();
Figure F_6 = new Pyramid{Side_2 = 9, Side_1 = 17, Place_X = 45, Color = "Green"};
//F_6.Show();
Figure F_7 = new MultyAngle{Side_2 = 9, Side_1 = 15, Place_X = 5, Color = "Red"};
//F_7.Show();
CollectionFigure Col = new CollectionFigure();
//Col.AddFigure(F_3);
//Col.AddFigure(F_4);
//Col.AddFigure(F_5);
//Col.Show();
string side_1, side_2, place_x;
string choice, figure, color, exit = "no";
do{
Write("Enter add figure - (1), show collection - (2), exit - (3) : ");
choice = ReadLine();
switch(choice){
	case "1":
Write("Enter figure name (Rect, Rhom, Tri, Pyr, Multy) : ");
figure = ReadLine();
switch(figure){
	case "Rect":
Write("Enter color (Red, Green, Blue) : ");
color = ReadLine();
Write("Enter side_1 (from 1 to 50) : ");
side_1 = ReadLine();
Write("Enter side_2 (from 1 to 50) : ");
side_2 = ReadLine();
Write("Enter place_x (from 1 to 50) : ");
place_x = ReadLine();
Figure F = new Rectangle{Side_1 = Int32.Parse(side_1), Place_X = Int32.Parse(place_x), Color = color, Side_2 = Int32.Parse(side_2)};
Col.AddFigure(F);
break;
	case "Rhom":
Write("Enter color (Red, Green, Blue) : ");
color = ReadLine();
Write("Enter side_1 (from 1 to 50) : ");
side_1 = ReadLine();
Write("Enter place_x (from 1 to 50) : ");
place_x = ReadLine();
Figure FR = new Rhombus{Side_1 = Int32.Parse(side_1), Place_X = Int32.Parse(place_x), Color = color};
Col.AddFigure(FR);
break;
	case "Tri":
Write("Enter color (Red, Green, Blue) : ");
color = ReadLine();
Write("Enter side_1 (from 1 to 50) : ");
side_1 = ReadLine();
Write("Enter place_x (from 1 to 50) : ");
place_x = ReadLine();
Figure FT = new Triangle{Side_1 = Int32.Parse(side_1), Place_X = Int32.Parse(place_x), Color = color};
Col.AddFigure(FT);
break;
	case "Pyr":
Write("Enter color (Red, Green, Blue) : ");
color = ReadLine();
Write("Enter side_1 (from 1 to 50) : ");
side_1 = ReadLine();
Write("Enter side_2 (from 1 to 50) : ");
side_2 = ReadLine();
Write("Enter place_x (from 1 to 50) : ");
place_x = ReadLine();
Figure FP = new Pyramid{Side_1 = Int32.Parse(side_1), Place_X = Int32.Parse(place_x), Color = color, Side_2 = Int32.Parse(side_2)};
Col.AddFigure(FP);
break;
	case "Multy":
Write("Enter color (Red, Green, Blue) : ");
color = ReadLine();
Write("Enter side_1 (from 1 to 50) : ");
side_1 = ReadLine();
Write("Enter side_2 (from 1 to 50) : ");
side_2 = ReadLine();
Write("Enter place_x (from 1 to 50) : ");
place_x = ReadLine();
Figure FM = new MultyAngle{Side_1 = Int32.Parse(side_1), Place_X = Int32.Parse(place_x), Color = color, Side_2 = Int32.Parse(side_2)};
Col.AddFigure(FM);
break;
}
break;
case "2":
Col.Show();
break;
case "3":
exit = "yes";
break;
}
}while(exit == "no");
}
}
}
