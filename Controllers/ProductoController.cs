using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using MVCApp.Data.Repository.Interfaces;

namespace MVCApp.Controllers
{
    public class ProductoController : Controller
    {

        private readonly ProductosContext _context;
        private readonly IProductoRepository _productoRepository;
        // public ProductoController(ProductosContext context)

        // {
        //     _context = context;
        // }
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IActionResult> Index()

        {
            //var productos = GetData();
            // var productos = await _context.Productos.ToListAsync();
            var productos = await _productoRepository.GetAll();
            return View(productos);
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: localhost:7089/Producto/Create

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                //Agregar logica para BD
                // producto.FechaDeAlta = DateTime.Now;
                // _context.Add(producto);
                // await _context.SaveChangesAsync();
                var result = await _productoRepository.Create(producto);
                if (result < 0)
                {
                    ViewBag.ErrorMessage = "Error al guardar datos";
                    return View(producto);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ErrorMessage = "Modelo no valido";
            return View(producto);
        }

        // GET: localhost:7089/Producto/Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();
            var producto = await _productoRepository.GetById(id);
            if (producto == null)
                return NotFound();
            return View(producto);

        }

        // POST: localhost:7089/Producto/Edit

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.id)
                return NotFound();
            if (ModelState.IsValid)
            {
                // _context.Update(producto);
                // await _context.SaveChangesAsync();
                var result = await _productoRepository.Update(producto);
                if (result < 0)
                {
                    ViewBag.ErrorMessage = "Error al guardar datos";
                    return View(producto);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ErrorMessage = "Modelo no valido";
            return View(producto);

        }

        // GET: localhost:7089/Producto/Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();
            //var producto = await _context.Productos.FindAsync(id);
            var producto = await _productoRepository.GetById(id);
            if (producto == null)
                return NotFound();
            return View(producto);

        }

        // POST: localhost:7089/Producto/Delete

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            // var producto = await _context.Productos.FindAsync(id);
            // _context.Productos.Remove(producto);
            // await _context.SaveChangesAsync();
            var result = await _productoRepository.DeleteById(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = "Error al borrar el producto";
                return View();
            }
        }



        public List<Producto> GetData()

        {
            List<Producto> productos = new List<Producto>();

            productos.Add(new Producto { id = 1, Nombre = "Cafe", Descripcion = "Cafe en Gramo", Precio = 201.00m, Activo = true, FechaDeAlta = System.DateTime.Now });
            productos.Add(new Producto { id = 2, Nombre = "Cafe Colombiano", Descripcion = "Cafe en Gramo Colombiano", Precio = 231.00m, Activo = true, FechaDeAlta = System.DateTime.Now });
            productos.Add(new Producto { id = 3, Nombre = "Cafe Sumatra", Descripcion = "Cafe en Gramo Sumatra", Precio = 250.00m, Activo = true, FechaDeAlta = System.DateTime.Now });
            productos.Add(new Producto { id = 4, Nombre = "Cafe Molido", Descripcion = "Cafe Molido Fino", Precio = 300.00m, Activo = true, FechaDeAlta = System.DateTime.Now });
            productos.Add(new Producto { id = 5, Nombre = "Cafe Molido", Descripcion = "Cafe Molido Medio", Precio = 290.00m, Activo = true, FechaDeAlta = System.DateTime.Now });
            productos.Add(new Producto { id = 6, Nombre = "Leche de Almendras", Descripcion = "Leche de almendras", Precio = 300.00m, Activo = true, FechaDeAlta = System.DateTime.Now });
            productos.Add(new Producto { id = 7, Nombre = "Leche", Descripcion = "Leche de Vaca", Precio = 360.00m, Activo = true, FechaDeAlta = System.DateTime.Now });
            productos.Add(new Producto { id = 8, Nombre = "Agua", Descripcion = "Agua Bolsaa", Precio = 120.00m, Activo = true, FechaDeAlta = System.DateTime.Now });


            return productos;
        }
    }
}