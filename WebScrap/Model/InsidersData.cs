using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebScrap.Model
{
    internal class InsidersData
    {

        DateTime tradedate;
        string insiderName;
        string title;
        string tradetype;
        double price;
        double value;



        public DateTime Tradedate { get => tradedate; set => tradedate = value; }
        public string InsiderName { get => insiderName; set => insiderName = value; }
        public string Title { get => title; set => title = value; }
        public string Tradetype { get => tradetype; set => tradetype = value; }
        public double Price { get => price; set => price = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
