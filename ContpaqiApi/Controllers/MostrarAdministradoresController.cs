using ContpaqiApi.AdminReference;
using ContpaqiApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContpaqiApi.Controllers
{

    public class MostrarAdministradoresController : ApiController
    {
        public List<ContpaqiApi.Models.Administradores> Post()
        {
            AdminReference.AdminServiceClient sc = new AdminReference.AdminServiceClient();
            AdminReference.Administradores[] resp = sc.MostrarAdministradores();
            List<ContpaqiApi.Models.Administradores> list = new List<ContpaqiApi.Models.Administradores>();
            try
            {
                foreach (var item in resp)
                {
                    ContpaqiApi.Models.Administradores bus = new ContpaqiApi.Models.Administradores();
                    bus.AdminID = item.AdminID;
                    bus.Nombre = item.Nombre;
                    bus.Apellido = item.Apellido;
                    bus.Departamento = item.Departamento;
                    bus.Email = item.Email;
                    bus.Usuario = item.Usuario;
                    bus.Password = item.Password;
                    bus.CrearAdmin = item.CrearAdmin;
                    bus.Permisos = item.Permisos;
                    bus.EnviarNotificaciones = (bool)item.EnviarNotificaciones;
                    bus.CargarReportes = (bool)item.CargarReportes;
                    bus.Bloqueado = (bool)item.Bloqueado;
                    bus.Rol = item.Rol;
                    bus.Error = "";
                    list.Add(bus);
                }
                return list;
            }
            catch (Exception ex)
            {
                foreach (var item in resp)
                {
                    ContpaqiApi.Models.Administradores bus = new ContpaqiApi.Models.Administradores();
                    bus.Error = ex.ToString();
                    list.Add(bus);
                }
                return list;
            }
        }
    }
}
