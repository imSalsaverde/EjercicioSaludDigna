using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace prospectos
{
    public partial class captura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panelCaptura.Visible = false;
            tablaProspecto();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtaPaterno.Text != "" || txtaMaterno.Text != "" || txtCalle.Text != "" || txtNombre.Text != "" || txtColonia.Text != ""
    || txtCP.Text != "" || txtTelefono.Text != "" || txtRFC.Text != "")
            {
                insertaProspecto(txtNombre.Text, txtaPaterno.Text, txtaMaterno.Text, txtCalle.Text, txtNumero.Text, txtColonia.Text, Convert.ToInt16(txtCP.Text), txtTelefono.Text, txtRFC.Text);
                insertaDoc();
                tablaProspecto();
                limpiaCampos();

            }
            else { return; }
            panelCaptura.Visible = false;
            panelListado.Visible = true;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" ||txtaPaterno.Text!="" || txtaMaterno.Text != "" || txtCalle.Text != "" || txtNombre.Text != "" || txtColonia.Text != ""
                || txtCP.Text != "" || txtTelefono.Text != "" || txtRFC.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea salir sin guardar los cambios?", "Descartar Cambios", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    panelCaptura.Visible = false;
                    panelListado.Visible = true;
                    limpiaCampos();

                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
            }
            else
            {
                panelCaptura.Visible = false;
                panelListado.Visible = true;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            panelCaptura.Visible = true;
            panelListado.Visible = false;
        }

        private void insertaProspecto(string nombre, string apaterno, string amaterno, string calle, string numero, string colonia, int cp, string telefono, string rfc)
        {
            var prospectos = new DataSet.claseProspectos();
            prospectos.insProspecto(nombre, apaterno, amaterno, calle,
                 numero, colonia, cp, telefono, rfc, 1);
        }

        private void insertaDoc()
        {
            var prospectos = new DataSet.claseProspectos();
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string nombreArchivo = Path.GetFileName(FileUploadControl.FileName);
                    string ruta = (Server.MapPath("~/Archivos") + "/" + nombreArchivo).ToString();
                    FileUploadControl.SaveAs(Server.MapPath("~/Archivos") + "/" + nombreArchivo);
                    prospectos.insDoc(ruta, nombreArchivo);
                    //StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    //StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }

        }

        private void tablaProspecto()
        {
            var prospectos = new DataSet.claseProspectos();
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            dt = prospectos.selProspecto();
            int r = 0;
            foreach (var row in dt.Rows)
            {
                r += 1;
            }
            if (r > 0)
            {
                sb.Append("<table class='table table-hover'>");
                sb.Append("<thead><tr> <th>Nombre</th> <th>Apellido Paterno</th> <th>Apellido Materno</th> <th>Estatus</th> <th></th> </tr></thead>");
                sb.Append("<tbody>");
                for (int i = 0; i < r; i++)
                {

                    sb.Append("<tr id="+ dt.Rows[i]["idProspecto"] + " onclick=selProspectoPorID(" + dt.Rows[i]["idProspecto"] + ")>");
                    sb.Append("<td>" + dt.Rows[i]["Nombre"] + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["aPaterno"] + "</td>");
                    sb.Append("<td>" + dt.Rows[i]["aMaterno"] + "</td>");
                    if (Convert.ToInt16(dt.Rows[i]["Estatus"]) == 1)
                    {
                        sb.Append("<td>Enviado</td>");
                    }
                    else if (Convert.ToInt16(dt.Rows[i]["Estatus"]) == 2)
                    {
                        sb.Append("<td>Autorizado</td>");
                    }
                    else
                    {
                        sb.Append("<td>Rechazado</td>");
                    }                  
                    //sb.Append($"<td><div class='btn btn-primary' onclick=selUpdAlumno(" + dt.Rows[i]["idAlumno"] + ")>Editar</div></td>");
                    //sb.Append("<td><div class='btn btn-primary' onclick='delAlumno(" + dt.Rows[i]["idAlumno"] + ")'>Borrar</div></td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["Calle"] + "</td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["Numero"] + "</td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["Colonia"] + "</td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["CP"] + "</td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["Telefono"] + "</td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["RFC"] + "</td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["Nombre1"] + "</td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["RutaDoc"] + "</td>");
                    sb.Append("<td style='display:none'>" + dt.Rows[i]["Observaciones"] + "</td>");



                    sb.Append("<td><div class='button' data-toggle='modal' data-target='#modalInfoProspecto'>Seleccionar</div></td>");
                    sb.Append("</tr>");

                }
                sb.Append("</tbody>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append("<h1>Sin registros disponibles</h1>");
            }
            litLista.Text = sb.ToString();
        }

        private void limpiaCampos()
        {
            txtNombre.Text = "";
            txtaPaterno.Text = "";
            txtaMaterno.Text = "";
            txtCalle.Text = "";
            txtNumero.Text = "";
            txtColonia.Text = "";
            txtCP.Text = "";
            txtTelefono.Text = "";
            txtRFC.Text = "";
        }

        protected void btnSelInfoProspecto_Click(object sender, EventArgs e)
        {
            panelCaptura.Visible = false;
            panelListado.Visible = true;
        }

    }
}