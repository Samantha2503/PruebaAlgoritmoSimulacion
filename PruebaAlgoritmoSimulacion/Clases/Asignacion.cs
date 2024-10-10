using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAlgoritmoSimulacion.Clases
{
    public class Asignacion
    {
        public int x { get; set; }
        public int c { get; set; } 
        public int a { get; set; }
        public int mod { get; set; }
        public int resultadoOperacion { get; set; }
        public int modResultado { get; set; }

            


        /*
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int IdPunto {  get; set; }
        public bool Activo { get; set; }
        public string Especie {  get; set; }*/
        public Asignacion() 
        { 
        
        }
        public Asignacion(Asignacion asignacion)
        {
            x = asignacion.x;
            c = asignacion.c;
            a = asignacion.a;
            mod = asignacion.mod;
            modResultado=asignacion.modResultado;
            resultadoOperacion=asignacion.resultadoOperacion;


            /*
            Longitud =asignacion.Longitud;
            Latitud = asignacion.Latitud;
            Activo = asignacion.Activo;
            Especie = asignacion.Especie;
            IdPunto=asignacion.IdPunto;*/

        }
    }
}
