using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_HealthyRoasters
{
    class Controller
    {
        DBConnect db = new DBConnect();
        public String[] dates = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public String[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public String[] adminBtn = { "Products", "Employees", "Sales Report", "Activity Log" };
        private string sc;
        private string pwd;
        private string vat;

        public void setPercentage()
        {
            db.connection.Open();
            MySqlDataReader cursor = db.getPercentage().ExecuteReader();
            while (cursor.Read())
            {
                sc = cursor[0].ToString();
                pwd = cursor[1].ToString();
                vat = cursor[2].ToString();
            }
            db.connection.Close();
        }

        public string getSC()
        {
            return sc;
        }

        public string getPWD()
        {
            return pwd;
        }

        public string getVAT()
        {
            return vat;
        }

        public void addDrinks()
        {
            db.getProducts("drinks");
        }

        public void addSalad()
        {
            db.getProducts("salad");
        }

        public string computeChange(string price, string amount)
        {
            double totalPrice = Convert.ToDouble(price);
            double totalAmount = Convert.ToDouble(amount);
            double totalChange = (totalPrice - totalAmount) * (-1);
            return String.Format("{0:0.00}", totalChange);
        }

        public string computePrice(string sPrice, string sQuantity)
        {
            double price = Convert.ToDouble(sPrice);
            double quantity = Convert.ToDouble(sQuantity);
            double totalPrice = price * quantity;
            return String.Format("{0:0.00}", totalPrice);
        }
        public string recordActivity(string username, string date, string time, string activity)
        {
            return username + " " + date + " " + time + " " + activity;
        }

        public ArrayList getSalad()
        {
            return db.getSaladMenu();
        }
        public ArrayList getSaladPrice()
        {
            return db.getSaladPrice();
        }
        public ArrayList getDrinks()
        {
            return db.getDrinksMenu();
        }
        public ArrayList getDrinksPrice()
        {
            return db.getDrinksPrice();
        }
    }
}
