using System;
using System.Collections.Generic;
using  static System.Console;
namespace Exam_1
{
class Word {
public string Value{get; set;}
public List<string> arrTranslate;
public Word(){
arrTranslate = new List<string>();
}
public void AddTranslate(string trans){
arrTranslate.Add(trans);
}
public void Show(){
Write($"{Value} - ");
foreach(string str in arrTranslate) Write($"{str} ");
WriteLine();
}
public void ChangeWord(string newword){
Value = newword;
}
public void ChangeTranslate(string trans, string newtrans){
for(int i = 0; i < arrTranslate.Count; i++){
if(arrTranslate[i] != null){
   if(arrTranslate[i] == trans) {
   arrTranslate[i] = newtrans;
   return;
   }
}	
}
WriteLine($"New interpretation {newtrans}");
arrTranslate.Add(newtrans);
}
public void WriteInFile(){

}
}
class Dictionary {
public string Dtype{get; set;} 
public List<Word> arrWords;
public Dictionary(string type){
Dtype = type;
arrWords = new List<Word>();
}
public void AddWord(string word, string translate){
	WriteLine($"Count words : {arrWords.Count}");
	for(int i = 0; i < arrWords.Count; i++){
//	WriteLine($"Current word {arrWords[i]?.Value}");
if(arrWords[i] != null){
   if(arrWords[i].Value == word) {
   arrWords[i].arrTranslate.Add(translate);
   return;
   }
}	
}
WriteLine($"New word {word}");
Word W = new Word();
W.Value = word;
W.arrTranslate.Add(translate);
arrWords.Add(W);
}
public void DeleteWord(string word){
for(int i = 0; i < arrWords.Count; i++){
if(arrWords[i].Value == word) //here
}
}

public void ChangeWordorTranslate(string word, string newword, int pos, string newtranslate){

}
public void DeleteWordorTranslate(string word, int pos){

}
public Word SearchTranslate(string word){
for(int i = 0; i < arrWords.Count; i++){
//arrWords[i].Show();
if(arrWords[i].Value == word) {
return arrWords[i];
}
}
return null;
}
public void Show(){
foreach(Word word in arrWords){
word.Show();
}
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
public Dictionary SearchDictionary(string type){
for(int i = 0; i < arrDictionary.Count; i++){
if(arrDictionary[i].Dtype == type) {
return arrDictionary[i];
}
}
return null;
}
}
class Program {
public static void Main(){
Library L = new Library();
	//upload bd from file
L.AddDictionary("en-ru");	
L.AddDictionary("ru-en");	
L.arrDictionary[0].AddWord("bread", "хлеб");
L.arrDictionary[0].AddWord("meat", "мясо");
L.arrDictionary[0].AddWord("water", "вода");
L.arrDictionary[0].Show();
L.arrDictionary[0].SearchTranslate("water").ChangeTranslate("вода","река");
L.arrDictionary[0].SearchTranslate("bread").ChangeTranslate("","батон");
L.arrDictionary[0].Show();
WriteLine("----------------------------");
WriteLine(L.arrDictionary[0].Dtype);
WriteLine("----------------------------");
//WriteLine(L.arrDictionary[0].arrWords[0].Value);
WriteLine("----------------------------");
string choice = "";
bool is_work = true;
string typeD, word, new_word, inter, new_inter;  
do{
WriteLine("Enter any choice : Add dictionary (1), Add word (2), Search (3)"); 
WriteLine("Change word (4), Change/add interpretation (5), Delete word (6), Print (6), exit (7)"); 
choice = ReadLine();
switch(choice){
	case "1":
		WriteLine("Enter type new dictionary");
		typeD = ReadLine();
                L.AddDictionary(typeD);
	break;
	case "2":
		WriteLine("Enter type dictionary");
		typeD = ReadLine();
                Dictionary D = L.SearchDictionary(typeD); 
		if(D != null) WriteLine($"Found dictionary {D.Dtype}");
		else WriteLine("Dictionary wasn't found");
		WriteLine("Enter needed word");
		word = ReadLine();
		WriteLine("Enter needed interpretation");
		inter = ReadLine();
		D.AddWord(word, inter);
	break;
	case "3":
		WriteLine("Enter type dictionary");
		typeD = ReadLine();
                Dictionary D1 = L.SearchDictionary(typeD); 
		if(D1 != null) WriteLine($"Found dictionary {D1.Dtype}");
		else WriteLine("Dictionary wasn't found");
		WriteLine("Enter needed word");
		word = ReadLine();
		if(D1.SearchTranslate(word) != null) D1.SearchTranslate(word).Show();
		else WriteLine("Word wasn't found");
	break;
	case "4":
		WriteLine("Enter type dictionary");
		typeD = ReadLine();
                Dictionary D2 = L.SearchDictionary(typeD); 
		if(D2 != null) WriteLine($"Found dictionary {D2.Dtype}");
		else WriteLine("Dictionary wasn't found");
		WriteLine("Enter needed word");
		word = ReadLine();
		if(D2.SearchTranslate(word) != null) D2.SearchTranslate(word).Show();
		else WriteLine("Word wasn't found");
		WriteLine("Enter new word");
		new_word = ReadLine();
		D2.SearchTranslate(word).ChangeWord(new_word);
		D2.Show();
	break;
	case "5":
		WriteLine("Enter type dictionary");
		typeD = ReadLine();
                Dictionary D3 = L.SearchDictionary(typeD); 
		if(D3 != null) WriteLine($"Found dictionary {D3.Dtype}");
		else WriteLine("Dictionary wasn't found");
		WriteLine("Enter needed word");
		word = ReadLine();
		if(D3.SearchTranslate(word) != null) D3.SearchTranslate(word).Show();
		else WriteLine("Word wasn't found");
		WriteLine("Enter interpretation");
		inter = ReadLine();
		WriteLine("Enter new interpretation");
		new_inter = ReadLine();
		D3.SearchTranslate(word).ChangeTranslate(inter, new_interChangeTranslate(inter, new_inter)ak;
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
//WriteLine(L.arrDictionary[0].Dtype);
}
}
}

