<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUsers.aspx.cs" Inherits="Presentation.WFUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
        <%--<asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
        <asp:TextBox ID="TBEstado" runat="server"></asp:TextBox><br /><br />--%>
        <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
        <asp:DropDownList ID="DDLState" runat="server">
            <asp:ListItem Value="0">Seleccione</asp:ListItem>
            <asp:ListItem Value="Activo">Activo</asp:ListItem>
            <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
        </asp:DropDownList><br />

        <%--Botonoes  Usuario--%>
        <asp:Button ID="BtnGuardar" runat="server" cssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" BackColor="#009933" />
        <asp:Button ID="BtnActualizar" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="BtnActualizar_Click" BackColor="#0000CC" /><br /><br />
        
        <%--Mensaje --%>
        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label>

        







        <%--Id--%>
         <%--<asp:Label ID="LblId" runat="server" Text=""></asp:Label>--%><br />

        <%--Correo--%>
        <%--<asp:Label ID="Label1" runat="server" Text="Ingrese el correo"></asp:Label>--%>
        <%--<asp:TextBox ID="TBMail" runat="server" TextMode="Email"></asp:TextBox>--%><br />

        <%--Contraseña--%>
        <%--<asp:Label ID="Label2" runat="server" Text="Ingrese la contraseña"></asp:Label>--%>
        <%--<asp:TextBox ID="TBContrasena" runat="server" TextMode="Password"></asp:TextBox>--%><br />

         <%--Salt del Usuario--%>
      <%--  <asp:Label ID="Label4" runat="server" Text="Salt"></asp:Label>
        <asp:TextBox ID="TBSalt" runat="server"></asp:TextBox><br /><br />--%>

        <%--Estados--%>
     <%--    <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
        <asp:DropDownList ID="DDLState" runat="server">
            <asp:ListItem Value="0">Seleccione</asp:ListItem>
            <asp:ListItem Value="Activo">Activo</asp:ListItem>
            <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
        </asp:DropDownList><br />--%>

        <%--Botones--%>
 <%--       <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="BtnUpdate_Click" />--%>

        <%--Mensaje--%>
<%--        <asp:Label ID="LblMsj" runat="server" Text=""></asp:Label><br />--%>

        <%--Tabla--%>
        <asp:GridView ID="GVUsers" runat="server" AutoGenerateColumns="False"
            OnSelectedIndexChanged="GVUsers_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="usu_id" HeaderText="Id" />
                <asp:BoundField DataField="usu_correo" HeaderText="Correo" />
                <asp:BoundField DataField="usu_contrasena" HeaderText="Contraseña" />
                <asp:BoundField DataField="usu_salt" HeaderText="Salt" />
                <asp:BoundField DataField="usu_estado" HeaderText="Estado" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
