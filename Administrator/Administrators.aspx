<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administrators.aspx.cs" Inherits="Assignment4.Administrator.Administrators" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Members:</p>
<p>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</p>
    <p>
        Add new member:</p>
    <p>
        Username:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</p>
    <p>
        Password:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</p>
    <p>
        First name:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</p>
    <p>
        Last name:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
</p>
    <p>
        Phone number:
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
</p>
    <p>
        Email:
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
</p>
    <p>
        Section:
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="500.00">Karate Age-Uke</asp:ListItem>
            <asp:ListItem Value="600.00">Karate Chudan-Uke</asp:ListItem>
        </asp:DropDownList>
</p>
    <p>
        InstructorID:
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Submit" />
</p>
    <p>
        Delete Student with ID:
        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
</p>
<p>
    Instructors:</p>
<p>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
</p>
    <p>
        Add new instructor:</p>
    <p>
        Username:
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
</p>
    <p>
        Password:
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
</p>
    <p>
        First name:
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
</p>
    <p>
        Last name:
        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
</p>
    <p>
        Phone number:
        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Submit" />
    <br />
</p>
<p>
</p>
</asp:Content>
