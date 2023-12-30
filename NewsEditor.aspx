<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="NewsEditor.aspx.cs" Inherits="DB.NewsEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [id_news], [title_news], [date_news], [text_news] FROM [News]" DeleteCommand="DELETE FROM News WHERE id_news = @id_news"></asp:SqlDataSource>

    <h3 style="padding-top:1vh">Добавление новости</h3>
    <table>
        <tr style="width: 13vw; height: 4vh;">
            <td style="height: 4vh;">
                <asp:Label ID="Label2" runat="server" Width="100%" Text="Событие" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td style="height: 4vh;">
                <asp:Label ID="Label5" runat="server" Width="100%" Text="Информация" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
        </tr>
        <tr style="width: 13vw; height: 4vh;">
            <td style="height: 4vh;">
                <asp:TextBox ID="Textbox2" runat="server"></asp:TextBox>
            </td>
            <td style="height: 4vh;">
                <asp:TextBox ID="Textbox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="width: 13vw; height: 4vh;">
            <td style="height: 4vh;" colspan="3">
                <asp:Button ID="AddingButton" runat="server" Font-Size="20px" Text="Добавить новость" OnClick="AddingButton_Click"/>
            </td>
        </tr>
    </table>
     <asp:Label ID="ErrorLabel1" runat="server" Visible="false" Width="100%" Text="Необходимо заполнить все поля!" Font-Size="35px" ForeColor="red"/>
    <h3 style="padding-bottom:1vh">
    Новости
</h3>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="id_news" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>

        <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
        <asp:BoundField DataField="id_news" HeaderText="ID" ReadOnly="True" SortExpression="id_news"></asp:BoundField>
        <asp:BoundField DataField="title_news" HeaderText="Событие" SortExpression="title_news"></asp:BoundField>
        <asp:BoundField DataField="date_news" HeaderText="Дата" SortExpression="date_news"></asp:BoundField>
        <asp:BoundField DataField="text_news" HeaderText="Информация" SortExpression="text_news"></asp:BoundField>
        </Columns>
</asp:GridView>
   
</asp:Content>

