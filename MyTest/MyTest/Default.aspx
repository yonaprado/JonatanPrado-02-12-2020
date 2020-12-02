<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Albums</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Lista de albums</h2>

            <asp:GridView ID="gdv_Album" runat="server" OnRowCommand="gdv_Album_RowCommand" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="userId" HeaderText="UserId" SortExpression="userId" Visible="false" />
                    <asp:BoundField DataField="id" HeaderText="Id" SortExpression="id" Visible="true" />
                    <asp:BoundField DataField="title" HeaderText="Titulo" SortExpression="title" />
                    <asp:buttonfield buttontype="Button" commandname="View" headertext="" text="Visualizar Album"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
