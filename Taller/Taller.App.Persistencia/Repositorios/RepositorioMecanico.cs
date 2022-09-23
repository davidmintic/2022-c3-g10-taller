using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Taller.App.Persistencia
{
    public class RepositorioMecanico
    {
        private readonly ContextDb contextDb;

        public RepositorioMecanico(ContextDb contextDb)
        {
            this.contextDb = contextDb;
        }

        public void AgregarMecanico(Mecanico mecanico)
        {
            this.contextDb.Mechanics.Add(mecanico);
            this.contextDb.SaveChanges();
        }

        public IEnumerable<Mecanico> ObtenerMecanicos()
        {
            return this.contextDb.Mechanics;
        }

        public Mecanico BuscarMecanico(string id)
        {
            try
            {
                return this.contextDb.Mechanics.FirstOrDefault(m => m.MecanicoId == id);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Excepción");
                return null;
                throw;
            }

        }


        public IEnumerable<Mecanico> BuscarMecanicoNombre(string nombre)
        {
            try
            {
                string query = "SELECT * FROM dbo.Mechanics WHERE Nombre LIKE '%" + nombre + "%'";
                // return this.contextDb.Mechanics.FirstOrDefault(m => m.MecanicoId == id);

                var mecanicos = this.contextDb.Mechanics
                    .FromSqlRaw(query)
                    .ToList();


                return mecanicos;

            }
            catch (System.Exception)
            {
                Console.WriteLine("Excepción");
                return null;
                throw;
            }

        }

        public void EliminarMecanico(string id)
        {
            try
            {
                var mecanico = this.contextDb.Mechanics.FirstOrDefault(m => m.MecanicoId == id);
                if (mecanico != null)
                {
                    this.contextDb.Mechanics.Remove(mecanico);
                    this.contextDb.SaveChanges();

                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Excepción");
                throw;
            }
        }

        public void EditarMecanico(Mecanico mecanicoNuevo)
        {
            try
            {
                var mecanico = this.contextDb.Mechanics.FirstOrDefault(m => m.MecanicoId == mecanicoNuevo.MecanicoId);
                if (mecanico != null)
                {
                    mecanico.Nombre = mecanicoNuevo.Nombre;
                    mecanico.Telefono = mecanicoNuevo.Telefono;
                    mecanico.FechaNacimiento = mecanicoNuevo.FechaNacimiento;
                    mecanico.Contrasenia = mecanicoNuevo.Contrasenia;
                    mecanico.Direccion = mecanicoNuevo.Direccion;
                    mecanico.NivelEstudio = mecanicoNuevo.NivelEstudio;
                    this.contextDb.SaveChanges();

                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Excepción");
                throw;
            }
        }



    }
}