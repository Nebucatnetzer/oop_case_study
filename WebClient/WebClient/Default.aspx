<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Webclient for EHEC</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            
            Create a new Person via WebService<br />
            <br />
            <asp:TextBox ID="txtSalutation" runat="server"></asp:TextBox>
&nbsp;Salutation<br />
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
&nbsp;First Name<br />
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
&nbsp;Last Name<br />
            <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
&nbsp;Gender<br />
            <asp:TextBox ID="txtStreetName" runat="server"></asp:TextBox>
&nbsp;Street Name<br />
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
&nbsp;City<br />
            <br />
            
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnSubmitPerson" runat="server" OnClick="btnSubmitPerson_Click" Text="Button" />
        </div>
        </div>

</asp:Content>
