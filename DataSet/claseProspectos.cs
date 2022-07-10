using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prospectos.DataSet
{
    public class claseProspectos
    {

        public DataTable selProspecto()
        {
            DataTable dt = new dsProspectos.PROSPECTODataTable();
            dsProspectosTableAdapters.PROSPECTOTableAdapter ta = new dsProspectosTableAdapters.PROSPECTOTableAdapter();

            ta.Fill((dsProspectos.PROSPECTODataTable)dt);
            return dt;
        }

        public DataTable selProspectoPorID(int idprospecto)
        {
            DataTable dt = new dsProspectos.PROSPECTODataTable();
            dsProspectosTableAdapters.PROSPECTOTableAdapter ta = new dsProspectosTableAdapters.PROSPECTOTableAdapter();

            ta.FillByID((dsProspectos.PROSPECTODataTable)dt, idprospecto);
            return dt;
        }

        public void insProspecto(string nombre, string apaterno, string amaterno, string calle, string numero, string colonia, int cp, string telefono, string rfc, int estatus)
        {
            dsProspectosTableAdapters.PROSPECTOTableAdapter ta = new dsProspectosTableAdapters.PROSPECTOTableAdapter();

            ta.Insert1(nombre, apaterno, amaterno, calle, numero, colonia, cp, telefono, rfc, estatus, "NA");
        }

        public void insDoc(string ruta, string nombreDoc)
        {
            dsProspectosTableAdapters.DOCTableAdapter ta = new dsProspectosTableAdapters.DOCTableAdapter();
            ta.InsertDoc(ruta,nombreDoc);
        }

        public void updProspecto(int idestatus, int idprospecto, string observaciones)
        {
            dsProspectosTableAdapters.PROSPECTOTableAdapter ta = new dsProspectosTableAdapters.PROSPECTOTableAdapter();

            ta.Update1(idestatus,observaciones, idprospecto);
        }

    }
}