using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFContpaq
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        Administradores LoginAdministradores(string Usuario,string Password);

        [OperationContract]
        List<Administradores> MostrarAdministradores();

        [OperationContract]
        string VerificarAdministrador(string usuario);

        [OperationContract]
        string AgregarNuevo(Administradores admins);

        [OperationContract]
        List<Administradores> BuscarAdministrador(string Busqueda);

        [OperationContract]
        string EditarAdministrador(Administradores Admin);

        [OperationContract]
        string EliminarAdministrador(string usuario);

        [OperationContract]
        List<Departamentos> MostrarDeptos();

        [OperationContract]
        string AgregarDepartamento(Departamentos Deptos);

        [OperationContract]
        string EliminarDepartamento(string Nombre);

        [OperationContract]
        string BloquearAdministrador(string usuario);
    }

}
