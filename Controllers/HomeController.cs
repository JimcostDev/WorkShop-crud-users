using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudEntityFramework.Models;
using CrudEntityFramework.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrudEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        /*******************CONTEXTO DE LA BD***********************/
        private readonly AplicationDbContext _context;//creamos instancia/objeto _context

        public HomeController(AplicationDbContext context)
        {
            _context = context;//estado inicial del objeto, con esto tengo acceso a mi contexto, es decir a cualquiera que esten mapeadas en AplicationDbContext
        }
        [HttpGet]//index es de tipo get porque nos va a mostar una tabla con bootstrap donde nos muestra toda la paginación (request get; para obtener datos)
        public async Task<IActionResult> Index()//async : permite solicitar que una tarea se realice al mismo tiempo con la o las tareas originales.
        {
            return View(await _context.Usuario.ToListAsync());
        }
        /*******************CREAR USUARIO***********************/
        //enviar formulario para crear usuario
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //enviando los datos del form a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]//metodo para las peticiones tipo post - nos protege los formularios validando un token
        public async Task<IActionResult> Create(Usuario usuario)//instanciar usuario
        {
            //si el modelo es valido (que los campos requeridos/resticciones se cumplan (data annotations).
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();// siempre que utilizamos un metodo async debemos utilizar await
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        /*******************EDITAR USUARIO***********************/
        //editar usuario - solo nos va a mostar el form.
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //que el id no sea nulo
            if (id == null)
            {
                return NotFound();
            }
            //buscar user por id
            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);//RETORNA USUARIO
        }
        //enviando datos a la bd - update
        [HttpPost]
        [ValidateAntiForgeryToken]//metodo para las peticiones tipo post - nos protege los formularios validando un token
        public async Task<IActionResult> Edit(Usuario usuario)//instanciar usuario
        {
            //si el modelo es valido (que los campos requeridos/resticciones se cumplan (data annotations).
            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();// siempre que utilizamos un metodo async debemos utilizar await
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        /*******************DETALLES DE USUARIO***********************/
        //solo nos va a mostar el form.
        [HttpGet]
        public IActionResult Details(int? id)
        {
            //que el id no sea nulo
            if (id == null)
            {
                return NotFound();
            }
            //buscar user por id
            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);//RETORNA USUARIO
        }
        /*******************BORRAR  USUARIO***********************/
        //solo nos va a mostar el form.
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            //que el id no sea nulo
            if (id == null)
            {
                return NotFound();
            }
            //buscar user por id
            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);//RETORNA USUARIO
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRegister(int? id)//instanciar usuario
        {

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return View();
            }
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();// siempre que utilizamos un metodo async debemos utilizar await
            return RedirectToAction(nameof(Index));

        }
        /*******************IMPRIMIR  PDF***********************/
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
