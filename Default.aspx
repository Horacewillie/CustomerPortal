<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerPortal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   

    <div class="row">
      <div class ="form_container">
          
          <div class="container">
              Enter Id :  <asp:TextBox ID="id" runat="server" /><br />
          </div>
          <div class="container">
              Enter Name : <asp:TextBox ID="name" runat="server" /><br />
          </div>
          <div class="container">
              Enter Address: <asp:TextBox ID="address" runat="server" /><br />
          </div>
          <div class="container">
              Enter Account: <asp:TextBox ID="account" runat="server" /><br />
          </div>
          
          <asp:Button ID="button" Text ="Submit" runat="server" OnClick="button_Click" />

          <label id ="result" runat="server"></label>
          

              <asp:GridView runat="server" ID="dataTable"></asp:GridView>
          <asp:Button ID="Button1" Text="Update" runat="server" OnClick="Update"/>
          <asp:Button ID="Button2" Text="Delete" runat="server" OnClick="Delete"/>
          <asp:Button ID="Button4" Text="Clear" runat="server" OnClick="Clear"/>
      </div>
    </div>

</asp:Content>
