using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class Goods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Неавторизованный пользователь
            if (Convert.ToInt64(Session["TU"]) == 0)
            {
                Label1.Text = "Для добавления товаров в корзину необходимо авторизоваться";
                var column1 = GridView1.Columns[0];
                column1.Visible = false;


            }

            // Авторизованный пользователь
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                Label1.Text = "Для оформления заказа выберите интересующие товары и перейдите на страницу Корзина";
                var column1 = GridView1.Columns[0];
                column1.Visible = true;


            }

        }
        // фильтр по категории
        protected void Button1_Click(object sender, EventArgs e)
        {
            string crit;
            crit = "SELECT Goods.good_name, Goods_Categories.category_name, Manufacturers.name_mf, Goods.price, Goods.description,Goods.good_quantity FROM Manufacturers INNER JOIN (Goods_Categories INNER JOIN (Goods_Availability INNER JOIN Goods ON Goods_Availability.id_availability = Goods.id_availability) ON Goods_Categories.id_category = Goods.id_category) ON Manufacturers.id_mf = Goods.id_mf WHERE Goods.good_quantity > 0 " +
            "AND category_name = '" + this.DropDownList1.SelectedValue + "'";
            SqlDataSource3.SelectCommand = crit;
            GridView1.DataBind();
        }

        // фильтр по производителю
        protected void Button2_Click(object sender, EventArgs e)
        {
            string crit;
            crit = "SELECT Goods.good_name, Goods_Categories.category_name, Manufacturers.name_mf, Goods.price, Goods.description,Goods.good_quantity FROM Manufacturers INNER JOIN (Goods_Categories INNER JOIN (Goods_Availability INNER JOIN Goods ON Goods_Availability.id_availability = Goods.id_availability) ON Goods_Categories.id_category = Goods.id_category) ON Manufacturers.id_mf = Goods.id_mf WHERE Goods.good_quantity > 0 " +
            "AND name_mf = '" + this.DropDownList2.SelectedValue + "'";
            SqlDataSource3.SelectCommand = crit;
            GridView1.DataBind();
        }

        // фильтр по категории и производителю
        protected void Button3_Click(object sender, EventArgs e)
        {
            string crit1, crit;
            crit1 = "category_name = '" + this.DropDownList1.SelectedValue +
            "' AND  name_mf = '" + this.DropDownList2.SelectedValue + "'";
            crit = "SELECT Goods.good_name, Goods_Categories.category_name, Manufacturers.name_mf, Goods.price, Goods.description,Goods.good_quantity FROM Manufacturers INNER JOIN (Goods_Categories INNER JOIN (Goods_Availability INNER JOIN Goods ON Goods_Availability.id_availability = Goods.id_availability) ON Goods_Categories.id_category = Goods.id_category) ON Manufacturers.id_mf = Goods.id_mf WHERE Goods.good_quantity > 0 " +
            "AND " + crit1;
            SqlDataSource3.SelectCommand = crit;
            GridView1.DataBind();
        }

        // отмена фильтров
        protected void Button4_Click(object sender, EventArgs e)
        {
            string crit;
            crit = "SELECT Goods.good_name, Goods_Categories.category_name, Manufacturers.name_mf, Goods.price, Goods.description,Goods.good_quantity FROM Manufacturers INNER JOIN (Goods_Categories INNER JOIN (Goods_Availability INNER JOIN Goods ON Goods_Availability.id_availability = Goods.id_availability) ON Goods_Categories.id_category = Goods.id_category) ON Manufacturers.id_mf = Goods.id_mf WHERE Goods.good_quantity > 0";
            SqlDataSource3.SelectCommand = crit;
            GridView1.DataBind();
        }

        // Добавление товаров в корзину
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // получение id товара
            string goodName;
            goodName = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
            OleDbConnection connect = new OleDbConnection(connectString);
            connect.Open();
            string idGoodSelectQuery = "SELECT Goods.id_good FROM Goods WHERE Goods.good_name = '" + goodName + "';";
            var mycom = new OleDbCommand();
            mycom.CommandText = idGoodSelectQuery;
            mycom.Connection = connect;
            OleDbDataReader myread;
            myread = mycom.ExecuteReader();
            myread.Read();
            long idGood = Convert.ToInt64(myread.GetValue(0));
            string id_Good = Convert.ToString(idGood);
            

            // получение id заказа 
            string idOrderSelectQuery = "SELECT min(Orders.id_order) FROM Orders";
            var myc_order = new OleDbCommand();
            myc_order.CommandText = idOrderSelectQuery;
            myc_order.Connection = connect;
            OleDbDataReader myread_order;
            myread_order = myc_order.ExecuteReader();
            myread_order.Read();
            long idOrder = Convert.ToInt64(myread_order.GetValue(0));
            string min_id_Order = Convert.ToString(idOrder);
            

            // получение последнего id корзины 
            string idMaxBasket = "SELECT max(Basket.id_basket) FROM Basket";
            var myc_basket = new OleDbCommand();
            myc_basket.CommandText = idMaxBasket;
            myc_basket.Connection = connect;
            OleDbDataReader myread_idbask;
            myread_idbask = myc_basket.ExecuteReader();
            myread_idbask.Read();
            long idBasket = Convert.ToInt64(myread_idbask.GetValue(0));
            idBasket += 1;
            

            // Добавление записи в корзину
            string BasketAdding = "insert into Basket(id_basket, id_order, id_good, quantity) values('"+ idBasket + "','" + min_id_Order + "', '" + id_Good + "', 1);";
            var basket_m = new OleDbCommand();
            basket_m.CommandText = BasketAdding;
            basket_m.Connection = connect;
            OleDbDataReader myread_basket;
            myread_basket = basket_m.ExecuteReader();
            
        }
    }
}