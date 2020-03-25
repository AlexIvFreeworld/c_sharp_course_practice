using System;
using System.Collections.Generic;
using static System.Console;
namespace Exam_2
{
public delegate void Del();	
class User{
public string Name {get; set;}
public string Login {get; set;}
public string Password {get; set;}
public DateTime DateBirth {get; set;}
public int CurrentResult {get; set;}
public int CurrentRating {get; set;}
public List<string> arrResults;
public User(string name){
Name = name;
DateBirth = DateTime.Now;
arrResults = new List<string>();
}
public void Show(){
WriteLine($"User {Name} your result : {CurrentResult} rating : {CurrentRating}");
}
}	
class Question{
public string Value{get; set;}
public List<string> arrAnswers;
public string TrueIndexesAnswers;
public Question(string q){
Value = q;
arrAnswers = new List<string>();
}
public void Show(){
WriteLine($"Question : {Value}");
WriteLine("Variants answer : ");
int count = 1;
foreach(string str in arrAnswers){
WriteLine($"{count} - {str}");
count++;
}
}
public void FillQuestion(string trueAnswers, string[] arr){
TrueIndexesAnswers = trueAnswers;
arrAnswers.AddRange(arr); 

}	
public void ChangeQuestion(){

}	
}
class KnowledgeSpace{
public string Type{get; set;}
public List<Question> arrQuestions;
public KnowledgeSpace(string t){
Type = t;
arrQuestions = new List<Question>();
}
public void ShowAllQuestions(){
WriteLine($"KnowledgeSpace - {Type}");
int count = 1;
foreach(Question obj in arrQuestions){
WriteLine($"{count} - {obj.Value}");
count++;
}
}	
public void AddNewQuestion(Question obj){
arrQuestions.Add(obj);
}	
public Question SearchQuestion(int index){
for(int i = 0; i < arrQuestions.Count; i++){
if(i == index - 1) return arrQuestions[i];
}
return null;
}	
public void DeleteQuestion(Question obj){

}	
}
class Quiz{
public List<Del> arrDel;
public List<KnowledgeSpace> arrSpaces;
public List<Question> arrCurrentQuestion;
public List<User> arrUsers;
public User CurrentUser = null;
public Quiz(){
arrSpaces = new List<KnowledgeSpace>();
arrCurrentQuestion = new List<Question>();
arrUsers = new List<User>();
arrDel = new List<Del>(5);
arrDel.Add(ChoiceSpace);
arrDel.Add(ShowResult);
arrDel.Add(ShowTop20);
arrDel.Add(ChangeSetting);
arrDel.Add(Exit);
}
public bool AddorRegUser(){
string temp_log,temp_pass, temp_name, temp_birthday;
bool is_user = false;
bool result = false;
WriteLine("Enter your login");
temp_log = ReadLine();
foreach(User obj in arrUsers){
if(temp_log == obj.Login){
       	is_user = true;
	CurrentUser = obj;
}
}
if(is_user){
WriteLine("Enter your password");
temp_pass = ReadLine();
if(CurrentUser.Password == temp_pass){
WriteLine("You may to start quiz");
result = true;
}
else{
WriteLine("Your password isn't correct");
result = false;
}
}
else{
WriteLine("You need registration");
WriteLine("Enter your name");
temp_name = ReadLine();
WriteLine("Enter your birthday");
temp_birthday = ReadLine();
WriteLine("Enter your password");
temp_pass = ReadLine();
User U = new User(temp_name);
U.Login = temp_log;
U.DateBirth = DateTime.Now;//need to correct
U.Password = temp_pass;
arrUsers.Add(U);
foreach(User obj in arrUsers){
if(temp_log == obj.Login){
	CurrentUser = obj;
}
}
result = true;
}
return result;
}
public void Menu(){
WriteLine("---------------------------------------------------------------------");
WriteLine("Enter your choice :");
WriteLine("Choice knowledge space (0), Your last results (1), Top20 results (2)");
WriteLine("Change setting (3), Exit (4)");
WriteLine("---------------------------------------------------------------------");
int choice = Int32.Parse(ReadLine());
if(choice >= 0 && choice <= 4){
arrDel[choice]();
}
else{
WriteLine("Error enter");
Menu();
}
/*	arrDel[0]();
	arrDel[1]();
	arrDel[2]();
	arrDel[3]();
*/
}
public void Exit(){
WriteLine("Good buy!!!");
}
public void ChoiceSpace(){
WriteLine("This is ChoiceSpace()");
WriteLine("Choice knowledge space :");
WriteLine("Geography (1), History (2), Mix (3)");
arrCurrentQuestion.Clear();
string choice = ReadLine();
switch(choice){
	case "1":
arrCurrentQuestion.AddRange(arrSpaces[0].arrQuestions);
	break;
	case "2":
arrCurrentQuestion.AddRange(arrSpaces[1].arrQuestions);
	break;
	case "3":
	for(int i = 0; i < arrSpaces.Count; i++){
for(int j = 0; j < arrSpaces[i].arrQuestions.Count / arrSpaces.Count; j++){
arrCurrentQuestion.Add(arrSpaces[i].arrQuestions[j]);
}
	}
	break;
	default:
WriteLine("Error enter");
	break;
}
/*foreach(Question Q in arrCurrentQuestion){
Q.Show();
}
*/
// start quiz
string current_answer;
CurrentUser.CurrentResult = 0;
foreach(Question Q in arrCurrentQuestion){
Q.Show();
WriteLine("Enter your answer");
current_answer = ReadLine();
if(current_answer == Q.TrueIndexesAnswers){
WriteLine("Correctly!");
CurrentUser.CurrentResult++;
}
else{
WriteLine("Incorrectly!");
}
}
CurrentUser.arrResults.Add($"Result quiz by {DateTime.Now} : {CurrentUser.CurrentResult}, Raiting : {CurrentUser.CurrentRating}"); 
// 
//
//
//
//
// end quiz
Menu();
}
public void StartQuiz(){

}
public void ShowResult(){// need show history results
WriteLine("This is ShowResult()");
	if(CurrentUser != null){
foreach(string str in CurrentUser.arrResults){
WriteLine(str);
}
	}
	else{
WriteLine("Current user isn't exist");
	}
	Menu();
}
public void ShowTop20(){
WriteLine("This is ShowResult()");
	Menu();
}
public void ChangeSetting(){
WriteLine("This is ChangeSetting()");
	Menu();
}
public void AddKnowledgeSpace(KnowledgeSpace K){
arrSpaces.Add(K);
}
public void ChangeQuestion(){

}
public void AddQuestion(){

}
public void DeleteQuestion(){

}

}
class Program
{
public static void Main()
{
Question Q_1 = new Question("What is the capital of Russia?");
Q_1.FillQuestion("1", new string[] {"Moscow", "London", "Berlin"});
Question Q_2 = new Question("What is the capital of USA?");
Q_2.FillQuestion("2", new string[] {"Moscow", "Washington", "Berlin"});
Question Q_3 = new Question("Which river is in the Russia?");
Q_3.FillQuestion("12", new string[] {"Volga", "Oka", "Nile"});
Question Q_4 = new Question("Which town is in the Russia?");
Q_4.FillQuestion("123", new string[] {"Moscow", "Tomsk", "Saratov"});
//Q_1.Show();
KnowledgeSpace K_1 = new KnowledgeSpace("Geography");
K_1.AddNewQuestion(Q_1);
K_1.AddNewQuestion(Q_2);
K_1.AddNewQuestion(Q_3);
K_1.AddNewQuestion(Q_4);
//K_1.ShowAllQuestions();
//K_1.SearchQuestion(1).Show();
Question QH_1 = new Question("When started the Great Patriotic War?");
QH_1.FillQuestion("1", new string[] {"1941", "1917", "1905"});
Question QH_2 = new Question("When finished the Great Patriotic War?");
QH_2.FillQuestion("2", new string[] {"1939", "1945", "1957"});
Question QH_3 = new Question("Which country consisted in the USSR?");
QH_3.FillQuestion("12", new string[] {"Ukraine", "Georgia", "Poland"});
Question QH_4 = new Question("When USSR was destroyed?");
QH_4.FillQuestion("3", new string[] {"1957", "1945", "1991"});
//QH_1.Show();
KnowledgeSpace K_2 = new KnowledgeSpace("Geography");
K_2.AddNewQuestion(QH_1);
K_2.AddNewQuestion(QH_2);
K_2.AddNewQuestion(QH_3);
K_2.AddNewQuestion(QH_4);
Quiz QZ = new Quiz();
QZ.AddKnowledgeSpace(K_1);
QZ.AddKnowledgeSpace(K_2);
QZ.arrUsers.Add(new User("Alex") {
	Login = "123",
	Password = "123",
		}); 
WriteLine("Checking user before registration");
foreach(User U in QZ.arrUsers){
U.Show();
}	
bool is_reg = QZ.AddorRegUser();
if(!is_reg) {
QZ.Exit();
return;
}
WriteLine("Checking user after registration");
foreach(User U in QZ.arrUsers){
U.Show();
}	
QZ.Menu();
//WriteLine("Result this quiz");
//QZ.ShowResult();
/*WriteLine("This menu");
QZ.Menu();
*/
}
}
}
