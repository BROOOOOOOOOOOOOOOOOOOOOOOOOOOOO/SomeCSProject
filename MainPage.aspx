<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="DB.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [title_news], [date_news], [text_news] FROM [News]"></asp:SqlDataSource>
    <h3 style="padding-bottom:1vh">
        Новости
    </h3>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="title_news" HeaderText="Событие" SortExpression="title_news"></asp:BoundField>
            <asp:BoundField DataField="date_news" HeaderText="Дата" SortExpression="date_news"></asp:BoundField>
            <asp:BoundField DataField="text_news" HeaderText="Описание" SortExpression="text_news"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <h3 style="padding-bottom:1vh; padding-top:1vh;">
   Информация о компании
  </h3>
   <p>
    Петербургская сеть аптек "Подорожник" была основана в 1997 году российским предпринимателем Жильцовым Николаем Вячеславовичем. На протяжении всех двадцати шести лет существования "Подорожник" предоставляет людям возможность приобретать качественные лекарства по самой низкой цене. «Подорожник» – многократный победитель профессиональных фармацевтических премий и конкурсов. Например, в 2009 году наша аптека была удостоена звания “Лучшая аптечная сеть”,  а в 2018 была признана любимым брендом петербуржцев в категории “Аптеки”.
    </p>
</asp:Content>

