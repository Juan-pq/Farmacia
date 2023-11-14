<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFUser.aspx.cs" Inherits="Presentation.WFUser" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

     
        <div>

        <asp:TextBox ID="TBid" runat="server"></asp:TextBox>
        <br />

     
        <%--Correo del Usuario--%>
        <asp:Label ID="Label1" runat="server" Text="Correo"></asp:Label>
        <asp:TextBox ID="TBCorreo" runat="server"></asp:TextBox><br />

        <%--Contraseña del Usuario--%>
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
        <asp:TextBox ID="TBContrasena" runat="server"></asp:TextBox><br />

        <%--Salt del Usuario--%>
        <asp:Label ID="Label3" runat="server" Text="Salt"></asp:Label>
        <asp:TextBox ID="TBSalt" runat="server"></asp:TextBox><br /><br />

        <%--Estado del Usuario--%>
        <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
        <asp:TextBox ID="TBEstado" runat="server"></asp:TextBox><br /><br />

        <%--Botonoes  Usuario--%>
        <asp:Button ID="BtnGuardar" runat="server" cssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" BackColor="#009933" />
        <asp:Button ID="BtnActualizar" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="BtnActualizar_Click" BackColor="#0000CC" /><br /><br />
        
        <%--Mensaje --%>
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>

        <%--Tabla--%>

            <asp:GridView ID="GVUser" runat="server" OnRowDataBound="GVUser_RowDataBound" OnRowDeleting="GVUser_RowDeleting" OnSelectedIndexChanged="GVUser_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                <asp:CommandField ShowDeleteButton="true" ></asp:CommandField>
                </Columns>
            
        </asp:GridView>
    </div>
    </form>
</body>
</html>
</asp:Content>
