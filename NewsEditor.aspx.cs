using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class NewsEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var column1 = GridView1.Columns[1];
            column1.Visible = false;
        }
        // Добавление новости 
        protected void AddingButton_Click(object sender, EventArgs e)
        {
            string title = Convert.ToString(Textbox2.Text);
            string text = Convert.ToString(Textbox3.Text);
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
            OleDbConnection connect = new OleDbConnection(connectString);
            connect.Open();

            // генерация id новости
            string idMaxNew = "SELECT max(News.id_news) FROM News";
            var myc_basket = new OleDbCommand();
            myc_basket.CommandText = idMaxNew;
            myc_basket.Connection = connect;
            OleDbDataReader myread_idord;
            myread_idord = myc_basket.ExecuteReader();
            myread_idord.Read();
            long MaxNew = Convert.ToInt64(myread_idord.GetValue(0));
            MaxNew += 1;

            // запрос на добаление новости
            string sqlQ = sqlQ = "insert into News values ('"+ MaxNew + "','" + title + "'," + "Now(),'" + text + "')";
            var mycom = new OleDbCommand();
            mycom.CommandText = sqlQ;
            mycom.Connection = connect;
            OleDbDataReader myread;
            myread = mycom.ExecuteReader();
            connect.Close();

            // обновление страницы
            Response.Redirect("NewsEditor.aspx");
            connect.Open();
            string Crit;
            Crit = "SELECT [id_news], [title_news], [date_news], [text_news] FROM [News]" + Session["IDP"];
            SqlDataSource1.SelectCommand = Crit;
            GridView1.DataBind();
        }
        
        // Удаление новостей
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newsss = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Николай\\OneDrive\\Рабочий стол\\BD.accdb\"";
            OleDbConnection connect = new OleDbConnection(connectString);
            connect.Open();
            string sqlQ = "DELETE FROM News WHERE id_news = " + newsss;
            var mycom = new OleDbCommand();
            mycom.CommandText = sqlQ;
            mycom.Connection = connect;
            OleDbDataReader myread;
            myread = mycom.ExecuteReader();
            connect.Close();
            Response.Redirect("NewsEditor.aspx");
            connect.Open();
            string Crit;
            Crit = "SELECT [id_news], [title_news], [date_news], [text_news] FROM [News]" + Session["IDP"];
            SqlDataSource1.SelectCommand = Crit;
            GridView1.DataBind();
        }
    }
}
