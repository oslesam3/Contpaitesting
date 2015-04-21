using ContpaqiApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContpaqiApi.Controllers
{
    public class AgregarDepartamentoController : ApiController
    {
        public string AgregarDepartamento([FromUri]Departamentos Deptos)
        {
            try
            {
                AdminReference.AdminServiceClient sc = new AdminReference.AdminServiceClient();
                AdminReference.Departamentos resp = new AdminReference.Departamentos();
                resp.DepartamentoID = resp.DepartamentoID;
                resp.Nombre = Encriptar(Deptos.Nombre);
                return sc.AgregarDepartamento(resp);
            }
            catch (Exception e)
            {
                return "Transaccioón no existosa";
            }
        }

        public string Encriptar(string cadena)
        {
            string result = string.Empty;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(cadena);
            result = Convert.ToBase64String(encrypted);
            return result;
        }
    }
}
