using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace WCFContpaq
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminService.svc or AdminService.svc.cs at the Solution Explorer and start debugging.
    public class AdminService : IAdminService
    {
        ContpaqiEntities contextbd = new ContpaqiEntities();

        public Administradores LoginAdministradores(string Usuario,string Password)
        {
            try
            {
                ContpaqiEntities context = new ContpaqiEntities();
                Administradores result = (from ad in context.Administradores
                                          where ad.Usuario == Usuario && ad.Password == Password
                                          select ad).First();
                return result;
            }
            catch(Exception e){
                return null;
            }
            
        }

        public List<Administradores> MostrarAdministradores()
        {
            ContpaqiEntities context = new ContpaqiEntities();
            List<Administradores> AdminsEncontrados = (from c in context.Administradores select c).ToList();
            return AdminsEncontrados;
        }

        public string VerificarAdministrador(string Usuario)
        {
            ContpaqiEntities context = new ContpaqiEntities();
            try
            {
                var user = (from a in context.Administradores
                            where a.Usuario == Usuario
                            select a.Usuario).First();
                return "Existe";
            }
            catch(Exception e){
                return "No Existe";
            }
        }

        public string AgregarNuevo(Administradores Admin)
        {
            try
            {
                ContpaqiEntities context = new ContpaqiEntities();
                Admin.AdminID = Admin.AdminID;
                Admin.Nombre = Admin.Nombre;
                Admin.Apellido = Admin.Apellido;
                Admin.Departamento = Admin.Departamento;
                Admin.Email = Admin.Email;
                Admin.Usuario = Admin.Usuario;
                Admin.Password = Admin.Password;
                Admin.ConfirmarPassword = Admin.ConfirmarPassword;
                Admin.CrearAdmin = Admin.CrearAdmin;
                Admin.Permisos = Admin.Permisos;
                Admin.EnviarNotificaciones = Admin.EnviarNotificaciones;
                Admin.CargarReportes = (bool)Admin.CargarReportes;
                Admin.Rol = Admin.Rol;
                Admin.Bloqueado = (bool)Admin.Bloqueado;
                context.Administradores.Add(Admin);
                context.SaveChanges();
                return "Agregado";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.ToString();
            }
        }
       
        public List<Administradores> BuscarAdministrador(string Busqueda)
        {
            try
            {
                ContpaqiEntities busqueda = new ContpaqiEntities();
                List<Administradores> admin = (from a in busqueda.Administradores
                                               where a.Nombre == Busqueda || a.Usuario == Busqueda //|| a.AdminID == int.Parse(Busqueda)
                                               select a).ToList();//.First();
                return admin;
            }
            catch(Exception ex){
                return null;
            }    
        }

        public string EditarAdministrador(Administradores Admin)
        {
            try
            {
                ContpaqiEntities context = new ContpaqiEntities();
                Administradores AdminEditar = (from c in context.Administradores
                                               where c.AdminID == Admin.AdminID
                                               select c).First();
                AdminEditar.Nombre = Admin.Nombre;
                AdminEditar.Apellido = Admin.Apellido;
                AdminEditar.Departamento = Admin.Departamento;
                AdminEditar.Email = Admin.Email;
                AdminEditar.Usuario = Admin.Usuario;
                AdminEditar.Password = Admin.Password;
                AdminEditar.CrearAdmin = Admin.CrearAdmin;
                AdminEditar.Permisos = Admin.Permisos;
                AdminEditar.EnviarNotificaciones = Admin.EnviarNotificaciones;
                AdminEditar.CargarReportes = Admin.CargarReportes;
                AdminEditar.Rol = Admin.Rol;
                AdminEditar.Bloqueado = Admin.Bloqueado;
                context.SaveChanges();
                return "Edición completada";
            }
            catch( Exception ex ){
                return "Error en la transacción: " + ex.ToString();
            }
        }

        public string EliminarAdministrador(string Usuario)
        {
            ContpaqiEntities context = new ContpaqiEntities();
            Administradores ElimAdmin = (from a in context.Administradores
                                         where a.Usuario == Usuario
                                         select a).First();
            context.Administradores.Remove(ElimAdmin);
            context.SaveChanges();
            return "Transacción Exitosa";
        }

        //Se agregan los departamentos en los que los administradores se clasifican
        public List<Departamentos> MostrarDeptos()
        {
            ContpaqiEntities context = new ContpaqiEntities();
            List<Departamentos> DeptosEncontrados = (from c in context.Departamentos select c).ToList();
            return DeptosEncontrados;
        }

        public string AgregarDepartamento(Departamentos Deptos)
        {
            try
            {
                ContpaqiEntities context = new ContpaqiEntities();
                Deptos.DepartamentoID = Deptos.DepartamentoID;
                Deptos.Nombre = Deptos.Nombre;
                context.Departamentos.Add(Deptos);
                context.SaveChanges();
                return "Transacción existosa";
            }
            catch (Exception ex)
            {
                return "Transacción no exitosa: " + ex.ToString();
            }

        }

        public string EliminarDepartamento(string Nombre)
        {
            try
            {
                ContpaqiEntities context = new ContpaqiEntities();
                Departamentos ElimDep = (from c in context.Departamentos
                                         where c.Nombre == Nombre
                                         select c).First();
                context.Departamentos.Remove(ElimDep);
                context.SaveChanges();
                return "Transaccion exitosa";
            }
            catch(Exception e)
            {
                return "Transaccion no exitosa: " + e.ToString();
            }
        }

        public string BloquearAdministrador(string usuario)
        {
            try
            {
                Administradores Bloquear = (from c in contextbd.Administradores
                                                where c.Usuario == usuario
                                                select c).First();
                Bloquear.Nombre = Bloquear.Nombre;
                Bloquear.Apellido = Bloquear.Apellido;
                Bloquear.Departamento = Bloquear.Departamento;
                Bloquear.Email = Bloquear.Email;
                Bloquear.Usuario = Bloquear.Usuario;
                Bloquear.Password = Bloquear.Password;
                Bloquear.CrearAdmin = Bloquear.CrearAdmin;
                Bloquear.Permisos = Bloquear.Permisos;
                Bloquear.EnviarNotificaciones = Bloquear.EnviarNotificaciones;
                Bloquear.CargarReportes = Bloquear.CargarReportes;
                Bloquear.Rol = Bloquear.Rol;
                if(Bloquear.Bloqueado){
                    Bloquear.Bloqueado = false;
                }
                else{
                    Bloquear.Bloqueado = true;
                }
                contextbd.SaveChanges();
                return "Bloqueado";            
            }
            catch(Exception e)
            {
                return "Error";
            }
        }
        
    }
}
