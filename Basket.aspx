<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="Basket.aspx.cs" Inherits="DB.Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT Goods.[good_name], count(Basket.quantity), count(Basket.quantity) * Goods.[price] FROM [Goods] INNER JOIN Basket ON Goods.[id_good] = Basket.[id_good] WHERE [id_basket] > 10 AND [id_order] = 1 GROUP BY Goods.[good_name], Basket.quantity, Goods.[price];" DeleteCommand="DELETE FROM Basket WHERE id_basket > 10 AND id_order = 1 and id_good = (select id_good from Goods where good_name = @good_name)"></asp:SqlDataSource>
    <asp:Label ID="Label2" Visible="False" runat="server" Width="100%" Text="" Font-Bold="False" Font-Size="25px" ForeColor="red"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" Font-Size="Large" AutoPostBack="True" DataTextField="address" DataValueField="address" DataSourceID="SqlDataSource2"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [address] FROM [Pick_Up_points]"></asp:SqlDataSource>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
            <asp:BoundField DataField="good_name" HeaderText="Товар" SortExpression="good_name"></asp:BoundField>
            <asp:BoundField DataField="Expr1001" HeaderText="Количество" SortExpression="Expr1001"></asp:BoundField>
            <asp:BoundField DataField="Expr1002" HeaderText="Сумма" ReadOnly="True" SortExpression="Expr1002"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <div style="width: 12.5vw; height: 4vh;">
        <asp:Button ID="OrderButton" runat="server" Text="Оформить заказ" OnClick="OrderButton_Click" />
    </div>
</asp:Content>

