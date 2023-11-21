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
    Instructors:</p>
<p>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
    <br />
</p>
<p>
</p>
</asp:Content>
