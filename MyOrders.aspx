<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="DB.Myorders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT Orders.[id_order], Order_status.[st_name], Pick_Up_points.[address], Orders.[order_sum],Orders.[reg_date], Orders.[issue_date]
FROM Order_status INNER JOIN (Pick_Up_points INNER JOIN (Orders INNER JOIN Users ON Orders.id_user = Users.id_user)
ON Pick_Up_points.id_point = Orders.id_point) ON Order_status.id_st = Orders.id_st "></asp:SqlDataSource>
    <h4 style="padding-bottom:1vh">Список ваших заказов</h4>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AllowSorting="True" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id_order" HeaderText="Номер заказа" InsertVisible="False" SortExpression="id_order"></asp:BoundField>
            <asp:BoundField DataField="st_name" HeaderText="Статус" SortExpression="st_name"></asp:BoundField>
            <asp:BoundField DataField="address" HeaderText="Пункт выдачи" SortExpression="address"></asp:BoundField>
            <asp:BoundField DataField="order_sum" HeaderText="Сумма заказа" SortExpression="order_sum"></asp:BoundField>
            <asp:BoundField DataField="reg_date" HeaderText="Дата оформления" SortExpression="reg_date"></asp:BoundField>
            <asp:BoundField DataField="issue_date" HeaderText="Дата доставки" SortExpression="issue_date"></asp:BoundField>
        </Columns>
    </asp:GridView>
    
    
</asp:Content>

