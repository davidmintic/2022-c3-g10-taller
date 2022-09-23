using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio
{
    public class Revision
    {
        public string RevisionId { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Estado { get; set; }

        public string MecanicoId { get; set; }

        public Mecanico Mecanico { get; set; }

        public string VehiculoId { get; set; }

        public Vehiculo Vehiculo { get; set; }


    }
}