<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="Reviews.aspx.cs" Inherits="DB.Reviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT Reviews.id_review, Users.user_name, Users.[phone_number], Users.[email], Reviews.[review_text] FROM Reviews INNER JOIN Users ON Reviews.id_user = Users.id_user;" DeleteCommand="DELETE FROM Reviews WHERE Reviews.id_review = @id_review"></asp:SqlDataSource>
    <asp:Label ID="Label1" Visible="True" runat="server" Width="100%" Text="" ForeColor="green"></asp:Label>
    <div style="height:30px;width:450px;">
        <asp:TextBox ID="TextBox1" Visible="True" runat="server"></asp:TextBox>
    </div> 
     <div style="padding-bottom:1vh"></div>
    <div style="height:30px;width:200px;">
        <asp:Button ID="Button1" Font-Size="20px" Visible="True" runat="server" Text="Отправить отзыв" OnClick="Button1_Click"/>
    </div> 
     
    <div style="padding-bottom:1.5vh">
            <asp:Label ID="AllUsersReviews" Visible="True" runat="server" Width="100%" Text="Отзывы покупателей" ForeColor="green"></asp:Label>

    </div>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames ="id_review">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ></asp:CommandField>
            <asp:BoundField DataField="id_review" HeaderText="IDR" SortExpression="id_review"></asp:BoundField>
            <asp:BoundField DataField="user_name" HeaderText="Имя" SortExpression="user_name"></asp:BoundField>
            <asp:BoundField DataField="phone_number" HeaderText="Номер телефона" SortExpression="phone_number"></asp:BoundField>
            <asp:BoundField DataField="email"  HeaderText="Почта" SortExpression="email"></asp:BoundField>
            <asp:BoundField DataField="review_text" HeaderText="Текст отзыва" SortExpression="review_text"></asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>

