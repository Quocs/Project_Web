<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="giohang.aspx.cs" Inherits="Project_Web.giohang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="483px">
        <Columns>
            <asp:TemplateField HeaderText="MA HANG">
                
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("mahang") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TEN HANG">
               
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("tenhang") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DON GIA">
                
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("dongia") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SO LUONG">
                
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("soluong") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="THANH TIEN">
                
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("thanhtien") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" ></asp:Label>
</asp:Content>
