using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string myuser = Convert.ToString(Session["IDU"]);
            long iduser = Convert.ToInt64(Session["IDP"]);
            // если пользователь авторизован
            if (iduser != 0)
            {
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                TextBox1.Text = "";
                TextBox2.Text = "";
                HeadAuthLabel.Visible = true;
                LabelLogin.Visible = false;
                LabelPassword.Visible = false;
                ErrorLabel.Visible = false;
                HeadAuthLabel.Text = "Здравствуйте, " + myuser + "!";
                LeaveButton.Visible = true;
                EnterButton.Visible = false;
                RegButton.Visible = false;
                // Пользователь
                if (Convert.ToInt64(Session["TU"]) == 1)
                {
                    LinkButtonMain.Visible = true;
                    LinkButtonGoods.Visible = true;
                    LinkButtonProfile.Visible = true;
                    LinkButtonBasket.Visible = true;
                    LinkButtonOrders.Visible = true;
                    LinkButtonReviews.Visible = true;
                    LinkButtonGoodsEditor.Visible = false;
                    LinkButtonOrdersEditor.Visible = false;
                    LinkButtonNewsEditor.Visible = false;
                }
                // Админ
                else
                {
                    LinkButtonMain.Visible = true;
                    LinkButtonGoods.Visible = false;
                    LinkButtonProfile.Visible = false;
                    LinkButtonBasket.Visible = false;
                    LinkButtonOrders.Visible = false;
                    LinkButtonReviews.Visible = true;
                    LinkButtonGoodsEditor.Visible = true;
                    LinkButtonOrdersEditor.Visible = true;
                    LinkButtonNewsEditor.Visible = true;
                }
            }
            // Eсли пользователь не авторизован
            else
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                HeadAuthLabel.Visible = true;
                LabelLogin.Visible = true;
                LabelPassword.Visible = true;
                ErrorLabel.Visible = false;
                LeaveButton.Visible = false;
                EnterButton.Visible = true;
                RegButton.Visible = true;
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
        }

        // Кнопка регистрации
        protected void RegButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }

        // Главная страница
        protected void LinkButtonMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }

        // Страница с товарами
        protected void LinkButtonGoods_Click(object sender, EventArgs e)
        {
            Response.Redirect("Goods.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }

        // Страница профиля
        protected void LinkButtonProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyProfile.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }
        // Страница корзины
        protected void LinkButtonBasket_Click(object sender, EventArgs e)
        {
            Response.Redirect("Basket.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }

        // Страница заказов
        protected void LinkButtonOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyOrders.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }

        // Страница отзывов
        protected void LinkButtonReviews_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reviews.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true; ;
            }
        }

        // Страница редактирования товаров
        protected void LinkButtonGoodsEditor_Click(object sender, EventArgs e)
        {
            Response.Redirect("GoodsEditor.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }

        // Страница редактирования заказов
        protected void LinkButtonOrdersEditor_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdersEditor.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }

        // Страница редактирования новостей
        protected void LinkButtonNewsEditor_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsEditor.aspx");
            if (Convert.ToInt64(Session["TU"]) == 1)
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
            }
            else
            {
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
            }
        }

        // Вход в аккаунт
        protected void EnterButton_Click(object sender, EventArgs e)
        {
            
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
            OleDbConnection connect = new OleDbConnection(connectString);
            connect.Open();
            string sparol, slogin;
            sparol = Convert.ToString(this.TextBox2.Text);
            slogin = Convert.ToString(this.TextBox1.Text);
            string sqlQ = "SELECT id_user FROM Users WHERE login = '" + slogin + "' AND password = '" + sparol + "'";
            var mycom = new OleDbCommand();
            mycom.CommandText = sqlQ;
            mycom.Connection = connect;
            OleDbDataReader myread;
            myread = mycom.ExecuteReader();
            sqlQ = "SELECT id_employee FROM Employees WHERE login = '" + slogin + "' AND password = '" + sparol + "'";
            mycom = new OleDbCommand();
            mycom.CommandText = sqlQ;
            mycom.Connection = connect;
            OleDbDataReader myread_employee;
            myread_employee = mycom.ExecuteReader();

            // Пользователь
            if (myread.Read() == true)
            {
                Session["TU"] = 1;
                Session["IDU"] = slogin;
                Session["IDP"] = Convert.ToInt64(myread.GetValue(0));
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                HeadAuthLabel.Visible = true;
                LabelLogin.Visible = false;
                LabelPassword.Visible = false;
                ErrorLabel.Visible = false;
                HeadAuthLabel.Text = "Здравствуйте, " + slogin + "!";
                LeaveButton.Visible = true;
                EnterButton.Visible = false;
                RegButton.Visible = false;
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = true;
                LinkButtonProfile.Visible = true;
                LinkButtonBasket.Visible = true;
                LinkButtonOrders.Visible = true;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = false;
                LinkButtonOrdersEditor.Visible = false;
                LinkButtonNewsEditor.Visible = false;
                Response.Redirect("MainPage.aspx");
            }

            // Админ
            else if (myread_employee.Read() == true)
            {
                Session["TU"] = 2;
                Session["IDU"] = slogin;
                Session["IDP"] = Convert.ToString(myread_employee.GetValue(0));
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                HeadAuthLabel.Visible = true;
                LabelLogin.Visible = false;
                LabelPassword.Visible = false;
                ErrorLabel.Visible = false;
                HeadAuthLabel.Text = "Здравствуйте, " + slogin + "!";
                LeaveButton.Visible = true;
                EnterButton.Visible = false;
                RegButton.Visible = false;
                LinkButtonMain.Visible = true;
                LinkButtonGoods.Visible = false;
                LinkButtonProfile.Visible = false;
                LinkButtonBasket.Visible = false;
                LinkButtonOrders.Visible = false;
                LinkButtonReviews.Visible = true;
                LinkButtonGoodsEditor.Visible = true;
                LinkButtonOrdersEditor.Visible = true;
                LinkButtonNewsEditor.Visible = true;
                Response.Redirect("MainPage.aspx");
            }

            // Если введены некорректные данные
            else
            {
                Session["TU"] = 0;
                ErrorLabel.Visible = true;
                Session["IDP"] = 0;
                Session["IDU"] = "";
            }
            connect.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        // Выход
        protected void LeaveButton_Click(object sender, EventArgs e)
        {
            Session["TU"] = 0;
            Session["IDP"] = 0;
            Session["IDU"] = "";
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            HeadAuthLabel.Visible = false;
            LabelLogin.Visible = true;
            LabelPassword.Visible = true;
            ErrorLabel.Visible = false;
            LeaveButton.Visible = false;
            EnterButton.Visible = true;
            RegButton.Visible = true;
            LabelPassword.Text = "Пароль";
            LinkButtonMain.Visible = true;
            LinkButtonGoods.Visible = true;
            LinkButtonProfile.Visible = true;
            LinkButtonBasket.Visible = false;
            LinkButtonOrders.Visible = false;
            LinkButtonReviews.Visible = true;
            LinkButtonGoodsEditor.Visible = false;
            LinkButtonOrdersEditor.Visible = false;
            LinkButtonNewsEditor.Visible = false;
            Response.Redirect("MainPage.aspx");
        }
    }
}
