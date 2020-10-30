<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="chitiet.aspx.cs" Inherits="Project_Web.chitiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 112%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <table class="auto-style1">
                <tr>
                    <td rowspan="2" colspan="3">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#"~/IMG/"+ Eval("hinh") %>' Width="200px" />
                    </td>
                    <td colspan="3">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("tenhang") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        SO LUONG<asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="124px"></asp:TextBox>
                        &nbsp;<asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("mahang") %>' OnClick="Button2_Click" Text="MUA HANG" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("dongia") %>'></asp:Label>
                    </td>
                    <td colspan="3">
                        
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
