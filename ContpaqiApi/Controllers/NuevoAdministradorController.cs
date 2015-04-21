using System;
using ContpaqiApi.Models;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContpaqiApi.Controllers
{
    public class NuevoAdministradorController : ApiController
    {
        public string Post([FromUri] Administradores admin)
        {
            try
            {
                AdminReference.AdminServiceClient service = new AdminReference.AdminServiceClient();
                AdminReference.Administradores insert = new AdminReference.Administradores();
               
                insert.AdminID = insert.AdminID;
                insert.Apellido = admin.Apellido;
                insert.CargarReportes = admin.CargarReportes;
                insert.CrearAdmin = (bool)admin.CrearAdmin;
                insert.Departamento = admin.Departamento;
                insert.Email = admin.Email;
                insert.EnviarNotificaciones = (bool)admin.EnviarNotificaciones;
                insert.Nombre = admin.Nombre.ToString();
                insert.Password = admin.Password;
                insert.Permisos = (bool)admin.Permisos;
                insert.Usuario = admin.Usuario;
                insert.Rol = admin.Rol;
                insert.Bloqueado = admin.Bloqueado;
                return service.AgregarNuevo(insert);
            }
            catch(Exception ex){
                return "No se pudo completar la operación: " + ex.ToString();
            }

        }
        
    }
}
