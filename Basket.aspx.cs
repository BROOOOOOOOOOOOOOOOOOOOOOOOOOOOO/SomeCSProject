using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class Basket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Удаление товара из корзины
            string goodName;
            goodName = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
            OleDbConnection connect = new OleDbConnection(connectString);
            connect.Open();
            string idGood = "DELETE FROM Basket WHERE id_basket > 10 AND id_order = 1 and id_good = (select id_good from Goods where good_name = '" + goodName + "');";
            var mycom = new OleDbCommand();
            mycom.CommandText = idGood;
            mycom.Connection = connect;
            OleDbDataReader myread;
            myread = mycom.ExecuteReader();

            // Обновление корзины
            string BasketDel = "SELECT Goods.[good_name], count(Basket.quantity), count(Basket.quantity) * Goods.[price] FROM [Goods] INNER JOIN Basket ON Goods.[id_good] = Basket.[id_good] WHERE [id_basket] > 10 AND [id_order] = 1 GROUP BY Goods.[good_name], Basket.quantity, Goods.[price];";
            var basket_m = new OleDbCommand();
            basket_m.CommandText = BasketDel;
            basket_m.Connection = connect;
            OleDbDataReader myread_basket;
            myread_basket = basket_m.ExecuteReader();

        }

        // Оформление заказа
        protected void OrderButton_Click(object sender, EventArgs e)
        {
            // получение последнего id заказа 
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
            OleDbConnection connect = new OleDbConnection(connectString);
            connect.Open();
            string idMaxOrder = "SELECT max(Orders.id_order) FROM Orders";
            var myc_basket = new OleDbCommand();
            myc_basket.CommandText = idMaxOrder;
            myc_basket.Connection = connect;
            OleDbDataReader myread_idord;
            myread_idord = myc_basket.ExecuteReader();
            myread_idord.Read();
            long idOrders = Convert.ToInt64(myread_idord.GetValue(0));
            idOrders += 1;

            // получение id пользователя 
            string idUser = "SELECT id_user FROM Users WHERE login = '" + Session["IDU"] +"'";
            var us = new OleDbCommand();
            us.CommandText = idUser;
            us.Connection = connect;
            OleDbDataReader myread_idus;
            myread_idus = us.ExecuteReader();
            myread_idus.Read();
            long idUss = Convert.ToInt64(myread_idus.GetValue(0));

            // получение id пункта выдачи 
            string idPoint = "SELECT id_point FROM Pick_Up_points WHERE address = '" + this.DropDownList2.SelectedValue + "'";
            var point = new OleDbCommand();
            point.CommandText = idPoint;
            point.Connection = connect;
            OleDbDataReader myread_point;
            myread_point = point.ExecuteReader();
            myread_point.Read();
            long idPNT = Convert.ToInt64(myread_point.GetValue(0));

            // расчет суммы 
            string Summm = "SELECT sum(Goods.[price])FROM [Goods]  INNER JOIN Basket ON Goods.[id_good] = Basket.[id_good] WHERE[id_basket] > 10 AND[id_order] = 1 ";
            var s = new OleDbCommand();
            s.CommandText = Summm;
            s.Connection = connect;
            OleDbDataReader myread_s;
            myread_s = s.ExecuteReader();
            myread_s.Read();
            double s_calc = Convert.ToInt64(myread_s.GetValue(0));

            // добавление строки в таблицу Заказов 
            string sqlQ = "INSERT INTO Orders (id_order, id_user, id_point, id_st,order_sum, reg_date, issue_date) VALUES ('" + idOrders + "','" + idUss + "', '" + idPNT + "', '1', '" + s_calc + "', 'Now()', '(SELECT now() + INTERVAL 1 days)')";
            var mycommmmm = new OleDbCommand();
            mycommmmm.CommandText = sqlQ;
            mycommmmm.Connection = connect;
            OleDbDataReader myreadd;
            myreadd = mycommmmm.ExecuteReader();

            // обновление id заказа в корзине
            string sqlQl = "UPDATE Basket SET id_order = '" + idOrders + "' WHERE id_order = 1 and id_basket > 10";
            var mycommmm = new OleDbCommand();
            mycommmm.CommandText = sqlQl;
            mycommmm.Connection = connect;
            OleDbDataReader mycommmmrrr;
            mycommmmrrr = mycommmm.ExecuteReader();
        }
    }
}
