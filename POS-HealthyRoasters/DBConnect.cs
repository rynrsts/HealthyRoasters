using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_HealthyRoasters
{
    class DBConnect
    {
        public MySqlConnection connection;
        private ArrayList saladMenu = new ArrayList();
        private ArrayList saladPrice = new ArrayList();
        private ArrayList drinksMenu = new ArrayList();
        private ArrayList drinksPrice = new ArrayList();

        public DBConnect()
        {
            Initialize();
        }
        private void Initialize()
        {
            connection = new MySqlConnection("Server=localhost;Database=healthyroasters;Uid=root;Pwd=;");
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public string checkSession(string username)
        {
            string confirmation = "fail";
            if (OpenConnection() == true)
            {
                string query = "SELECT b.firstname,b.lastname FROM tbl_account_credentials " +
                    "AS a INNER JOIN tbl_user_information AS b ON a.user_id = b.user_id AND " +
                    "a.username='" + username + "' AND a.status='active'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 1)
                {
                    DataRow row = dt.Rows[0];
                    confirmation = row["firstname"].ToString() + " " + row["lastname"].ToString();
                }
                connection.Close();
            }
            return confirmation;
        }

        public string validateManager(string username)
        {
            string confirmation = "fail";
            if (OpenConnection() == true)
            {
                string query = "SELECT b.firstname,b.lastname FROM tbl_account_credentials " +
                    "AS a INNER JOIN tbl_user_information AS b ON a.user_id = b.user_id AND " +
                    "a.username='" + username + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 1)
                {
                    DataRow row = dt.Rows[0];
                    confirmation = row["firstname"].ToString() + " " + row["lastname"].ToString();
                }
                connection.Close();
            }
            return confirmation;
        }

        public bool endSession(string username)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_account_credentials WHERE username='" + username + "' AND status='active'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 1)
                {
                    query = "UPDATE tbl_account_credentials SET status='inactive' WHERE username='" + username + "'";
                    cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    validity = true;
                }
                connection.Close();
            }
            return validity;
        }

        int i;
        public string checkLogin(string username, string password)
        {
            string dec = "";
            int i = 0;
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_account_credentials WHERE username='" + username + "' AND password='" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 1)
                {
                    DataRow row = dt.Rows[0];
                    dec = row["usertype"].ToString();
                    if (row["status"].ToString() == "inactive")
                    {
                        query = "UPDATE tbl_account_credentials SET status='active' WHERE user_id=" + Convert.ToInt32(row["user_id"]);
                        cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
            else
            {
                dec = "error";
            }
            return dec;
        }
        public string checkUsername(string username)
        {
            string validity = "";
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_account_credentials WHERE username='" + username + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 1)
                {
                    validity = "existed";
                }
                connection.Close();
            }
            else
            {
                validity = "error";
            }
            return validity;
        }

        public string checkEmail(string email)
        {
            string validity = "";
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_user_information WHERE email='" + email + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 1)
                {
                    validity = "existed";
                }
                connection.Close();
            }
            else
            {
                validity = "error";
            }
            return validity;
        }

        public DataTable viewProducts()
        {
            DataTable dt = new DataTable();
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_products";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }

        public bool checkStock(string prodName)
        {
            int count = 0;
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "SELECT COUNT(*) FROM tbl_products WHERE status='out-of-stock' AND product_name='" + prodName + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar().ToString());
                if (count == 1)
                {
                    validity = true;
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return validity;
        }

        public void getProducts(string type)
        {
            connection.Open();
            string query = "SELECT product_name,product_price FROM tbl_products WHERE item_type='" + type + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader cursor = cmd.ExecuteReader();
            while (cursor.Read())
            {
                if (type == "salad")
                {
                    saladMenu.Add(cursor["product_name"].ToString());
                    saladPrice.Add(cursor["product_price"].ToString());
                }
                else if (type == "drinks")
                {
                    drinksMenu.Add(cursor["product_name"].ToString());
                    drinksPrice.Add(cursor["product_price"].ToString());
                }

            }
            connection.Close();
        }

        public ArrayList getSaladMenu()
        {
            return saladMenu;
        }

        public ArrayList getSaladPrice()
        {
            return saladPrice;
        }

        public ArrayList getDrinksMenu()
        {
            return drinksMenu;
        }

        public ArrayList getDrinksPrice()
        {
            return drinksPrice;
        }

        public bool checkProduct(string prodId, string prodName)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_products WHERE product_id='" + prodId + "' OR product_name='" + prodName + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i >= 1)
                {
                    validity = true;
                }
                connection.Close();
            }
            else
            {
                validity = false;
            }
            return validity;
        }

        public bool createProduct(string id, string name, string price, string type, string status)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "INSERT INTO tbl_products (product_id,product_name,product_price,item_type,status) VALUES ('" + id + "','" + name + "','" + price + "','" + type + "','" + status + "')";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return validity;
        }

        public bool editProduct(string id, string prodName, string prodPrice, string type, string status)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "UPDATE tbl_products SET product_name='" + prodName + "',product_price='" + prodPrice + "',item_type='" + type + "', " +
                    "status='" + status + "' WHERE product_id='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            return validity;
        }

        public bool deleteProduct(string id)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "DELETE FROM tbl_products WHERE product_id='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return validity;
        }

        public DataTable viewEmployees()
        {
            DataTable dt = new DataTable();
            if (OpenConnection() == true)
            {
                string query = "SELECT a.user_id,a.username,a.password,a.usertype,b.firstname,b.middlename,b.lastname,b.gender,b.mobile_no," +
                "b.tel_no,b.email,b.address,b.birthday,a.status FROM tbl_account_credentials " +
                "AS a INNER JOIN tbl_user_information AS b ON a.user_id = b.user_id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }

        public bool registerEmployee(string username, string password, string usertype, string firstname, string middlename,
            string lastname, string gender, string mobile, string tele, string email, string address, string bday)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                StringBuilder query = new StringBuilder();
                query.Append("INSERT INTO tbl_account_credentials (username,password,usertype,status) VALUES (" +
                    "'" + username + "','" + password + "','" + usertype + "','inactive')");
                MySqlCommand cmd = new MySqlCommand(query.ToString(), connection);
                cmd.ExecuteNonQuery();
                query.Clear();
                query.Append("INSERT INTO tbl_user_information (firstname,middlename,lastname,gender,mobile_no" +
                    ",tel_no,email,address,birthday) VALUES ('" + firstname + "','" + middlename + "','" + lastname + "','" + gender + "'," +
                    "'" + mobile + "','" + tele + "','" + email + "','" + address + "','" + bday + "')");
                cmd = new MySqlCommand(query.ToString(), connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return validity;
        }

        public bool deleteEmployee(string id)
        {
            bool validity = false;
            int uid = Convert.ToInt32(id);
            if (OpenConnection() == true)
            {
                string query = "DELETE FROM tbl_account_credentials WHERE user_id=" + uid;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                query = "DELETE FROM tbl_user_information WHERE user_id=" + uid;
                cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            return validity;
        }
        public bool editEmployee(string id, string username, string password, string usertype, string firstname, string middlename,
            string lastname, string gender, string mobile, string tele, string email, string address, string bday)
        {
            bool validity = false;
            int uid = Convert.ToInt32(id);
            if (OpenConnection() == true)
            {
                StringBuilder query = new StringBuilder();
                query.Append("UPDATE tbl_account_credentials SET username='" + username + "',password='" + password + "',usertype='" + usertype + "' " +
                    "WHERE user_id=" + uid);
                MySqlCommand cmd = new MySqlCommand(query.ToString(), connection);
                cmd.ExecuteNonQuery();
                query.Clear();
                query.Append("UPDATE tbl_user_information SET firstname='" + firstname + "',middlename='" + middlename + "',lastname='" + lastname + "', " +
                    "gender='" + gender + "',mobile_no='" + mobile + "',tel_no='" + tele + "',email='" + email + "',address='" + address + "',birthday='" + bday + "' WHERE user_id=" + uid);
                cmd = new MySqlCommand(query.ToString(), connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            return validity;
        }

        public int getCount()
        {
            int count = -1;
            if (OpenConnection() == true)
            {
                string query = "SELECT COUNT(*) FROM tbl_account_credentials";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return count;
        }

        public int getProductCount()
        {
            int count = -1;
            if (OpenConnection() == true)
            {
                string query = "SELECT COUNT(*) FROM tbl_products";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return count;
        }

        public bool recordSales(string amount)
        {
            String[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "INSERT INTO `tbl_sales_report`(`amount`, `day`, `month`, `year`, `time`) VALUES " +
                    "('" + amount + "','" + DateTime.Now.Day.ToString() + "','" + months[DateTime.Now.Month - 1] + "','" + DateTime.Now.Year.ToString()
                    + "','" + DateTime.Now.ToString("hh:mm tt") + "')";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                validity = true;
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return validity;
        }

        public bool setPercentage(string sc, string pwd, string vat)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "UPDATE `tbl_tax_discount` SET `sc_discount`='" + sc + "',`pwd_discount`='" + pwd + "'," +
                    "`vat_percent`='" + vat + "' WHERE percent_id='1'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            return validity;
        }

        public MySqlCommand getPercentage()
        {
            string query = "SELECT sc_discount,pwd_discount,vat_percent FROM tbl_tax_discount WHERE percent_id='1'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            return cmd;
        }

        public DataTable viewCoupons()
        {
            DataTable dt = new DataTable();
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_coupon";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }

        public int getCouponCount()
        {
            int count = -1;
            if (OpenConnection() == true)
            {
                string query = "SELECT COUNT(*) FROM tbl_coupon";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return count;
        }

        public bool editCoupon(string id, string cdesc, string cpercent)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "UPDATE tbl_coupon SET coupon_desc='" + cdesc + "',coupon_percent='" + cpercent + "' WHERE coupon_ID='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            return validity;
        }

        public bool createCoupon(string id, string cdesc, string cpercent)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "INSERT INTO `tbl_coupon`(`coupon_ID`, `coupon_desc`, `coupon_percent`) VALUES ('" + id + "','" + cdesc + "','" + cpercent + "')";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return validity;
        }

        public bool checkCoupon(string cid, string cdesc)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_coupon WHERE coupon_ID='" + cid + "' OR coupon_desc='" + cdesc + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i >= 1)
                {
                    validity = true;
                }
                connection.Close();
            }
            else
            {
                validity = false;
            }
            return validity;
        }

        public bool validateCoupon(string cid)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_coupon WHERE coupon_ID='" + cid + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i >= 1)
                {
                    validity = true;
                }
                connection.Close();
            }
            else
            {
                validity = false;
            }
            return validity;
        }

        public bool deleteCoupon(string id)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "DELETE FROM tbl_coupon WHERE coupon_ID='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                validity = true;
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return validity;
        }

        public MySqlCommand getCouponDiscount(string id)
        {
            string query = "SELECT coupon_percent FROM tbl_coupon WHERE coupon_ID='" + id + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            return cmd;
        }

        public int getSalesCount()
        {
            int count = -1;
            if (OpenConnection() == true)
            {
                string query = "SELECT COUNT(*) FROM tbl_sales_report";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return count;
        }

        public int getSpecificSalesCount(string day, string month, string year, string type)
        {
            int count = -1;
            string query = "";
            if (OpenConnection() == true)
            {
                if (type == "year")
                {
                    query = "SELECT COUNT(*) FROM tbl_sales_report WHERE year = '" + year + "'";
                }
                else if (type == "year and month")
                {
                    query = "SELECT COUNT(*) FROM tbl_sales_report WHERE year = '" + year + "' AND month = '" + month + "'";
                }
                else if (type == "day, month, and year")
                {
                    query = "SELECT COUNT(*) FROM tbl_sales_report WHERE year = '" + year + "' AND month = '" + month + "' AND day = '" + day + "'";
                }
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = int.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return count;
        }

        public string getSales()
        {
            double count = 0;
            if (OpenConnection() == true)
            {
                string query = "SELECT SUM(amount) FROM tbl_sales_report";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = double.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return String.Format("{0:#,0.00}", count);
        }

        public string getSpecificSales(string day, string month, string year, string type)
        {
            double count = 0;
            string query = "";
            if (OpenConnection() == true)
            {
                if (type == "year")
                {
                    query = "SELECT SUM(amount) FROM tbl_sales_report WHERE year = '" + year + "'";
                }
                else if (type == "year and month")
                {
                    query = "SELECT SUM(amount) FROM tbl_sales_report WHERE year = '" + year + "' AND month = '" + month + "'";
                }
                else if (type == "day, month, and year")
                {
                    query = "SELECT SUM(amount) FROM tbl_sales_report WHERE year = '" + year + "' AND month = '" + month + "' AND day = '" + day + "'";
                }
                MySqlCommand cmd = new MySqlCommand(query, connection);
                count = double.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return String.Format("{0:#,0.00}", count);
        }

        public DataTable viewSales()
        {
            DataTable dt = new DataTable();
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_sales_report";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }

        public DataTable viewSpecificSale(string day, string month, string year, string type)
        {
            DataTable dt = new DataTable();
            string query = "";
            if (OpenConnection() == true)
            {
                if (type == "year")
                {
                    query = "SELECT * FROM tbl_sales_report WHERE year = '" + year + "'";
                }
                else if (type == "year and month")
                {
                    query = "SELECT * FROM tbl_sales_report WHERE year = '" + year + "' AND month = '" + month + "'";
                }
                else if (type == "day, month, and year")
                {
                    query = "SELECT * FROM tbl_sales_report WHERE year = '" + year + "' AND month = '" + month + "' AND day = '" + day + "'";
                }
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }

        public string validateUser(string username, string password)
        {
            string dec = "";
            int i = 0;
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_account_credentials WHERE username='" + username + "' AND password='" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 1)
                {
                    DataRow row = dt.Rows[0];
                    dec = row["usertype"].ToString();
                }
                connection.Close();
            }
            else
            {
                dec = "error";
            }
            return dec;
        }

        public DataTable viewDateLog(string date)
        {
            DataTable dt = new DataTable();
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_activity_log WHERE date = '" + date + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }

        public DataTable viewUserActivity(string name, string date)
        {
            DataTable dt = new DataTable();
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_activity_log WHERE username = '" + name + "' AND date = '" + date + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }

        public bool recordActivity(string username, string date, string time, string activity)
        {
            bool validity = false;
            if (OpenConnection() == true)
            {
                string query = "INSERT INTO `tbl_activity_log`(`username`, `activity_description`, `date`, `time`) VALUES ('" + username + "'," +
                    "'" + activity + "','" + date + "','" + time + "')";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                validity = true;
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return validity;
        }

        public DataTable viewActivity()
        {
            DataTable dt = new DataTable();
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_activity_log";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }

        public DataTable searchUserActivity(string name)
        {
            DataTable dt = new DataTable();
            if (OpenConnection() == true)
            {
                string query = "SELECT * FROM tbl_activity_log WHERE username = '" + name + "'";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                connection.Close();
            }
            else
            {
                MessageBox.Show("No connection! try again.");
            }
            return dt;
        }
    }
}
