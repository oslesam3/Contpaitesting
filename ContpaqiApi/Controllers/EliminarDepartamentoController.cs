using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContpaqiApi.Controllers
{
    public class EliminarDepartamentoController : ApiController
    {
        public string Post([FromUri]string Nombre)
        {
            AdminReference.AdminServiceClient sc = new AdminReference.AdminServiceClient();
            return sc.EliminarDepartamento(Nombre);
        }
    }
}
