using System;
using static System.Console;
namespace hw_4_2
{
    abstract class Item
    {
        public virtual string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public int Sell { get; set; }
        public int Selling { get; set; }
        public int Out { get; set; }
        public virtual void Show()
        {
            WriteLine("Price : {0}\nAmount : {1}", this.Price, this.Amount);
            WriteLine("InSell : {0}\nInSelling : {1}\nInOut : {2}", this.Sell, this.Selling, this.Out);
        }
    }
    abstract class HouseChem : Item
    {
        public string Group
        {
            get { return "Household chemicals"; }
        }
        public override void Show()
        {
            WriteLine("Group : {0} ", this.Group);
            base.Show();
        }
    }
    class Tide : HouseChem
    {
        public override string Name
        {
            get { return "Tide"; }
        }
        public override void Show()
        {
            WriteLine("Name : {0} ", this.Name);
            base.Show();
        }
    }
    abstract class Food : Item
    {
        public string Group
        {
            get { return "Food products"; }
        }
        public override void Show()
        {
            WriteLine("Group : {0} ", this.Group);
            base.Show();
        }
    }
    class Lays : Food
    {
        public override string Name
        {
            get { return "Lays"; }
        }
        public override void Show()
        {
            WriteLine("Name : {0} ", this.Name);
            base.Show();
        }
    }
    class Stack
    {
        private Item[] Store;
        public Stack(params Item[] arr)
        {
            int i = 0;
            Store = new Item[arr.Length];
            arr.CopyTo(Store, 0);
        }
        public void addNewItem(Item It)
        {
            foreach (Item storeIt in Store)
            {
                if (storeIt.Name == It.Name)
                {
                    WriteLine("Thie item already exists in the store");
                    return;
                }
            }
            int size = Store.Length;
            Array.Resize(ref Store, size + 1);
            Store[size] = It;
        }
        public void Show()
        {
            foreach (Item It in Store)
            {
                It.Show();
            }
        }
        public void InSell(string name, int amount)
        {
            foreach (Item It in Store)
            {
                if (It.Name == name && It.Amount >= amount)
                {
                    It.Amount -= amount;
                    It.Sell += amount;
                }
                else
                {
                    WriteLine("This item isn't exist in Store or its amount isn't enough");
                }
            }
        }
        public void InSelling(string name, int amount)
        {
            foreach (Item It in Store)
            {
                if (It.Name == name && It.Amount >= amount)
                {
                    It.Amount -= amount;
                    It.Selling += amount;
                }
                else
                {
                    WriteLine("This item isn't exist in Store or its amount isn't enough");
                }
            }
        }
        public void InOut(string name, int amount)
        {
            foreach (Item It in Store)
            {
                if (It.Name == name && It.Amount >= amount)
                {
                    It.Amount -= amount;
                    It.Out += amount;
                }
                else
                {
                    WriteLine("This item isn't exist in Store or its amount isn't enough");
                }
            }
        }
        public void InStore(string name, int amount)
        {
            foreach (Item It in Store)
            {
                if (It.Name == name)
                {
                    It.Amount += amount;
                }
                else
                {
                    WriteLine("This item isn't exist in Store");
                }
            }
        }
        class Program
        {
            static void Main()
            {
                // Tide T = new Tide();
                // T.Price = 30.50;
                // T.Amount = 100;
                //  T.Show();
                Item T_1 = new Tide();
                T_1.Price = 10.50;
                T_1.Amount = 50;
                Item T_2 = new Tide();
                T_2.Price = 20.50;
                T_2.Amount = 75;
                Item T_3 = new Lays();
                T_3.Price = 30.00;
                T_3.Amount = 1000;
                Stack St = new Stack(T_1, T_3);
                St.Show();
                St.addNewItem(T_2);
                St.Show();
                St.InSell("Tide", 20);
                St.Show();
                St.InSelling("Tide", 5);
                St.Show();
                St.InOut("Tide", 10);
                St.Show();
                St.InStore("Tide", 200);
                St.Show();

            }
        }
    }
}
