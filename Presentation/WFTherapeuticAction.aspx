<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFTherapeuticAction.aspx.cs" Inherits="Presentation.WFTherapeuticAction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

            <div class="container my-3">

        <div class="row">
            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4">
                <h2>Formulario De Accion Terapeutica</h2>
                <form>
                    <div class="mb-3">
                        <%--Tipo de Presentacion --%>
                        <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TBNombre" runat="server" type="text" class="form-control" placeholder="Nombre" autofocus></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <%--Cantidad de Presentacion--%>
                        <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox ID="TBDescripcion" runat="server" type="number" class="form-control" placeholder="Descripcion"></asp:TextBox>
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
                <h2>Listado de Accionterapeuta</h2>                
                <asp:GridView ID="GVAccionterapeuta" runat="server" class="table table-secondary table-striped bordered " OnSelectedIndexChanged="GVAccionterapeuta_SelectedIndexChanged" OnRowDeleting="GVAccionterapeuta_RowDeleting" OnRowDataBound="GVAccionterapeuta_RowDataBound">
                   
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
