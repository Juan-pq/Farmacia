<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Farmacia</title>

    <%--Bootstrap CSS--%>
    <link href="resources/css/bootstrap.min.css" rel="stylesheet" />

</head>
<body class="bg-info d-flex justify-content-center align-items-center vh-100">
    <body background="" bgcolor="87CEEB">

    <form id="form1" runat="server" class="row g-3 needs-validation" novalidate>


        <div class="bg-white p-5 rounded-3 text-secondary shadow"
            style="width: 25rem">


            <%--imagen login--%>
            <div class="d-flex justify-content-center">
                <img
                    src="resources/img/FUP-40.png"
                    alt="login-icon"
                    style="height: 7rem" />
            </div>
            <div class="text-center fs-1 fw-bold">Login</div>

            <%--usuario--%>
            <div class="input-group mt-4 position-relative">
                <div class="input-group-text bg-info">
                    <img
                        src="resources/img/username-icon.png"
                        alt="username-icon"
                        style="height: 1rem" />
                </div>
                <asp:TextBox ID="TBCorreo" runat="server" CssClass="form-control bg-light" type="text" placeholder="correo" required></asp:TextBox><br />
                <%--Validacion caja de texto correo--%>
                <div class="invalid-tooltip fst-italic" style="font-size: 0.9rem">
                    Ingresar correo
                </div>
            </div>

            <%--password--%>
            <div class="input-group mt-4 position-relative">
                <div class="input-group-text bg-info">
                    <img
                        src="resources/img/password-icon.png"
                        alt="password-icon"
                        style="height: 1rem" />
                </div>
                <asp:TextBox ID="TBContrasena" runat="server" CssClass="form-control bg-light" type="password" placeholder="Password" required></asp:TextBox><br />
                <%--Validacion caja de texto contraseña--%>
                <div class="invalid-tooltip fst-italic" style="font-size: 0.9rem">
                    Ingresar contraseña
                </div>
            </div>

            <div class="d-flex justify-content-around mt-4">
                <div class="d-flex align-items-center gap-1">
                    <input class="form-check-input" type="checkbox" />
                    <div class="p-1" style="font-size: 0.9rem">Recordar</div>
                </div>
                <div class="pt-1">
                    <a href="#" class="text-decoration-none text-info fst-italic" style="font-size: 0.9rem">¿Olvidaste tu contraseña?</a>
                </div>
            </div>

            <%--mensaje campos invalidos--%>           
            <asp:Label ID="LblMsg" runat="server" Text="" Style="font-size: 0.9rem" BackColor="White" BorderColor="#66FF66" ForeColor="Red"></asp:Label>

            <%--Boton Iniciar--%>
            <asp:Button ID="BtIniciar" runat="server" CssClass="btn btn-info text-white w-100 mt-4 fw-bold shadow-sm" Text="Iniciar" OnClick="BtIniciar_Click" /><br />
            <div class="d-flex gap-1 justify-content-center mt-1">
                <div>¿No tiene una cuenta?</div>
                <a href="#" class="text-decoration-none text-info fw-bold">Registrar</a>
            </div>
            <%--contenedor para la letra o--%>
            <div class="p-3">
                <div class="border-bottom text-center" style="height: 0.9rem">
                    <span class="bg-white px-3">o</span>
                </div>
            </div>
            <%--boton continuar con google--%>
            <div class="btn d-flex gap-2 justify-content-center border mt-3 shadow-sm">
                <img
                    src="resources/img/google-icon.png"
                    alt="google-icon"
                    style="height: 1.6rem" />
                <div class="fw-bold text-secondary">continuar con google</div>


            </div>






        </div>
    </form>

    <%--scrip de javaScrip para que funcione la validacion--%>
    <script>
        // Example starter JavaScript for disabling form submissions if there are invalid fields
        (function () {
            'use strict'

            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.querySelectorAll('.needs-validation')

            // Loop over them and prevent submission
            Array.prototype.slice.call(forms)
                .forEach(function (form) {
                    form.addEventListener('submit', function (event) {
                        if (!form.checkValidity()) {
                            event.preventDefault()
                            event.stopPropagation()
                        }

                        form.classList.add('was-validated')
                    }, false)
                })
        })()

    </script>

</body>
</html>
