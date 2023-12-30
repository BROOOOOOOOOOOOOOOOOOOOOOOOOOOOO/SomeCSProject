<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="OrdersEditor.aspx.cs" Inherits="DB.OrdersEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT Orders.[id_order], Users.[user_name],Users.[phone_number], Pick_Up_points.[address], Order_status.[st_name], Orders.[reg_date], Orders.[issue_date]
FROM Order_status INNER JOIN (Pick_Up_points INNER JOIN (Orders INNER JOIN Users ON Orders.id_user = Users.id_user)
ON Pick_Up_points.id_point = Orders.id_point) ON Order_status.id_st = Orders.id_st ;"></asp:SqlDataSource>
    <h3 style="padding-top:1vh">Изменение заказа</h3>
    <table>
        <tr style="width: 13vw; height: 4vh;">
            <td style="height: 4vh;">
                <asp:Label ID="Label1" runat="server" Width="100%" Text="Введите ID заказа" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td style="height: 4vh;">
                <asp:Label ID="Label2" runat="server" Width="100%" Text="Выберите статус заказа" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
        </tr>
        <tr style="width: 13vw; height: 4vh;">
            <td style="height: 4vh;">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" Font-Size="XX-Large" runat="server" DataTextField="st_name" DataValueField="st_name" AutoPostBack="True" DataSourceID="SqlDataSource2"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [st_name] FROM [Order_status]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr style="width: 13vw; height: 4vh;">
            <td style="height: 4vh;" colspan="2">
                <asp:Button ID="Button1" runat="server" Font-Size="20px" Text="Изменить"/>
            </td>
        </tr>
    </table>
    
    <h3 style="padding-top:1vh">Заказы</h3>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowEditButton="True"></asp:CommandField>
            <asp:BoundField DataField="user_name" HeaderText="Пользователь" SortExpression="user_name"></asp:BoundField>
            <asp:BoundField DataField="phone_number" HeaderText="Номер телефона" SortExpression="phone_number"></asp:BoundField>
            <asp:BoundField DataField="address" HeaderText="Пункт выдачи" SortExpression="address"></asp:BoundField>
            <asp:BoundField DataField="st_name" HeaderText="Статус" SortExpression="st_name"></asp:BoundField>
            <asp:BoundField DataField="reg_date" HeaderText="Дата оформления" SortExpression="reg_date"></asp:BoundField>
            <asp:BoundField DataField="issue_date" HeaderText="Дата доставки" SortExpression="issue_date"></asp:BoundField>
        </Columns>
    </asp:GridView>
    
</asp:Content>

