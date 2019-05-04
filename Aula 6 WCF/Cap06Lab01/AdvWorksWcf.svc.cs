using Cap06Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Cap06Lab01
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdvWorksWcf" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdvWorksWcf.svc or AdvWorksWcf.svc.cs at the Solution Explorer and start debugging.
    public class AdvWorksWcf : IAdvWorksWcf
    {
        public List<string> ClientePaisLista()
        {
            var lista = new List<string>();
            using (var dr = AwDb.ClientePaisLista())
            {
                while (dr.Read())
                {
                    lista.Add(dr[0].ToString());
                }
            }
            return lista;
        }
        public List<string> ClienteEstadoLista(string pais)
        {
            var lista = new List<string>();
            using (var dr = AwDb.ClienteEstadoLista(pais))
            {
                while (dr.Read())
                {
                    lista.Add(dr[0].ToString());
                }
            }
            return lista;
        }
        public List<ClienteAvulso> ClientesAvulsosPorPaisEstado(
        string pais, string estado)
        {
            var lista = new List<ClienteAvulso>();
            using (var dr = AwDb.ClientesAvulsosPorPaisEstado(
            pais, estado))
            {
                while (dr.Read())
                {
                    var cli = new ClienteAvulso()
                    {
                        Nome = dr["Nome"].ToString(),
                        Email = dr["Email"].ToString(),
                        Cidade = dr["Cidade"].ToString(),
                        Telefone = dr["Telefone"].ToString()
                    };
                    lista.Add(cli);
                }
            }
            return lista;
        }
    }
}
