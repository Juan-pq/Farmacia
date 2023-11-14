<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFPresentation.aspx.cs" Inherits="Presentation.WFPresentacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-3">

        <div class="row">
            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4">
                <h2>Formulario de Presentación</h2>
                <form>
                    <div class="mb-3">
                        <%--Tipo de Presentacion --%>
                        <asp:Label ID="Label1" runat="server" Text="Tipo"></asp:Label>
                        <asp:TextBox ID="TBTipo" runat="server" type="text" class="form-control" placeholder="Tipo" autofocus></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Cantidad de Presentacion--%>
                        <asp:Label ID="Label2" runat="server" Text="Cantidad"></asp:Label>
                        <asp:TextBox ID="TBCantidad" runat="server" type="number" class="form-control" placeholder="Cantidad"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--PrecioUnidad de Presentacion--%>
                        <asp:Label ID="Label3" runat="server" Text="Precio unidad"></asp:Label>
                        <asp:TextBox ID="TBPreciounidad" runat="server" type="number" class="form-control" placeholder="Precio unidad"></asp:TextBox>
                    </div>

                    <div class="d-grid gap-2">
                        <%--Botonoes  Presentacion--%>
                        <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" BackColor="#009933" />
                        <asp:Button ID="BtnActualizar" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="BtnActualizar_Click" BackColor="#0000CC" /><br />
                        
                        <%--Mensaje --%>
                        <asp:Label ID="LblMsj" runat="server" Text="" Style="font-size: 0.9rem" BackColor="White" BorderColor="#66FF66" ForeColor="Black"></asp:Label>
                    </div>
                </form>
            </div>


            <%--Tabla--%>
            <div class="col-sm-12 col-md-8 col-lg-8 col-xl-8">
                <h2>Listado de presentación</h2>                
                <asp:GridView ID="GVPresentacion" runat="server" class="table table-secondary table-striped bordered " OnSelectedIndexChanged="GVPresentacion_SelectedIndexChanged" OnRowDeleting="GVPresentacion_RowDeleting" OnRowDataBound="GVPresentacion_RowDataBound">
                   
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
