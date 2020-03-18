using System;
using System.Collections.Generic;
using  static System.Console;
namespace Exam_1
{
class Word {
public string Value{get; set;}
public List<string> arrTranslate;
public void AddTranslate(string word){
arrTranslate = new List<string>();
arrTranslate.Add(word);
}
public void Show(){

}
public void WriteInFile(){

}
}
class Dictionary {
public string Type{get; set;} 
public List<Word> arrWords;
public Dictionary(string type){
Type = type;
arrWords = new List<Word>();
}
public void ChangeWordorTranslate(string word, string newword, int pos, string newtranslate){

}
public void DeleteWordorTranslate(string word, int pos){

}
public void SearchTranslate(string word){

}
}
class Library{
public List<Dictionary> arrDictionary;
public Library(){
arrDictionary = new List<Dictionary>();
}
public void AddDictionary(string type){
Dictionary D = new Dictionary(type);	
arrDictionary.Add(D);
}
}
class Program {
public static void Main(){
string choice = "";
bool is_work = true;
Library L = new Library();
string typeD;  
do{
WriteLine("Enter any choice : Add dictionary (1), Add word (2), Search (3)"); 
WriteLine("Change (4), Delete (5), Print (6), exit (7)"); 
choice = ReadLine();
switch(choice){
	case "1":
		WriteLine("Enter type new dictionary");
		typeD = ReadLine();
                L.AddDictionary(typeD);
	break;
	case "2":
	break;
	case "3":
	break;
	case "4":
	break;
	case "5":
	break;
	case "6":
	break;
	case "7":
	is_work = false;
	break;
	default :
	WriteLine("Incorrect choice");
	break;
}
}while(is_work);
WriteLine(L.arrDictionary[0].Type);
}
}
}

