<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Photos.aspx.cs" Inherits="MyTest.Photos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1><asp:Label runat="server" ID="lbl_Titulo"></asp:Label></h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Fotos</h2>

            <asp:GridView ID="gdv_Photos" runat="server" AutoGenerateColumns="False" OnRowCommand="gdv_Photos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="AlbumId" HeaderText="AlbumId" Visible="False" />
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="True" />
                    <asp:BoundField DataField="Url" HeaderText="" Visible="false" />
                    <asp:BoundField DataField="ThumbnailUrl" HeaderText="" Visible="false" />
                    <asp:BoundField DataField="Title" HeaderText="Titulo" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ThumbnailUrl") %>' style="width:100px;height:100px;"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:buttonfield buttontype="Button" commandname="View" headertext="" text="Ver Comentarios"/>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-4">
            <h2>Comentarios</h2>

            <asp:GridView runat="server" ID="gdv_Comments" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="PostId" HeaderText="PostId" Visible="False" />
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:TemplateField HeaderText="Comentario">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Body") %>' >
                            </asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
