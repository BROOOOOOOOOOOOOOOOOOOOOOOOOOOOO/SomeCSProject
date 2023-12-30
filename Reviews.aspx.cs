using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DB
{
    public partial class Reviews : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Неавторизованный пользователь
            if (Convert.ToInt64(Session["TU"]) == 0)
            {
                Label1.Visible = false;
                Button1.Visible = false;
                TextBox1.Visible = false;
                var column1 = GridView1.Columns[0];
                var column4 = GridView1.Columns[1];
                var column2 = GridView1.Columns[3];
                var column3 = GridView1.Columns[4];
                column1.Visible = false;
                column2.Visible = false;
                column3.Visible = false;
                column4.Visible = false;

            }

            // Авторизованный пользователь
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                var column1 = GridView1.Columns[0];
                var column4 = GridView1.Columns[1];
                var column2 = GridView1.Columns[3];
                var column3 = GridView1.Columns[4];
                column1.Visible = false;
                column2.Visible = false;
                column3.Visible = false;
                column4.Visible = false;
                Label1.Text = "Оставьте отзыв о нашей компании!";

            }
            // Админ
            if (Convert.ToInt64(Session["TU"]) == 2)
            {
                Label1.Visible = false;
                Button1.Visible = false;
                TextBox1.Visible = false;
                var column4 = GridView1.Columns[1];
                column4.Visible = false;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Авторизованный пользователь
            if (Convert.ToInt64(Session["TU"]) == 1)
            {

                string txt = Convert.ToString(TextBox1.Text);
                string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
                OleDbConnection connect = new OleDbConnection(connectString);
                connect.Open();

                // генерация id отзыва
                string idMaxOrder = "SELECT max(Reviews.id_review) FROM Reviews";
                var myc_basket = new OleDbCommand();
                myc_basket.CommandText = idMaxOrder;
                myc_basket.Connection = connect;
                OleDbDataReader myread_idord;
                myread_idord = myc_basket.ExecuteReader();
                myread_idord.Read();
                long idReview = Convert.ToInt64(myread_idord.GetValue(0));
                idReview += 1;

                // получение id пользователя 
                string idUser = "SELECT id_user FROM Users WHERE login = '" + Session["IDU"] + "'";
                var us = new OleDbCommand();
                us.CommandText = idUser;
                us.Connection = connect;
                OleDbDataReader myread_idus;
                myread_idus = us.ExecuteReader();
                myread_idus.Read();
                long idUss = Convert.ToInt64(myread_idus.GetValue(0));

                // Добавление отзыва
                string sqlQ = "INSERT INTO Reviews(id_review, id_user, review_text) Values ('"+ idReview + "','" + idUss + "','" + txt + "');";
                var mycom = new OleDbCommand();
                mycom.CommandText = sqlQ;
                mycom.Connection = connect;
                OleDbDataReader myread;
                myread = mycom.ExecuteReader();

                // Отображение изменений
                connect.Close();
                Response.Redirect("Reviews.aspx");
                connect.Open();
                string Crit;
                Crit = "SELECT Reviews.id_review, Users.user_name, Users.[phone_number], Users.[email], Reviews.[review_text] FROM Reviews INNER JOIN Users ON Reviews.id_user = Users.id_user" + Session["IDP"];
                SqlDataSource1.SelectCommand = Crit;
                GridView1.DataBind();
            }
        }

        // Удаление отзыва
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string review = GridView1.SelectedValue.ToString();
            string ggggg = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
            OleDbConnection con = new OleDbConnection(ggggg);
            con.Open();
            string sqlQ = "DELETE FROM Reviews WHERE id_review = " + review;
            var mycom = new OleDbCommand();
            mycom.CommandText = sqlQ;
            mycom.Connection = con;
            OleDbDataReader myread;
            myread = mycom.ExecuteReader();
            con.Close();
            Response.Redirect("Reviews.aspx");
            con.Open();
            string Crit;
            Crit = "SELECT Reviews.id_review, Users.user_name, Users.[phone_number], Users.[email], Reviews.[review_text] FROM Reviews INNER JOIN Users ON Reviews.id_user = Users.id_user" + Session["IDP"];
            SqlDataSource1.SelectCommand = Crit;
            GridView1.DataBind();
        }

    }

}