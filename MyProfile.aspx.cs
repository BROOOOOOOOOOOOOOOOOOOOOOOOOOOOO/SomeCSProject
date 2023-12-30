using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // если пользователь авторизован
            // открыть страницу в режиме редактирования данных
            if (Convert.ToInt64(Session["IDP"]) != 0)
            {
                RegButton.Visible = false;
                ChangeButton.Visible = true;
            }
            // если пользователь неавторизован
            // открыть страницу в режиме регистрации
            else
            {
                long idu = Convert.ToInt64(Session["IDP"]);
                ChangeButton.Visible = false;
                RegButton.Visible = true;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            // подтянуть данные из БД
            if (Convert.ToInt64(Session["IDP"]) != 0)
            {
                string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
                OleDbConnection connect = new OleDbConnection(connectString);
                connect.Open();
                string sqlQ = "SELECT surname, user_name, patronymic, phone_number, email, " +
                    "login, password FROM Users WHERE id_user = " + Session["IDP"];
                var mycom = new OleDbCommand();
                mycom.CommandText = sqlQ;
                mycom.Connection = connect;
                OleDbDataReader myread;
                myread = mycom.ExecuteReader();
                myread.Read();
                TextBox1.Text = Convert.ToString(myread.GetValue(0));
                TextBox2.Text = Convert.ToString(myread.GetValue(1));
                TextBox3.Text = Convert.ToString(myread.GetValue(2));
                TextBox4.Text = Convert.ToString(myread.GetValue(3));
                TextBox5.Text = Convert.ToString(myread.GetValue(4));
                TextBox6.Text = Convert.ToString(myread.GetValue(5));
                TextBox7.Text = Convert.ToString(myread.GetValue(6));
            }
        }
        // регистрация
        protected void RegButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
                OleDbConnection connect = new OleDbConnection(connectString);
                connect.Open();
                string surname, sname, patron, tele, mail, sparol, slogin;
                surname = Convert.ToString(TextBox1.Text);
                sname = Convert.ToString(TextBox2.Text);
                patron = Convert.ToString(TextBox3.Text);
                tele = Convert.ToString(TextBox4.Text);
                mail = Convert.ToString(TextBox5.Text);
                slogin = Convert.ToString(TextBox6.Text);
                sparol = Convert.ToString(TextBox7.Text);
                Session["IDU"] = slogin;

                // Указание ID
                string idUS = "SELECT max(Users.id_user) FROM Users";
                var myc_basket = new OleDbCommand();
                myc_basket.CommandText = idUS;
                myc_basket.Connection = connect;
                OleDbDataReader myread_idbask;
                myread_idbask = myc_basket.ExecuteReader();
                myread_idbask.Read();
                long idUser = Convert.ToInt64(myread_idbask.GetValue(0));
                idUser += 1;

                string sqlQ = "INSERT INTO Users(id_user, surname, user_name, patronymic, " +
                    "phone_number, email, login, [password]) VALUES ('" + idUser + "','" + surname + "', '" +
                    sname + "', '" + patron + "', '" + tele + "', '" + mail + "', '" +
                    slogin + "', '" + sparol + "')";
                var mycom = new OleDbCommand();
                mycom.CommandText = sqlQ;
                mycom.Connection = connect;
                OleDbDataReader myread;
                myread = mycom.ExecuteReader();
                Session["TU"] = 1;
                Session["IDU"] = slogin;
                sqlQ = "SELECT TOP 1 id_user FROM Users WHERE login = '" + Session["IDU"] +
                    "' ORDER BY id_user DESC";
                mycom = new OleDbCommand();
                mycom.CommandText = sqlQ;
                mycom.Connection = connect;
                myread = mycom.ExecuteReader();
                myread.Read();
                Session["IDP"] = Convert.ToString(myread.GetValue(0));
                connect.Close();
                // редирект на нужную страницу
                Response.Redirect("MyProfile.aspx");
            }
        }
        // изменение данных профиля
        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
                OleDbConnection connect = new OleDbConnection(connectString);
                connect.Open();
                string surname, sname, patron, tele, mail, sparol, slogin;
                surname = Convert.ToString(TextBox1.Text);
                sname = Convert.ToString(TextBox2.Text);
                patron = Convert.ToString(TextBox3.Text);
                tele = Convert.ToString(TextBox4.Text);
                mail = Convert.ToString(TextBox5.Text);
                slogin = Convert.ToString(TextBox6.Text);
                sparol = Convert.ToString(TextBox7.Text);
                Session["IDU"] = slogin;

                string sqlQ = "UPDATE Users SET surname = '" + surname + "', [password] = '" + sparol + "', user_name = '" +
                    sname + "', patronymic = '" + patron + "', phone_number = '" + tele +
                    "', email = '" + mail + "', login = '" + slogin +
                    "' WHERE id_user = " + Session["IDP"];
                var mycom = new OleDbCommand();
                mycom.CommandText = sqlQ;
                mycom.Connection = connect;
                OleDbDataReader myread;
                myread = mycom.ExecuteReader();
                connect.Close();
                // редирект на нужную страницу
                Response.Redirect("MyProfile.aspx");
            }
        }
    }
}