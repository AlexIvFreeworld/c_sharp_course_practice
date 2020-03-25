using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace Test_Log {
public class Loger {
public Loger(){
string path = "ini.txt";
string str;
using (FileStream fs = new FileStream(path, FileMode.Open)){
      using (StreamReader sr = new StreamReader(fs, Encoding.Unicode)) {
//Console.WriteLine($"Coding of stream file ini : {sr.CurrentEncoding}");
//Console.WriteLine($"Is end of stream file ini : {sr.EndOfStream}");
str = sr.ReadToEnd();
//Console.WriteLine($"Length of string  from file ini : {str.Length}");
//Console.WriteLine($"Is end of stream file ini : {sr.EndOfStream}");
      }
}
//Console.WriteLine($"This string from file ini : {str}");
for(int i = 0; i < str.Length - 1; i++){
if(Int32.Parse(str[i].ToString()) < 0 || Int32.Parse(str[i].ToString()) > 3){
str = "01234";
break;
}
}
char[] arrCh = str.ToCharArray();	
i_Date = Int32.Parse(str[0].ToString());
i_TypeMessage = Int32.Parse(str[1].ToString());
i_UserName = Int32.Parse(str[2].ToString());
i_Message = Int32.Parse(str[3].ToString());
//Console.WriteLine($"Indexes : {i_Date} | {i_TypeMessage} | {i_UserName} | {i_Message}");
Amount = Int32.Parse(str[4].ToString());
arrStr = new string[4];
//Console.WriteLine($"This arrStr.Length : {arrStr.Length}");
//arrStr[i_Date] = Date.ToString();
//arrStr[i_TypeMessage] = TypeMessage;
//arrStr[i_UserName] = UserName;
//arrStr[i_Message] = Message;
}	
private DateTime _date; 
public DateTime Date{
	get{return _date;}
       	set{arrStr[i_Date] = value.ToString();
	_date = value;
	}
}
private string _type_message;
public string TypeMessage{
	get{return _type_message;}
       	set{arrStr[i_TypeMessage] = value;
	_type_message = value;
}
}
private string _user_name;
public string UserName{
	get{return _user_name;}
       	set{arrStr[i_UserName] = value;
	_user_name = value;
}
}
private string _message;
public string Message{
	get{return _message;}
       	set{arrStr[i_Message] = value;
	_message = value;
}
}
public string[] arrStr;
public int Amount;
public int i_Date;
public int i_TypeMessage;
public int i_UserName;
public int i_Message;
public void WriteToFile(){
string path = "log.txt";
using (FileStream fs = new FileStream(path, FileMode.Append)){
      using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode)) {
	      for(int i = 0; i < Amount; i++){
	      sw.Write($"{arrStr[i]} | ");
	      }
	      sw.WriteLine();
      }
}
}
}
}
