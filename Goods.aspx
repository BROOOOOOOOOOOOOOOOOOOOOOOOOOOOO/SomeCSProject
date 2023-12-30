<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="Goods.aspx.cs" Inherits="DB.Goods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" Visible="True" runat="server" Width="100%" Text="" Font-Bold="True" Font-Size="20px" ForeColor="black"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Large" AutoPostBack="True" DataTextField="category_name" DataValueField="category_name" DataSourceID="SqlDataSource1"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT Goods.good_name, Goods_Categories.category_name, Goods_Availability.availability, Manufacturers.name_mf, Goods.price, Goods.description,  Goods.good_quantity FROM Manufacturers INNER JOIN (Goods_Categories INNER JOIN (Goods_Availability INNER JOIN Goods ON Goods_Availability.id_availability = Goods.id_availability) ON Goods_Categories.id_category = Goods.id_category) ON Manufacturers.id_mf = Goods.id_mf WHERE Goods.good_quantity > 0 ;"></asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [category_name] FROM [Goods_Categories]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList2" runat="server" Font-Size="Large" AutoPostBack="True" DataTextField="name_mf" DataValueField="name_mf" DataSourceID="SqlDataSource2"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [name_mf] FROM [Manufacturers]"></asp:SqlDataSource>
   <table>
       <tr style="width: 12.5vw; height: 4vh;">
           <td style="height: 4vh;">
                <asp:Button ID="Button5" runat="server" Text="Поиск по категории" OnClick="Button1_Click" />
           </td>
           <td style="height: 4vh;">
               <asp:Button ID="Button6" runat="server" Text="Поиск по производителю" OnClick="Button2_Click" />
           </td>
           <td style="height: 4vh;">
               <asp:Button ID="Button7" runat="server" Text="Поиск по категории и производителю" OnClick="Button3_Click" />
           </td>
           <td style="height: 4vh;">
               <asp:Button ID="Button8" runat="server" Text="Сброс" OnClick="Button4_Click" />
           </td>
       </tr> 
   </table> 
    <asp:Label ID="Label2" Visible="False" runat="server" Width="100%" Text="Выбрано максимальное количество данного товара" Font-Bold="False" Font-Size="25px" ForeColor="red"></asp:Label>
    <div style="height: 1.5vh;"></div>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="False" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="good_name" HeaderText="Товар" SortExpression="good_name"></asp:BoundField>
            <asp:BoundField DataField="category_name" HeaderText="Категория" SortExpression="category_name"></asp:BoundField>
            <asp:BoundField DataField="name_mf" HeaderText="Производитель" SortExpression="name_mf"></asp:BoundField>
            <asp:BoundField DataField="price" HeaderText="Цена" SortExpression="price"></asp:BoundField>
            <asp:BoundField DataField="description" HeaderText="Описание" SortExpression="description"></asp:BoundField>
            <asp:BoundField DataField="good_quantity" HeaderText="Кол-во" SortExpression="good_quantity"></asp:BoundField>
        </Columns>
    </asp:GridView>
       
</asp:Content>

