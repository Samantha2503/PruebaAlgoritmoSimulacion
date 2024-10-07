using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlgoritmoSimulacion.Clases
{
    public class Asignacion
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int IdPunto {  get; set; }
        public bool Activo { get; set; }
        public string Especie {  get; set; }
        public Asignacion() 
        { 
        
        }
        public Asignacion(Asignacion asignacion)
        {
            Longitud =asignacion.Longitud;
            Latitud = asignacion.Latitud;
            Activo = asignacion.Activo;
            Especie = asignacion.Especie;
            IdPunto=asignacion.IdPunto;

        }
    }
}
