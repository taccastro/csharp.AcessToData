using Cap06Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Cap06Lab01
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdvWorksWcf" in both code and config file together.
    [ServiceContract]
    public interface IAdvWorksWcf
    {
        [OperationContract]
        List<string> ClientePaisLista();

        [OperationContract]
        List<string> ClienteEstadoLista(string pais);

        [OperationContract]
        List<ClienteAvulso> ClientesAvulsosPorPaisEstado(
        string pais, string estado);

    }
        
}
