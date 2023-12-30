using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class Myorders : System.Web.UI.Page
    {
        // Отображение заказов пользователя
        protected void Page_Load(object sender, EventArgs e)
        {
            string Crit;
            Crit = "SELECT Orders.[id_order], Order_status.[st_name], Pick_Up_points.[address], Orders.[order_sum] , Orders.[issue_date] ,Orders.[reg_date] FROM Order_status INNER JOIN (Pick_Up_points INNER JOIN (Orders INNER JOIN Users ON Orders.id_user = Users.id_user) ON Pick_Up_points.id_point = Orders.id_point) ON Order_status.id_st = Orders.id_st WHERE  login = '" + Session["IDU"] + "'" ;
            SqlDataSource1.SelectCommand = Crit;
            GridView1.DataBind();
        }
        
        
    }
}
