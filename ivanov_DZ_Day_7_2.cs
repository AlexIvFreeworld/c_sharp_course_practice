using System;
using static System.Console;
using System.Collections.Generic;
using Test_Log;
namespace DZ_Day_6
{
    class Card
    {
        public Card(string color, int weight)
        {
            Color = color;
            Weight = weight;
            if (weight >= 6 && weight <= 10)
            {
                Type = weight.ToString();
            }
            else if (weight == 11) Type = "jack";
            else if (weight == 12) Type = "dame";
            else if (weight == 13) Type = "king";
            else if (weight == 14) Type = "ace";
            else WriteLine("This type isn't exist");
        }
        string Color;
        string Type;
        public int Weight;
        public override string ToString()
        {
            return $"[{Color} : {Type}]";
        }
        public static bool operator >=(Card C1, Card C2)
        {
            if (C1.Type == "6" && C2.Type == "ace") return true;
            else if (C1.Weight >= C2.Weight) return true;
            else return false;
        }
        public static bool operator <=(Card C1, Card C2)
        {
            if (C1.Type == "ace" && C2.Type == "6") return true;
            else if (C1.Weight <= C2.Weight) return true;
            else return false;
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
    class Player
    {
        public string Name;
        public Queue<Card> arrCard;
        public Player(string name)
        {
            Name = name;
            arrCard = new Queue<Card>();
        }
        public void Show()
        {
            WriteLine($"-------------{Name}------------------");
            foreach (object obj in arrCard)
            {
                WriteLine($"{obj}");
            }
            WriteLine("--------------------------------------");
        }

    }
    class Game
    {
        public List<Card> arrCard;
        public Game()
        {
            arrCard = new List<Card>(36);
            for (int i = 0; i < 4; i++)
            {
                string type = "";
                switch (i)
                {
                    case 0:
                        type = "heart";
                        break;
                    case 1:
                        type = "diamonds";
                        break;
                    case 2:
                        type = "clubs";
                        break;
                    case 3:
                        type = "spades";
                        break;
                    default:
                        WriteLine("This type isn't exist");
                        break;
                }
                for (int j = 6; j <= 14; j++)
                {
                    Card C = new Card(type, j);
                    arrCard.Add(C);
                }
            }
        }
        public void Show()
        {
            WriteLine("------------------");
            foreach (object obj in arrCard)
            {
                WriteLine($"{obj}");
            }
            WriteLine("------------------");
        }
        public void Shuffle()
        {
            Random R = new Random();
            int start, end;
            for (int i = 0; i < 100; i++)
            {
                start = R.Next(0, 35);
                end = R.Next(0, 35);
                Card Temp = arrCard[start];
                arrCard[start] = arrCard[end];
                arrCard[end] = Temp;
            }
        }
    }
    class Program
    {
        public static void Main()
        {
	    Loger LG = new Loger();	
            Game G = new Game();
            G.Shuffle();
            G.Show();
            Player Alex = new Player("Alex");
	    //testing Loger
	    LG.Date.ToLocalTime();
	    LG.TypeMessage = "info";
	    LG.UserName = "Alex";
	    LG.Message = "Creating Player Alex";
	    LG.WriteToFile();
	    WriteLine($"LG.TypeMessage : {LG.TypeMessage}");
	    WriteLine($"LG.arrStr[1] : {LG.arrStr[1]}");
            Player Igor = new Player("Igor");
            for (int i = 0; i < 36; i++)
            {
                if (i % 2 != 0 || i == 1) Alex.arrCard.Enqueue(G.arrCard[i]);
                else Igor.arrCard.Enqueue(G.arrCard[i]);
            }
            Alex.Show();
            Igor.Show();
            bool is_end = false;
            int count = 0;
            bool is_Alex = true;
            do
            {
                if (is_Alex)
                {
                    if (Alex.arrCard.Peek() >= Igor.arrCard.Peek())
                    {
                        Alex.arrCard.Enqueue(Alex.arrCard.Peek());
                        Alex.arrCard.Enqueue(Igor.arrCard.Peek());
                        Alex.arrCard.Dequeue();
                        Igor.arrCard.Dequeue();
                        is_Alex = true;
                    }
                    else
                    {
                        Igor.arrCard.Enqueue(Igor.arrCard.Peek());
                        Igor.arrCard.Enqueue(Alex.arrCard.Peek());
                        Alex.arrCard.Dequeue();
                        Igor.arrCard.Dequeue();
                        is_Alex = false;
                    }
                }
                else
                {
                    if (Igor.arrCard.Peek() >= Alex.arrCard.Peek())
                    {
                        Igor.arrCard.Enqueue(Igor.arrCard.Peek());
                        Igor.arrCard.Enqueue(Alex.arrCard.Peek());
                        Alex.arrCard.Dequeue();
                        Igor.arrCard.Dequeue();
                        is_Alex = false;
                    }
                    else
                    {
                        Alex.arrCard.Enqueue(Alex.arrCard.Peek());
                        Alex.arrCard.Enqueue(Igor.arrCard.Peek());
                        Alex.arrCard.Dequeue();
                        Igor.arrCard.Dequeue();
                        is_Alex = true;
                    }
                }
                //	WriteLine($"Alex card count : {Alex.arrCard.Count}");
                count++;
                if (Alex.arrCard.Count == 0 || Igor.arrCard.Count == 0 || count == 2000) is_end = true;
            } while (!is_end);
            if (Alex.arrCard.Count > Igor.arrCard.Count)
                WriteLine($"The player {Alex.Name} won!!!");
            else
                WriteLine($"The player {Igor.Name} won!!!");
            Alex.Show();
            Igor.Show();
        }
    }
}
