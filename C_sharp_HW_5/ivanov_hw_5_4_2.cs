using System;
using static System.Console;
using MyClassLib;
namespace Day7
{
    class Program
    {
        static public void Main()
        {
            Tank T1 = new Tank(1);
            Tank T2 = new Tank(1);
            Tank T3 = new Tank(1);
            Tank T4 = new Tank(1);
            Tank T5 = new Tank(1);
            Tank P1 = new Tank(2);
            Tank P2 = new Tank(2);
            Tank P3 = new Tank(2);
            Tank P4 = new Tank(2);
            Tank P5 = new Tank(2);
	    Tank[] arrT = new Tank[]{T1,T2,T3,T4,T5};
	    Tank[] arrP = new Tank[] {P1,P2,T1,P4,P5};
	    bool win;
	    for(int i = 0; i < 5; i++){
	    arrT[i].Show();	    
	    arrP[i].Show();	    
	    try{
		    MyEx e = new MyEx();
		    if(arrT[i].GetName().ToCharArray()[0] == arrP[i].GetName().ToCharArray()[0]){
                    throw e;
		    }
            win = arrT[i]*arrP[i];
	    }
	    catch(MyEx e){
            WriteLine(e.Message);
	    }
	    WriteLine("--------------------------------------");
	    }
            /*T1.Show();
            T2.Show();
            T3.Show();
            P1.Show();
            P2.Show();
	    bool vin = T1*P1;
	    */
        }
    }
}
