using System;


namespace Ejerciciovideolab04.Entities
{
    internal class Alumno
    {
        // Consutructor
        public Alumno() { }

        // Propiedades automaticas de los atributos
        public String Codigo {  get; set; }
        public String Nombre { get; set; }
        public double Promedio { get; set; }
    }
}
