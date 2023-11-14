<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUsu.aspx.cs" Inherits="Presentation.IndexUsu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Farmacia</title>
    <%--Bootstrap CSS--%>
    <link href="resources/css/bootstrap.min.css" rel="stylesheet" />


</head>
    <body background="resources/img/farma.jpg" bgcolor="FFCECB">

    
    <form id="form1" runat="server">

        <main>
            <section>
                <nav nav class="navbar navbar-expand-lg navbar-dark bg-primary">
                    <div class="container-fluid">
                        <header>
                            <img src="resources/img/tienda.png" />
                        </header>
                        <a class="navbar-brand" href="#">Farmacia</a>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup"
                            aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                            <div class="navbar-nav">
                                <a class="nav-link active" aria-current="page" href="IndexUsu.aspx">Inicio</a>                                                                
                                <a class="nav-link" href="WFMedicineUsu.aspx">Medicamentos</a>
                                <a class="nav-link" href="WFPresentation.aspx">Presentacion</a>
                                <a class="nav-link" href="WFTherapeuticAction.aspx">AccionTerapeutica</a>                               
                                <a class="nav-link close bg-info text-white rounded p-2" aria-label="close" href="Default.aspx">Cerrar sesión</a> 


                            </div>
                        </div>
                    </div>
                </nav>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-12 ">
                            <%--<img src="resources/img/farma.jpg" />--%>
                        </div>
                    </div>
                </div>
            </section>
        </main>

    </form>




</body>


</html>
