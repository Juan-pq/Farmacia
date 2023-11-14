<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFMedicine_has_lab.aspx.cs" Inherits="Presentation.WFMedicine_has_lab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-3">

        <div class="row">
            <div class="col-sm-12 col-md-4 col-lg-4 col-xl-4">
                <h2>Formulario de Presentación</h2>
                <form>
                    <div class="mb-3">
                        <%--hora de creacion _MedicamentosHasLaboratorio --%>
                        <asp:Label ID="Label4" runat="server" Text="Hora de creacion"></asp:Label>
                        <asp:TextBox ID="TBHoracreacion" runat="server" type="number" class="form-control" placeholder="Hora de creacion" autofocus></asp:TextBox>

                    </div>

                    <div class="mb-3">


                        <%--MedicamentosHasLaboratorioDDLLaboratorio--%>
                        <asp:Label ID="Label5" runat="server" Text="Laboratorio"></asp:Label>
                        <asp:DropDownList ID="DDLLaboratorio" runat="server" class="form-control" placeholder="Laboratorio"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <%--MedicamentosHasLaboratorioDDLStock--%>
                        <asp:Label ID="Label6" runat="server" Text="Stock"></asp:Label>
                        <asp:DropDownList ID="DDLStock" runat="server" class="form-control" placeholder="Stock"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <%-- MedicamentosHasLaboratorioDDLPresentation --%>
                        <asp:Label ID="Label1" runat="server" Text="Presentation "></asp:Label>
                        <asp:DropDownList ID="DDLPresentation" runat="server" class="form-control" placeholder="Presentation"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <%-- MedicamentosHasLaboratorioDDLMedicamentos --%>
                        <asp:Label ID="Label2" runat="server" Text="Medicamentos "></asp:Label>
                        <asp:DropDownList ID="DDLMedicamentos" runat="server" class="form-control" placeholder="DDLMedicamentos"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <%-- MedicamentosHasLaboratorioDDLMedicamentos --%>
                        <asp:Label ID="Label3" runat="server" Text="Therapeuticaction "></asp:Label>
                        <asp:DropDownList ID="DDLTherapeuticaction" runat="server" class="form-control" placeholder="DDLTherapeuticaction"></asp:DropDownList>
                    </div>


                    <div class="d-grid gap-2">
                        <%--Botones--%>
                        <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click1" BackColor="#009933" />
                        <asp:Button ID="BtnActualizar" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="BtnActualizar_Click1" BackColor="#0000CC" />

                        <%--Mensaje --%>
                        <asp:Label ID="LblMensaje" runat="server" Text="" Style="font-size: 0.9rem" BackColor="White" BorderColor="#66FF66" ForeColor="Black"></asp:Label>
                    </div>
                </form>
            </div>


            <%--Tabla--%>
            <div class="col-sm-12 col-md-8 col-lg-8 col-xl-8">
                <h2>Listado de MedicamentosHasLab</h2>
                <asp:GridView ID="GVMedicamentosHasLab" runat="server" class="table table-secondary table-striped bordered " OnSelectedIndexChanged="GVMedicamentosHasLab_SelectedIndexChanged" OnRowDeleting="GVMedicamentosHasLab_RowDeleting" OnRowDataBound="GVMedicamentosHasLab_RowDataBound">

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
