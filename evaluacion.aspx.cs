using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prospectos
{
    public partial class evaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tablaEvaluacion();
        }

        private void tablaEvaluacion()
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
                sb.Append("<thead><tr> <th>Nombre</th> <th>Apellido Paterno</th> <th>Apellido Materno</th> <th>Estatus</th> <th>Calle</th>  <th>Numero</th>" +
                    " <th>Colonia</th> <th>CP</th> <th>Telefono</th> <th>RFC</th>  <th>Observaciones</th> <th></th> </tr></thead>");
                sb.Append("<tbody>");
                for (int i = 0; i < r; i++)
                {

                    sb.Append("<tr id=" + dt.Rows[i]["idProspecto"] + ">");
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
                    sb.Append("<td >" + dt.Rows[i]["Calle"] + "</td>");
                    sb.Append("<td >" + dt.Rows[i]["Numero"] + "</td>");
                    sb.Append("<td >" + dt.Rows[i]["Colonia"] + "</td>");
                    sb.Append("<td >" + dt.Rows[i]["CP"] + "</td>");
                    sb.Append("<td >" + dt.Rows[i]["Telefono"] + "</td>");
                    sb.Append("<td >" + dt.Rows[i]["RFC"] + "</td>");
                    sb.Append("<td >" + dt.Rows[i]["Observaciones"] + "</td>");
                    sb.Append("<td ><div class='btn btn-primary' onclick='enviarEstatusAutorizado(" + dt.Rows[i]["idProspecto"] + ",2)'>Autorizar</div></td>");
                    sb.Append("<td ><div class='btn btn-danger' data-toggle='modal' data-target='#myModal' onclick='enviarEstatus("+ dt.Rows[i]["idProspecto"] + ",3)'>Rechazar</div></td>");


                    sb.Append("</tr>");

                }
                sb.Append("</tbody>");
                sb.Append("</table>");
            }
            else
            {
                sb.Append("<h1>Sin registros disponibles</h1>");
            }
            litTablaEvaluacion.Text = sb.ToString();
        }

        private void actualuzaEstatus(int idestatus, int idprospecto, string observaciones)
        {
            var prospectos = new DataSet.claseProspectos();
            string obs = "";
            if (observaciones == "")
            {
                obs = "NA";
            }
            else
            {
                obs = observaciones;
            }
             prospectos.updProspecto(idestatus, idprospecto, obs);
            tablaEvaluacion();
        }


        protected void btnObservaciones_Click(object sender, EventArgs e)
        {
            actualuzaEstatus(Convert.ToInt16(txtIdEstatus.Text),Convert.ToInt16(txtIdProspecto.Text), txtObservaciones.Text);
            tablaEvaluacion();
        }
    }
}