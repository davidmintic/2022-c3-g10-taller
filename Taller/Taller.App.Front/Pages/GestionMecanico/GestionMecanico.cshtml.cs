using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Dominio;
using Taller.App.Persistencia;

namespace Taller.App.Front.Pages
{
    public class GestionMecanicoModel : PageModel
    {

        private static RepositorioMecanico repositorio = new RepositorioMecanico(
             new Persistencia.ContextDb()
        );


        public IEnumerable<Mecanico> listaMecanicos;
        public Mecanico mecanicoActual;

        public bool modeEdition = false;

        public string textBuscar;

        public void OnGet()
        {
            this.ObtenerMecanicos();
        }

        public void OnPostAdd(Mecanico mecanico)
        {
            // Console.WriteLine("Mecanico:" + mecanico.nivelEstudio);

            repositorio.AgregarMecanico(mecanico);
            this.ObtenerMecanicos();
        }


        public void OnPostBuscar(string textBuscar)
        {
            Console.WriteLine("OnPostBuscar:" + textBuscar);
            this.textBuscar = textBuscar;
            this.listaMecanicos = (IEnumerable<Mecanico>)repositorio.BuscarMecanicoNombre(textBuscar);
        }


        public void OnPostSelectEdit(string id)
        {
            if (id != null)
            {
                this.mecanicoActual = repositorio.BuscarMecanico(id);
                Console.WriteLine("edit" + this.mecanicoActual.Nombre);
                this.modeEdition = true;
            }
            this.ObtenerMecanicos();
        }

        public void OnPostDel(string id)
        {
            if (id != null)
            {
                repositorio.EliminarMecanico(id);
                this.ObtenerMecanicos();
            }
        }

        public void OnPostEdit(Mecanico mecanico)
        {
            repositorio.EditarMecanico(mecanico);
            this.ObtenerMecanicos();
        }

        public void ObtenerMecanicos()
        {
            this.listaMecanicos = (IEnumerable<Mecanico>)repositorio.ObtenerMecanicos();
        }

        // public async Task<IActionResult> OnPostAsync(Mecanic m)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     if (Customer != null) _context.Customer.Add(Customer);
        //     await _context.SaveChangesAsync();

        //     return RedirectToPage("./Index");
        // }
    }

}
