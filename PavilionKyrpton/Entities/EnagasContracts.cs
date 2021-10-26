using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionKyrpton.Entities
{
    public class EnagasFile
    {
        public int Id { get; set; }

        public int FileId { get; set; }

        public FileClass File { get; set; }

        public string CodigoContrato { get; set; }

        public string CodigoAdenda { get; set; }

        public DateTime FechaFormalizacion { get; set; }

        public  string Origen { get; set; }

        public string NumeroSolicitud { get; set; }

        public string Comercializador { get; set; }

        public string Servicio { get; set; }

        public string MateriaPrima { get; set; }

        public string NaturalezaCapacidad { get; set; }

        public string Coordinacion { get; set; }

        public string SentidoFlujo { get; set; }

        public string Operador { get; set; }

        public string TipoInfrastructura { get; set; }

        public string Infrastructura { get; set; }

        public string TipoDuracion { get; set; }

        public DateTime InicioContracto { get; set; }

        public DateTime FinContracto { get; set; }

        public int Duracion_horas { get; set; }
        public decimal QTotalContratada_Volume { get; set; }

        public string QTotalContratada_Units { get; set; }

        public decimal QFirmeContratada_Volume { get; set; }

        public string QFirmeContratada_Units { get; set; }

        public decimal QIntContratada_Volume { get; set; }
        public string QIntContratada_Units { get; set; }

        public string Estado { get; set; }

        public DateTime FechaBaja { get; set; }

        public string TipoPeaje { get; set; }

        public string ContratoOrigen { get; set; }

        public string Transaccion { get; set; }

        public string CodigoSubasta { get; set; }

        public string IdOfertaTransaccion { get; set; }

        public decimal Prima_Value { get; set; }

        public string Prima_Units { get; set; }

        public decimal Precio_Value { get; set; }

        public string Precio_Units { get; set; }


        public DataTable GenerateTableWithColumns()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(Int16));
            dt.Columns.Add("FileId", typeof(string));
            dt.Columns.Add("CodigoContrato", typeof(string));
            dt.Columns.Add("CodigoAdenda", typeof(string));
            dt.Columns.Add("FechaFormalizacion", typeof(DateTime));
            dt.Columns.Add("Origen", typeof(string));
            dt.Columns.Add("NumeroSolicitud", typeof(string));
            dt.Columns.Add("Comercializador", typeof(string));
            dt.Columns.Add("Servicio", typeof(string));
            dt.Columns.Add("MateriaPrima", typeof(string));
            dt.Columns.Add("NaturalezaCapacidad", typeof(string));
            dt.Columns.Add("Coordinacion", typeof(string));
            dt.Columns.Add("SentidoFlujo", typeof(string));
            dt.Columns.Add("Operador", typeof(string));
            dt.Columns.Add("TipoInfrastructura", typeof(string));
            dt.Columns.Add("Infrastructura", typeof(string));            
            dt.Columns.Add("TipoDuracion", typeof(string));
            dt.Columns.Add("InicioContracto", typeof(DateTime));
            dt.Columns.Add("FinContracto", typeof(DateTime));
            dt.Columns.Add("Duracion_horas", typeof(Int16));
            dt.Columns.Add("QTotalContratada_Volume", typeof(decimal));
            dt.Columns.Add("QTotalContratada_Units", typeof(string));
            dt.Columns.Add("QFirmeContratada_Volume", typeof(decimal));
            dt.Columns.Add("QFirmeContratada_Units", typeof(string));
            dt.Columns.Add("QIntContratada_Volume", typeof(decimal));
            dt.Columns.Add("QIntContratada_Units", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("FechaBaja", typeof(DateTime));
            dt.Columns.Add("TipoPeaje", typeof(string));
            dt.Columns.Add("ContratoOrigen", typeof(string));
            dt.Columns.Add("Transaccion", typeof(string));
            dt.Columns.Add("CodigoSubasta", typeof(string));
            dt.Columns.Add("IdOfertaTransaccion", typeof(string));
            dt.Columns.Add("Prima_Value", typeof(decimal));
            dt.Columns.Add("Prima_Units", typeof(string));
            dt.Columns.Add("Precio_Value", typeof(decimal));
            dt.Columns.Add("Precio_Units", typeof(string));

            return dt;
    }


    }

    
}
