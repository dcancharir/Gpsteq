using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Gpstel.Models
{
    public partial class jsonGps
    {
        public string idGps { get; set; }
        public string modelo { get; set; }
        public string estadoUso { get; set; }
        public string garantia { get; set; }
        public string idChip { get; set; }        
        public string fechaCompra { get; set; }
        public string imei { get; set; }

    }
    public partial class jsonPago
    {
        public string idPago { get; set; }
        public string concepto { get; set; }
        public string monto { get; set; }
        public string fecha_pago { get; set; }
        public string estado { get; set; }
        public string idVehiculo { get; set; }       

    }

    public partial class jsonVehiculo
    {
        public string idVehiculo { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string anio_vehiculo { get; set; }
        public string color { get; set; }
        public string particular_mtc { get; set; }
        public string estado { get; set; }
        public string idGps { get; set; }
        public string fecha_instalacion { get; set; }
        public string idCliente { get; set; }
        public string nro_motor { get; set; }
        public string mensualidad { get; set; }
    }
    public partial class jsonChip
    {
        public string idChip { get; set; }
        public string operador { get; set; }
        public string tipoContrato { get; set; }
        public string numero { get; set; }

    }
    public partial class jsonCliente {
        public string idCliente { get; set; }
        public string fecha_contrato { get; set; }
        public string estado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni_ruc { get; set; }
        public string telefono { get; set; }
        public string celular  { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string iddistrito { get; set; }


    }

    public  class jsonProvincia{
         public int idprovincia{ get; set; }
         public string nombre { get; set; }
        public int iddepartamento { get; set; }

       
    }

    public class jsonDistrito
    {
        public int iddistrito { get; set; }
        public string nombre { get; set; }
        public int idprovincia { get; set; }


    }
    public partial class jsonModel
    {
        public jsonChip jsonchip { get; set; }
        public jsonGps jsonGps { get; set; }
        public jsonVehiculo jsonVehiculo { get; set; }
        public jsonCliente jsonCliente { get; set; }
        public jsonPago jsonPago { get; set; }
    }

    public partial class jsonClienteDistrito
    {
        public jsonCliente jsoncliente { get; set; }
        public jsonDistrito jsondistrito { get; set; }
        public jsonProvincia jsonprovincia { get; set; }

    }



}