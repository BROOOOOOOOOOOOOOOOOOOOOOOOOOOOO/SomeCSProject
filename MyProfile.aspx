<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" Inherits="DB.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3 style="padding-bottom: 1vh; margin-left: 95px;">Ваши данные</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Width="100%" Text="Фамилия" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" EnableClientScript="False" ErrorMessage="Введите фамилию"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Width="100%" Text="Имя" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" EnableClientScript="False" ErrorMessage="Введите имя"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Width="100%" Text="Отчество" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" EnableClientScript="False" ErrorMessage="Введите отчество"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Width="100%" Text="Номер телефона" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" EnableClientScript="False" ErrorMessage="Введите телефон"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" EnableClientScript="False" ErrorMessage="Введите существующий телефон" ValidationExpression="^((\+7|7|8)+([0-9]){10})$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Width="100%" Text="Email" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" EnableClientScript="False" ErrorMessage="Введите email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5" EnableClientScript="False" ErrorMessage="Введите существующий email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Width="100%" Text="Логин" Font-Size="30px" ForeColor="green"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" EnableClientScript="False" ErrorMessage="Введите логин"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Width="100%" Text="Пароль" Font-Size="30px" ForeColor="green" />
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox7" EnableClientScript="False" ErrorMessage="Введите пароль"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" >
                <asp:Button ID="ChangeButton" runat="server" Font-Size="20px" Text="Изменить данные" OnClick="ChangeButton_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" >
                <asp:Button ID="RegButton" runat="server" Font-Size="20px" Text="Зарегистрироваться" OnClick="RegButton_Click" />
            </td>
        </tr>

    </table> 
    </asp:Content>

