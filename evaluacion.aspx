<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="evaluacion.aspx.cs" Inherits="prospectos.evaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:Literal ID="litTablaEvaluacion" Text="text" runat="server" />
    </div>

    <%--modal--%>
    <div class="modal" tabindex="-1" role="dialog" id="myModal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <%--<asp:Label Text="ID Prospecto" runat="server" for="txtIdProspecto"/>--%>
                    <asp:TextBox runat="server" ID="txtIdProspecto" Style="display: none" />

                    <%--<asp:Label Text="Estatus" runat="server" for="txtIdProspecto"/>--%>
                    <asp:TextBox runat="server" ID="txtIdEstatus" Style="display: none" />

                    <div class="form-group">
                        <asp:Label Text="Observaciones" runat="server" for="txtObservaciones" />
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtObservaciones" TextMode="MultiLine" />

                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button Text="Enviar" runat="server" ID="btnObservaciones" OnClick="btnObservaciones_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%--modal--%>
    <script>
        function enviarEstatus(idprospecto, idestatus) {
            //document.getElementById('MainContent_lblNombre').textContent = document.getElementById(id).childNodes[0].innerHTML;
            document.getElementById('MainContent_txtIdProspecto').value = idprospecto;
            document.getElementById('MainContent_txtIdEstatus').value = idestatus;
        }
        function enviarEstatusAutorizado(idprospecto, idestatus) {
            document.getElementById('MainContent_txtObservaciones').value = "";
            document.getElementById('MainContent_txtIdProspecto').value = idprospecto;
            document.getElementById('MainContent_txtIdEstatus').value = idestatus;
            document.getElementById('MainContent_btnObservaciones').click();

        }
    </script>
</asp:Content>
