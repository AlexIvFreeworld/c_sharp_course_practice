using System;
using System.Collections.Generic;
using static System.Console;
namespace Exam_2
{
class User{
public string Name {get; set;}
public string Login {get; set;}
public string Password {get; set;}
public DateTime DateBirth {get; set;}
public int CurrentResult {get; set;}
public int CurrentRating {get; set;}
public User(string name){
Name = name;
}
public void Show(){
WriteLine($"User {Name} your result : {CurrentResult} rating : {CurrentRating}");
}
}	
class Question{
public string Value{get; set;}
public List<string> arrAnswers;
public Question(string q){
Value = q;
arrAnswers = new List<string>();
}
public void Show(){
WriteLine($"Question : {Value}");
}
}
class KnowledgeSpace{
public string Type{get; set;}
public List<Question> arrQuestions;
public KnowledgeSpace(string t){
Type = t;
arrQuestions = new List<Question>();
}
}
class Quiz{
public List<KnowledgeSpace> arrSpaces;
public List<Question> arrCurrentQuestion;
public List<User> arrUsers;
public User CurrentUser = null;
public Quiz(){
arrSpaces = new List<KnowledgeSpace>();
arrCurrentQuestion = new List<Question>();
arrUsers = new List<User>();
}
public void ChoiceSpase(){

}
public void StartQuiz(){

}
public void ShowResult(){
CurrentUser.Show();
}
public void AddKnowledgeSpace(){

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

}
}
}
