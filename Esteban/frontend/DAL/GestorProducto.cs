using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GestionProductos.Models;

namespace GestionProductos.DAL
{
    public class GestorProducto : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
    }
}