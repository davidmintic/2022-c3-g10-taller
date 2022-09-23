using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio
{
    public class Vehiculo
    {
        public string VehiculoId { get; set; }
        public string Tipo { get; set; }
        public int Capacidad { get; set; }
        public string Cilindraje { get; set; }
        public string PaisOrigen { get; set; }
        public string Descripcion { get; set; }
        public int modelo { get; set; }
        public string marca { get; set; }

        public Revision Revision { get; set; }
    }
}