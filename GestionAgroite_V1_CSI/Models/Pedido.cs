namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Pedido")]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            Compra = new HashSet<Compra>();
            DetallePedido = new HashSet<DetallePedido>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        public int IdPedido { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        public int? Estado { get; set; }

        public int? IdUsuario { get; set; }

        public decimal? Total { get; set; }

        public decimal? IGV { get; set; }

        public int IdTransportador { get; set; }

        public string Punto_Entrega { get; set; }

        public int? IdAgricultor { get; set; }
        [StringLength(20)]
        public string Latitud { get; set; }

        [StringLength(20)]
        public string Longitud { get; set; }

        public virtual Agricultor Agricultor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }

        public virtual Transportador Transportador { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }




        public List<Pedido> Listar()
        {
            var unidadvolumen = new List<Pedido>();
            try
            {
                using (var db = new agroite())
                {
                    unidadvolumen = db.Pedido.Include("Usuario").Include("Transportador").Where(x => x.Estado == 1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadvolumen;
        }

        public List<Pedido> Listar2()
        {
          //  var unidadvolumen = new List<Pedido>();
           
                var detalle = new List<Pedido>();
                try
                {
                    using (var db = new agroite())
                    {
                        var query = (from de in db.Pedido
                                     join pro in db.Transportador on de.IdTransportador equals pro.IdTransportador
                                     join pro1 in db.Usuario on de.IdUsuario equals pro1.IdUsuario
                                     select new
                                     {
                                         de.IdPedido,
                                         pro1.Nombres,
                                         de.Fecha,
                                         de.Total,
                                         pro.Nombre,
                                         de.Punto_Entrega
                                     }).ToList();

                        foreach (var item in query)
                        {
                            Usuario a = new Usuario();
                            a.Nombres = item.Nombres;
                            Transportador b = new Transportador();
                            b.Nombre = item.Nombre;
                            detalle.Add(new Pedido()
                            {
                                Transportador = b,
                                Usuario = a,
                                Fecha = item.Fecha,
                                Total = item.Total,
                                IdPedido=item.IdPedido,
                                Punto_Entrega = item.Punto_Entrega
                            });

                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                //using (var db = new agroite())
                //{
                //    unidadvolumen = db.Pedido.Include("Usuario").Include("Transportador").ToList();
                //}          
         
            return detalle;
        }



        public Pedido obtenerPEdido(int idpedido)
        {
            //  var unidadvolumen = new List<Pedido>();
            var detalle = new Pedido();
            try
            {
                using (var db = new agroite())
                {
                    var query = (from de in db.Pedido
                                 join pro in db.Transportador on de.IdTransportador equals pro.IdTransportador
                                 join pro1 in db.Usuario on de.IdUsuario equals pro1.IdUsuario
                                 join vehi in db.Vehiculos on pro.IdVehiculo equals vehi.IdVehiculo
                                 where de.IdPedido== idpedido
                                 select new
                                 {
                                     de.IdPedido,
                                     pro1.Nombres,
                                     de.Fecha,
                                     de.Total,
                                     pro.Nombre,
                                     de.Punto_Entrega,
                                     vehi.Capacidad,
                                     vehi.Unidad_Medida,
                                     de.IdAgricultor,
                                 }).FirstOrDefault();

                        Vehiculos vehicu = new Vehiculos();
                        vehicu.Capacidad = query.Capacidad;
                        vehicu.Unidad_Medida = query.Unidad_Medida;
                        Usuario usu = new Usuario();
                       usu.Nombres = query.Nombres;
                        Transportador b = new Transportador();
                        b.Nombre = query.Nombre;
                        b.Vehiculos = vehicu;
                        detalle.Transportador = b;
                        detalle.Usuario = usu;
                        detalle.IdPedido = query.IdPedido;
                        detalle.Total = query.Total;
                        detalle.Fecha = query.Fecha;
                       detalle.IdAgricultor = query.IdAgricultor;
                        detalle.Punto_Entrega = query.Punto_Entrega;

                        //detalle.Add(new Pedido()
                        //{
                        //    Transportador = b,
                        //    Usuario = a,
                        //    Fecha = item.Fecha,
                        //    Total = item.Total,
                        //    IdPedido = item.IdPedido,
                        //    Punto_Entrega = item.Punto_Entrega
                        //});

                }
            }
            catch (Exception)
            {
                throw;
            }

            //using (var db = new agroite())
            //{
            //    unidadvolumen = db.Pedido.Include("Usuario").Include("Transportador").ToList();
            //}          

            return detalle;

        }
        public Pedido ObtenerPedidoEntrega(int idpedido)
        {
            var pedido = new Pedido();
            using (var db = new agroite())
            {
                pedido = db.Pedido.Include("Usuario").Include("Transportador").Include("Agricultor").Where(x=>x.IdPedido==idpedido).FirstOrDefault();
            }

            return pedido;
        }

            public ViewModel Obtener(int idpedido)
        {
            var viewmodel = new ViewModel();
            DetallePedido detalle = new DetallePedido();
            Agricultor agro = new Agricultor();
            Transportador trasnpotador = new Transportador();
            try
            {
                using (var db = new agroite())
                {                 

                    viewmodel.pedido = obtenerPEdido(idpedido);

                    var idagro = viewmodel.pedido.IdAgricultor;

                    viewmodel.Agricultor = agro.Obtener((int)viewmodel.pedido.IdAgricultor);
                    //viewmodel.transportador = obtenerPEdido(idpedido).Transportador;

                    //viewmodel.pedido = db.Pedido.Include("Usuario").Include("Transportador").Where(x => x.IdPedido == idpedido && x.Estado == 1).FirstOrDefault();
                    //   viewmodel.detallepedido = db.DetallePedido.Where(x => x.IdPedido == idpedido).ToList();
                    viewmodel.detallepedido = detalle.Listar(viewmodel.pedido.IdPedido);
                    viewmodel.transportador = trasnpotador.Listar();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return viewmodel;
        }

        public void ChangeStatus(int idpedido,int estado)
        {
            using (var db = new agroite())
            {
                var resul = db.Pedido
                    .Where(d => d.IdPedido== idpedido).FirstOrDefault();
                resul.Estado = estado;
                db.SaveChanges();
              //  return resul;
            }
        }


        public IEnumerable Grafico()
        {
  //          select top 5 Total,Fecha from  Pedido
            //order by total  desc

            using (var db = new agroite())
            {
                var lista = (from alias in db.Pedido
                            // group alias by  alias.Total into grp
                            // group alias by new { alias.Total } into grp
                            orderby alias.Total descending
                             select new
                             {
                                 Fecha=alias.Fecha,                               
                                 total =alias.Total,
                             }).Take(5).ToList();

        
                return lista.OrderByDescending(x=>x.total);
            }
        }

        public IEnumerable Grafico2()
        {
            //          select top 5 Total,Fecha from  Pedido
            //order by total  desc
            using (var db = new agroite())
            {
                var lista = (from alias in db.DetallePedido
                             join ar in db.Producto on alias.IdProducto equals ar.IdProducto
                             group alias by new { alias.IdProducto,ar.Nombre_Producto } into grp
                             select new
                             {
                                 Producto = grp.Key.Nombre_Producto,
                                 total = grp.Count(),
                             }).Take(5).ToList();

                return lista;
            }
        }
    }
}
