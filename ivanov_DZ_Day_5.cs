using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;
namespace DZ_Day_5
{
    public delegate void DelFinish(string s, int i);
    public delegate void DelStart();
    public delegate void DelCurrentPosition();
    abstract class Car
    {
        abstract public event DelFinish EventFinish;
        public string Model;
        public int Speed { get; set; }
        public int Distance { get; set; }
        abstract public void Go();
        public void ShowDistance()
        {
            WriteLine($"Model : {Model} Distance : {Distance}");
        }
	public int GetDistance(){
        return Distance;
	}
    }
    class SportCar : Car
    {
        public override event DelFinish EventFinish;
        public SportCar()
        {
            Model = "SportCar";
            Distance = 0;
        }

        public override void Go()
        {
            Random R = new Random();
            Speed = R.Next(70, 320);
	    WriteLine($"{Model}  Speed  : {Speed}");
            Distance += Speed / 6;
            if (Distance >= 100)
            {
                EventFinish(Model, Distance);
            }
	    Thread.Sleep(20);
        }
    }
    class PassengerCar : Car
    {
        public override event DelFinish EventFinish;
        public PassengerCar()
        {
            Model = "PassengerCar";
            Distance = 0;
        }
        public override void Go()
        {
            Random R = new Random();
            Speed = R.Next(70, 140);
	    WriteLine($"{Model}  Speed  : {Speed}");
            Distance += Speed / 6;
            if (Distance >= 100)
            {
                EventFinish(Model, Distance);
            }
	    Thread.Sleep(20);
        }
    }
    class Bus : Car
    {
        public override event DelFinish EventFinish;
        public Bus()
        {
            Model = "Bus";
            Distance = 0;
        }
        public override void Go()
        {
            Random R = new Random();
            Speed = R.Next(70, 120);
	    WriteLine($"{Model}  Speed  : {Speed}");
            Distance += Speed / 6;
            if (Distance >= 100)
            {
                EventFinish(Model, Distance);
            }
	    Thread.Sleep(20);
        }
    }
    class Truck : Car
    {
        public override event DelFinish EventFinish;
        public Truck()
        {
            Model = "Truck";
            Distance = 0;
        }
        public override void Go()
        {
            Random R = new Random();
            Speed = R.Next(70, 110);
	    WriteLine($"{Model}  Speed  : {Speed}");
            Distance += Speed / 6;
            if (Distance >= 100)
            {
                EventFinish(Model, Distance);
            }
	    Thread.Sleep(20);
        }
    }
    class Game{
     public List<Car> arrCars;
     string WinModel;
     int WinDistance;
     bool exist_winner;
      public Game(){
     arrCars = new List<Car>();
     exist_winner = false;
      } 
    public event DelStart EventStart;  
    public event DelCurrentPosition EventPosition;  
    public void AddCar(Car C){
//	    EventStart += Car.Go;
    arrCars.Add(C);
    }
    public void StartGame(){
     EventStart();
    }
    public void ShowCurrentPosition(){
    EventPosition();
    }
    public void ShowWinner(){
	    WriteLine();
	    WriteLine($"Vinner : {WinModel} with distance : {WinDistance}");
			    }
    public void GetWinner(string model, int dist){
    if(exist_winner == false){
    WinModel = model;
    WinDistance = dist;
    exist_winner = true;
    }
    }
    }
    class Program
    {
        public static bool is_finish;
        public static void Main()
        {
	Game G = new Game();	
	Car S_2 = new SportCar();
	Car S_3 = new PassengerCar();
	Car S_4 = new Bus();
	Car S_5 = new Truck();
	G.AddCar(S_2);
	G.AddCar(S_3);
	G.AddCar(S_4);
	G.AddCar(S_5);
	for(int i = 0; i < G.arrCars.Count; i++){
        G.EventStart += G.arrCars[i].Go;
	G.EventPosition += G.arrCars[i].ShowDistance; 
	G.arrCars[i].EventFinish += ShowFinish;
	G.arrCars[i].EventFinish += G.GetWinner;
	}	
	    is_finish = false;	 
	    do {
		WriteLine("----------------------------------------");
		G.StartGame();
		WriteLine("----------------------------------------");
		G.ShowCurrentPosition();
	    }while(!is_finish);

	G.ShowWinner();
        }
        public static void ShowFinish(string s, int i)
        {
            is_finish = true;		
            WriteLine($"The {s} Finish with distance {i} !!!");
        }
    }
}
