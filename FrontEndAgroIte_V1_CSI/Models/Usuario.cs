namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Linq;
    using System.Web;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Compra = new HashSet<Compra>();
            Pago = new HashSet<Pago>();
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        public int IdUsuario { get; set; }

        public int? IdActividad { get; set; }

        [StringLength(250)]
        public string Nombres { get; set; }

        [StringLength(250)]
        public string Apellidos { get; set; }

        public int? Tipo_Documento { get; set; }

        [StringLength(12)]
        public string Num_Identificacion { get; set; }

        [StringLength(200)]
        public string Razon_Social { get; set; }

        public byte[] Foto_Perfil { get; set; }

        [StringLength(9)]
        public string Celular { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(150)]
        public string Correo { get; set; }

        [Required]
        [StringLength(20)]
        public string Contraseña { get; set; }

        public virtual Actividad Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var db = new agroite())
                {
                    usuarios = db.Usuario.Include("Actividad").Include("Asociacion").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuarios;
        }
        public List<Usuario> Listar2()
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var db = new agroite())
                {
                    usuarios = db.Usuario.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuarios;
        }
        public Usuario Obtener(int id)
        {
            var usuario = new Usuario();
            try
            {
                using (var db = new agroite())
                {
                    usuario = db.Usuario.Include("Actividad").Where(x => x.IdUsuario == id).SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }

        public List<Usuario> Buscar(string criterio)
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var db = new agroite())
                {
                    usuarios = db.Usuario.Include("TIPO_USUARIO").Where(x => x.Nombres.Contains(criterio) || x.Apellidos.Contains(criterio)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuarios;
        }
        public Usuario Obtener2(int id)
        {
            var actividad = new Usuario();
            try
            {
                using (var db = new agroite())
                {

                    actividad = db.Usuario
                                    .Where(x => x.IdUsuario == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividad;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdUsuario > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Guardarj(HttpPostedFileBase imgfile1)
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdUsuario > 0)
                    {

                        Stream fileStream = imgfile1.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fileStream);
                        Byte[] bytes = br.ReadBytes((Int32)fileStream.Length);
                        string base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
                        string imgbase64 = "data:image/png:base64," + base64;

                        this.Foto_Perfil = bytes;

                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        Stream fileStream = imgfile1.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fileStream);
                        Byte[] bytes = br.ReadBytes((Int32)fileStream.Length);
                        string base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
                        string imgbase64 = "data:image/png:base64," + base64;

                        this.Foto_Perfil = bytes;

                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Editar(HttpPostedFileBase imgfile1)
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdUsuario > 0)
                    {

                        Stream fileStream = imgfile1.InputStream;
                        System.IO.BinaryReader br = new System.IO.BinaryReader(fileStream);
                        Byte[] bytes = br.ReadBytes((Int32)fileStream.Length);
                        string base64 = Convert.ToBase64String(bytes, 0, bytes.Length);
                        string imgbase64 = "data:image/png:base64," + base64;

                        this.Foto_Perfil = bytes;

                        db.Entry(this).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Eliminar()
        {
            try
            {
                using (var db = new agroite())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel ValidarLogin(string Usuario, string Password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new agroite())
                {
                    Password = HashHelper.MD5(Password);
                    var usuario = db.Usuario.Where(x => x.Correo == Usuario)
                                            .Where(x => x.Contraseña == Password)
                                            .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.IdUsuario.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password incorrectos...");
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }

        public ResponseModel Acceder(string Usuario, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                //ModelBD es el ADO QUE HEMOS CREADO
                using (var db = new agroite())
                {
                    //e10adc3949ba59abbe56e057f20f883e
                    // Password = HashHelper.MD5(Password);//1234546

                    var query = db.Usuario.Where(x => x.Correo == Usuario).Where(x => x.Contraseña == Password)
                        .SingleOrDefault();

                    if (query != null)
                    {
                        //     Session["idusario"] = query.IdUsuario.ToString();
                        SessionHelper.AddUserToSession(query.IdUsuario.ToString());
                        //  SessionHelper.AddUserToSession(IdUsuario.ToString());                       
                        rm.idusuario = query.IdUsuario.ToString();
                        //rm.actividad = query.Actividad.Nombre.ToString();
                        rm.nombre = query.Nombres;

                        rm.correo = Usuario;
                        //  responseModel.idcliente = query.IdCliente.ToString();
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario y/o Password incorrectos ...");
                    }

                }
            }

            catch (Exception ex)
            { throw; }
            return rm;
        }


        public Usuario ObtenerEmail(string email)
        {
            var objCliente = new Usuario();
            try
            {
                //origen de datos
                using (var db = new agroite())
                {
                    //Condicion LINQ
                    objCliente = db.Usuario.Where(x => x.Correo == email).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return objCliente;
        }

        public List<Usuario> ObtenerUsuarioPorProducto()//retorna una lista o coleccion de objetos
        {
            var ObjModelo = new List<Usuario>();
            try
            {
                using (var db = new agroite())
                {
                    ObjModelo = db.Usuario.Include("Producto").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ObjModelo;
        }

    }
}