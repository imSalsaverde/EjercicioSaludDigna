<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="captura.aspx.cs" Inherits="prospectos.captura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="panelCaptura" CssClass="">
        <div class="container" style="margin-top: 1rem;">
            <div class="row">

                <div class="col-md-12 col-md-offset-5">
                    <h1>Nuevo prospecto</h1>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtNombre" placeholder="Nombre" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtaPaterno" placeholder="Apellido Paterno" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtaMaterno" placeholder="Apellido Materno" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtCalle" placeholder="Calle" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtNumero" placeholder="Numero" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtColonia" placeholder="Colonia" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtCP" placeholder="Codigo Postal" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtTelefono" placeholder="Telefono" class="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtRFC" placeholder="RFC" class="form-control" />
                    </div>
                    <div class="form-group">
                    </div>
                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                    <br />
                    <asp:Button Text="Enviar" runat="server" ID="btnEnviar" OnClick="btnEnviar_Click" />
                    <asp:Button Text="Salir" runat="server" ID="btnSalir" OnClick="btnSalir_Click" />
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="panelListado">
        <div class="container" style="margin-top: 1rem;">
            <div class="row">
                <div class="col-md-6">
                    <asp:Literal Text="" runat="server" ID="litLista" />
                    <asp:Button Text="Capturar nuevo prospecto" runat="server" ID="btnRegresar" OnClick="btnRegresar_Click" />
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label Text="Nombre:" runat="server" />
                        <asp:Label ID="lblNombre" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="Apellido Paterno:" runat="server" />
                        <asp:Label ID="lblApaterno" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="Apellido Materno:" runat="server" />
                        <asp:Label ID="lblAmaterno" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="Calle:" runat="server" />
                        <asp:Label ID="lblCalle" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="Numero:" runat="server" />
                        <asp:Label ID="lblNumero" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="Colonia:" runat="server" />
                        <asp:Label ID="lblColonia" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="CP:" runat="server" />
                        <asp:Label ID="lblCp" Text="" runat="server" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="Telefono:" runat="server" />
                        <asp:Label ID="lblTel" Text="" runat="server" />
                    </div>

                    <div class="form-group">
                        <asp:Label Text="RFC:" runat="server" />
                        <asp:Label ID="lblRfc" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="Estatus:" runat="server" />
                        <asp:Label ID="lblEstatus" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="Observaciones:" runat="server" />
                        <asp:Label ID="lblObservaciones" Text="" runat="server" />

                    </div>
                    <div class="form-group">
                        <asp:Label Text="Documentos:" runat="server" />
                        <a id="link">
                            <asp:Label ID="lblNombreDoc" Text="" runat="server" /></a>
                    </div>




                </div>
            </div>

        </div>
    </asp:Panel>
    <script>
        function selProspectoPorID(id) {
            document.getElementById('MainContent_lblNombre').textContent = document.getElementById(id).childNodes[0].innerHTML;
            document.getElementById('MainContent_lblApaterno').textContent = document.getElementById(id).childNodes[1].innerHTML;
            document.getElementById('MainContent_lblAmaterno').textContent = document.getElementById(id).childNodes[2].innerHTML;
            document.getElementById('MainContent_lblCalle').textContent = document.getElementById(id).childNodes[4].innerHTML;
            document.getElementById('MainContent_lblNumero').textContent = document.getElementById(id).childNodes[5].innerHTML;
            document.getElementById('MainContent_lblColonia').textContent = document.getElementById(id).childNodes[6].innerHTML;
            document.getElementById('MainContent_lblCp').textContent = document.getElementById(id).childNodes[7].innerHTML;
            document.getElementById('MainContent_lblTel').textContent = document.getElementById(id).childNodes[8].innerHTML;
            document.getElementById('MainContent_lblRfc').textContent = document.getElementById(id).childNodes[9].innerHTML;
            document.getElementById('MainContent_lblEstatus').textContent = document.getElementById(id).childNodes[3].innerHTML;
            document.getElementById('MainContent_lblObservaciones').textContent = document.getElementById(id).childNodes[12].innerHTML;

            document.getElementById('MainContent_lblNombreDoc').textContent = document.getElementById(id).childNodes[10].innerHTML;
            document.getElementById('link').href = document.getElementById(id).childNodes[11].innerHTML;
        }

    </script>
</asp:Content>
