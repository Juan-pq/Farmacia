<%@ Page Title="" Language="C#" MasterPageFile="~/MainUsu.Master" AutoEventWireup="true" CodeBehind="WFMedicineUsu.aspx.cs" Inherits="Presentation.WFMedicineUsu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container my-3">

        <div class="row">
            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4">
                <h2>Formulario de Medicamento</h2>
                <form>
                    <div class="mb-3">
                        <%--Nombre de Medicamento --%>
                        <asp:Label ID="Label10" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TBNombre" runat="server" type="text" class="form-control" placeholder="Nombre" autofocus></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Precio de Medicamento --%>
                        <asp:Label ID="Label11" runat="server" Text="Precio"></asp:Label>
                        <asp:TextBox ID="TBPrecio" runat="server" type="number" class="form-control" placeholder="Precio"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Descripción de Medicamento --%>
                        <asp:Label ID="Label12" runat="server" Text="TBDescripcion"></asp:Label>
                        <asp:TextBox ID="TBDescripcion" runat="server" type="text" class="form-control" placeholder="Descripcion"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Composición de Medicamento --%>
                        <asp:Label ID="Label13" runat="server" Text="Composicion"></asp:Label>
                        <asp:TextBox ID="TBComposicion" runat="server" type="number" class="form-control" placeholder="Composicion"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Precauciones de Medicamento --%>
                        <asp:Label ID="Label14" runat="server" Text="Precauciones"></asp:Label>
                        <asp:TextBox ID="TBPrecauciones" runat="server" type="text" class="form-control" placeholder="Precauciones"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Cantidad de Medicamento --%>
                        <asp:Label ID="Label15" runat="server" Text="Cantidad"></asp:Label>
                        <asp:TextBox ID="TBCantidad" runat="server" type="number" class="form-control" placeholder="Cantidad"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%-- accioterapeuta disponibles--%>
                        <asp:Label ID="Label16" runat="server" Text="Accion terapeuta"></asp:Label>
                        <asp:DropDownList ID="DDLTherapeuticaction" runat="server"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <%-- presentacion disponibles--%>
                        <asp:Label ID="Label17" runat="server" Text="DDLPresentation"></asp:Label>
                        <asp:DropDownList ID="DDLPresentation" runat="server"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <%-- stock disponibles--%>
                        <asp:Label ID="Label18" runat="server" Text="Stock"></asp:Label>
                        <asp:DropDownList ID="DDLStock" runat="server"></asp:DropDownList>
                    </div>

                    <div class="d-grid gap-2">
                        <%--Botonoes  Medicamento--%>
                        <asp:Button ID="BtnGuardar1" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click1" BackColor="#009933" />
                        <asp:Button ID="BtnActualizar1" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="BtnActualizar_Click1" BackColor="#0000CC" /><br />

                        <%--Mensaje --%>
                        <asp:Label ID="LblMensaje" runat="server" Text="" Style="font-size: 0.9rem" BackColor="White" BorderColor="#66FF66" ForeColor="Black"></asp:Label>
                    </div>
                </form>
            </div>


            <%--Tabla--%>
            <div class="col-sm-12 col-md-8 col-lg-8 col-xl-8">
                <h2>Listado de Medicamento</h2>
                <asp:GridView ID="GVMedicamentos" runat="server" class="table table-secondary table-striped bordered " OnSelectedIndexChanged="GVMedicamentos_SelectedIndexChanged" OnRowDeleting="GVMedicamentos_RowDeleting" OnRowDataBound="GVMedicamentos_RowDataBound">

                    <Columns>
                        <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                        <asp:CommandField ShowDeleteButton="true"></asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>

        <asp:TextBox ID="TBid" runat="server"></asp:TextBox>


    </div>



</asp:Content>
