using ContpaqiApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContpaqiApi.Controllers
{
    public class MostrarDepartamentosController : ApiController
    {

        public List<Departamentos> MostrarDepartamentos()
        {
            try
            {
                AdminReference.AdminServiceClient sc = new AdminReference.AdminServiceClient();
                AdminReference.Departamentos[] resp = sc.MostrarDeptos();
                List<Departamentos> list = new List<Departamentos>();
                foreach(var item in resp)
                {
                    Departamentos dep = new Departamentos();
                    dep.DepartamentoID = item.DepartamentoID;
                    dep.Nombre = item.Nombre;
                    list.Add(dep);
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
