<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFStock.aspx.cs" Inherits="Presentation.WFStock" %>


<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-3">

        <div class="row">
            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4">
                <h2>Formulario de Stock</h2>
                <form>
                    <div class="mb-3">
                        <%--Tipo de Presentacion --%>
                        <asp:Label ID="Label1" runat="server" Text="Cantidad"></asp:Label>
                        <asp:TextBox ID="TBCantidad" runat="server" type="text" class="form-control" placeholder="Cantidad" autofocus></asp:TextBox>
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
                <h2>Listado de Stock</h2>                
               
         <asp:GridView ID="GVStock" runat="server" class="table table-secondary table-striped bordered " OnSelectedIndexChanged="GVStock_SelectedIndexChanged" OnRowDeleting="GVStock_RowDeleting" OnRowDataBound="GVStock_RowDataBound1">
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
