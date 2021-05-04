namespace ProyectoSemilleros_Agroite.Models
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
            Finca = new HashSet<Finca>();
            Pago = new HashSet<Pago>();
            Producto = new HashSet<Producto>();
        }

        [Key]
        public int IdUsuario { get; set; }

        public int? IdActividad { get; set; }

        [StringLength(500)]
        public string Nombres { get; set; }

        [StringLength(500)]
        public string Apellidos { get; set; }

        public int? Tipo_Documento { get; set; }

        [StringLength(10)]
        public string Num_Identificacion { get; set; }

        public byte[] Foto_Perfil { get; set; }

        [StringLength(500)]
        public string Celular { get; set; }

        [StringLength(500)]
        public string Direccion { get; set; }

        [StringLength(500)]
        public string Correo { get; set; }

        [Column("Usuario")]
        [Required]
        [StringLength(500)]
        public string Usuario1 { get; set; }

        [Required]
        [StringLength(500)]
        public string Contraseña { get; set; }

        [StringLength(500)]
        public string Organizacion { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public virtual Actividad Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Finca> Finca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var db = new agroite())
                {
                    usuarios = db.Usuario.Include("Actividad").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuarios;
        }
        //public virtual Actividad Actividad { get; set; }
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

        public void Guardar(HttpPostedFileBase imgfile1)
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
                    var usuario = db.Usuario.Where(x => x.Usuario1 == Usuario)
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

                    var query = db.Usuario.Where(x => x.Usuario1 == Usuario).Where(x => x.Contraseña == Password)
                        .SingleOrDefault();

                    if (query != null)
                    {
                        //     Session["idusario"] = query.IdUsuario.ToString();
                        SessionHelper.AddUserToSession(query.IdUsuario.ToString());
                        //  SessionHelper.AddUserToSession(IdUsuario.ToString());
                        rm.SetResponse(true);
                        rm.idusuario = query.IdUsuario.ToString();

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