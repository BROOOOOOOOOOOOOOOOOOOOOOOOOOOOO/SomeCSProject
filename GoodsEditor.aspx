<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="GoodsEditor.aspx.cs" Inherits="DB.GoodsEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT Goods.id_good, Goods.good_name, Goods_Categories.category_name, Goods_Availability.availability, Manufacturers.name_mf, Goods.price, Goods.description,  Goods.good_quantity
FROM Manufacturers INNER JOIN (Goods_Categories INNER JOIN (Goods_Availability INNER JOIN Goods ON Goods_Availability.id_availability = Goods.id_availability) ON Goods_Categories.id_category = Goods.id_category) ON Manufacturers.id_mf = Goods.id_mf"></asp:SqlDataSource>
    
    <h4 style="padding-top:1vh">Добавление или изменение товара</h4>
    <table>
        <tr>
            <td>
                <asp:Label ID="GoodName" runat="server" Width="100%" Text="Название" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Width="100%" Text="Категория" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Width="100%" Text="Наличие" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Width="100%" Text="Производитель" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Price" runat="server" Width="100%" Text="Цена" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Description" runat="server" Width="100%" Text="Описание" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Quantity" runat="server" Width="100%" Text="Кол-во" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
        </tr>
        <tr style="height: 2vh">
            <td style="height: 2vh">
                <asp:TextBox ID="GoodNameTextBox" runat="server"></asp:TextBox>
            </td>
            <td style="height: 2vh">
               <asp:DropDownList ID="DropDownCatrgoryList" Font-Size="XX-Large" runat="server" AutoPostBack="True" DataTextField="category_name" DataValueField="category_name" DataSourceID="SqlDataSource2"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [category_name] FROM [Goods_Categories]"></asp:SqlDataSource>
            </td>
            <td style="height: 2vh">
               <asp:DropDownList ID="AvailDropDownList" Font-Size="XX-Large" runat="server" AutoPostBack="True" DataTextField="availability" DataValueField="availability" DataSourceID="SqlDataSource3"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [availability] FROM [Goods_Availability]"></asp:SqlDataSource>
            </td>
            <td style="height: 2vh">
               <asp:DropDownList ID="MFDropDownList" Font-Size="XX-Large" runat="server" AutoPostBack="True" DataTextField="name_mf" DataValueField="name_mf" DataSourceID="SqlDataSource4"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [name_mf] FROM [Manufacturers]"></asp:SqlDataSource>
            </td>
            <td style="height: 2vh">
                <asp:TextBox ID="PriceTextBox" runat="server"></asp:TextBox>
            </td>
            <td style="height: 2vh">
                <asp:TextBox ID="DescriptionTextBox" runat="server"></asp:TextBox>
            </td>
            <td style="height: 2vh">
                <asp:TextBox ID="QuantityTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div style="height: 4vh; width: 200px">
                    <asp:Button ID="AddingButton" runat="server" Font-Size="20px" Text="Добавить товар" />
                </div>
            </td>
            <td>
                <div style="height: 4vh; width: 200px">
                    <asp:Button ID="Button1" runat="server" Font-Size="20px" Text="Изменить товар" />
                </div>
            </td>
        </tr>
    </table>
    <asp:Label ID="ErrorLabel1" runat="server" Visible="false" Width="100%" Text="Необходимо заполнить все поля!" Font-Size="30px" ForeColor="red"/>
    
    <div style="padding-bottom:2vh;"></div>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="id_good" HeaderText="ID" InsertVisible="False" SortExpression="id_good"></asp:BoundField>
            <asp:BoundField DataField="good_name" HeaderText="Товар" SortExpression="good_name"></asp:BoundField>
            <asp:BoundField DataField="category_name" HeaderText="Категория" SortExpression="category_name"></asp:BoundField>
            <asp:BoundField DataField="availability" HeaderText="Наличие" SortExpression="availability"></asp:BoundField>
            <asp:BoundField DataField="name_mf" HeaderText="Производитель" SortExpression="name_mf"></asp:BoundField>
            <asp:BoundField DataField="price" HeaderText="Цена" SortExpression="price"></asp:BoundField>
            <asp:BoundField DataField="description" HeaderText="Описание" SortExpression="description"></asp:BoundField>
            <asp:BoundField DataField="good_quantity" HeaderText="Кол-во" SortExpression="good_quantity"></asp:BoundField>
        </Columns>
    </asp:GridView>
    
</asp:Content>

