<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCampus.aspx.cs" Inherits="Presentation.WFCampu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-3">

        <div class="row">
            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4">
                <h2>Formulario de Sede</h2>
                <form>
                    <div class="mb-3">
                        <%--Nombre de Sede --%>
                        <asp:Label ID="Label6" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TBNombre" runat="server" type="text" class="form-control" placeholder="Nombre" autofocus></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Ciudad de Sede--%>
                        <asp:Label ID="Label7" runat="server" Text="Ciudad"></asp:Label>
                        <asp:TextBox ID="TBCiudad" runat="server" type="text" class="form-control" placeholder="Ciudad"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Telefono de Sede--%>
                        <asp:Label ID="Label8" runat="server" Text=" Telefono"></asp:Label>
                        <asp:TextBox ID="TBTelefono" runat="server" type="number" class="form-control" placeholder=" Telefono"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Direccion de Sede--%>
                        <asp:Label ID="Label9" runat="server" Text=" Direccion"></asp:Label>
                        <asp:TextBox ID="TBDireccion" runat="server" type="text" class="form-control" placeholder="Direccion "></asp:TextBox>
                    </div>


                    <div class="mb-3">
                        <%--Stock de Sede--%>

                        <asp:Label ID="Label10" runat="server" Text="Stock"></asp:Label>
                        <asp:DropDownList ID="DDLStock" runat="server" class="form-control" placeholder="Stock"></asp:DropDownList><br />

                    </div>


                    <div class="d-grid gap-2">
                        <%--Botonoes  Sede--%>
                        <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" BackColor="#009933" />
                        <asp:Button ID="BtnActualizar" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="BtnActualizar_Click" BackColor="#0000CC" /><br />

                        <%--Mensaje --%>
                        <asp:Label ID="LblMensaje" runat="server" Text="" Style="font-size: 0.9rem" BackColor="White" BorderColor="#66FF66" ForeColor="Black"></asp:Label>
                    </div>
                </form>
            </div>


            <%--Tabla--%>
            <div class="col-sm-12 col-md-8 col-lg-8 col-xl-8">
                <h2>Listado de Sede</h2>
                <asp:GridView ID="GVCampu" runat="server" class="table table-secondary table-striped bordered " OnSelectedIndexChanged="GVCampu_SelectedIndexChanged" OnRowDeleting="GVCampu_RowDeleting" OnRowDataBound="GVCampu_RowDataBound">

                    <Columns>
                        <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                        <asp:CommandField ShowDeleteButton="true"></asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>

        <asp:TextBox ID="TBid" runat="server"></asp:TextBox>
        <br />


    </div>
</asp:Content>
