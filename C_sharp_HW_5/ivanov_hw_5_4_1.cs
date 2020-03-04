using System;
using System.Threading;
using static System.Console;
namespace MyClassLib
{
    class Tank
    {
        string Name;
        int Ammunition;
        int Armor;
        int Mobility;
        static int CountT34;
        static int CountPantera;
        public Tank(int n)
        {
            if (n == 1)
            {
                CountT34++;
                Name = $"T34_{CountT34}";
            }
            else
            {
                CountPantera++;
                Name = $"Pantera_{CountPantera}";
            }
            Random R = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            Ammunition = R.Next(100);
            Armor = R.Next(100);
            Mobility = R.Next(100);
            Thread.Sleep(20);
        }
        public void Show()
        {
            WriteLine($"Name : {Name}, Ammunition : {Ammunition}, Armor : {Armor}, Mobility : {Mobility}");
        }
        public string GetName()
        {
            return Name;
        }
	static public bool operator * (Tank t1, Tank t2){
        int res = 0;
	if(t1.Ammunition > t2.Ammunition) res++;
	if(t1.Armor > t2.Armor) res++;
	if(t1.Mobility > t2.Mobility) res++;
	if(res >= 2) WriteLine("This tank {0} von!!", t1.GetName()); 
	else WriteLine("This tank {0} von!!", t2.GetName());
	return true;
	}
    }
    class MyEx : System.Exception {
    public override string Message {
    get {
    return $"ERROR: these tanks are same side!";
    }
    }
    }
}
