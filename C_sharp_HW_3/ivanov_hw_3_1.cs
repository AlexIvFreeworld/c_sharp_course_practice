using System;
using static System.Console;
namespace hw_3_1
{
    //task 5
    enum ArticleType
    {
        Fruit,
        Vegetables,
        Meat
    }
    // task 6
    enum ClientType
    {
        Vip,
        Middle,
        Low
    }
    //task 7
    enum PayType
    {
        Credit_card,
        Cash
    }
    //task 1
    struct Article
    {
        public int code_item;
        public string name_item;
        public double price_item;
        public ArticleType ArType;
    }
    // task 2
    struct Client
    {
        public int code_client;
        public string full_name_client;
        public string address_client;
        public string phone_client;
        public int amount_orders;
        public double sum_all_orders;
        public ClientType ClType;
    }
    // task 3
    struct RequestItem
    {
        public Article Art;
        public int amount_items;
    }
    // task 4
    struct Request
    {
        public int code_order;
        public Client Cl;
        public DateTime date_order;
        public RequestItem[] arrReq;
	public PayType PaTy;
        double sum_order;
        public double SumOrder
        {
            get { return sum_order; }
            set
            {
                sum_order = 0;
                foreach (RequestItem R in arrReq)
                {
                    sum_order += R.Art.price_item * R.amount_items;
                }

            }
        }
    }
    class Program
    {
        static public void Main()
        {
	    Article Apple = new Article();
	    Article Banana = new Article(); 
	    Apple.price_item = 20.20;
	    Banana.price_item = 30.30;
        RequestItem Req_1 = new RequestItem();
        RequestItem Req_2 = new RequestItem();
        Req_1.Art = Apple;
	    Req_1.amount_items = 100;
	    Req_2.Art = Banana;
	    Req_2.amount_items = 200;
	    Request R_1 = new Request();
	    R_1.arrReq = new RequestItem[]{Req_1, Req_2};
        R_1.SumOrder = 1;
	    WriteLine(R_1.SumOrder);
            R_1.PaTy = 0;
	    WriteLine(R_1.PaTy);
        }
    }
}
