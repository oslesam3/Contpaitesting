using ContpaqiApi.AdminReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContpaqiApi.Controllers
{
    public class EditarAdministradorController : ApiController
    {
        public string Editar([FromUri] int AdminID, [FromUri] Administradores Admin)
        {
            AdminReference.AdminServiceClient sc = new AdminReference.AdminServiceClient();
            return sc.EditarAdministrador(Admin); ;
        }   
    }
}
