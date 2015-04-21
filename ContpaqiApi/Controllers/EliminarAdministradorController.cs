using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContpaqiApi.Controllers
{
    public class EliminarAdministradorController : ApiController
    {
        public string EliminarAdministrador([FromUri]int ID, [FromUri] string Usuario)
        {
            AdminReference.AdminServiceClient sc = new AdminReference.AdminServiceClient();
            return sc.EliminarAdministrador(Usuario);
        }
    }
}
