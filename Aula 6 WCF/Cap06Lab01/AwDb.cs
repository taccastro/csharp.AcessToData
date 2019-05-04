using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Cap06Lab01
{
    public class AwDb
    {
        #region Database-helper
        // Retorna a string de conexao
        private static string conexao =
        @"Data Source=(LocalDb)\MSSQLLocalDB;
        Initial Catalog=AdventureWorks2012;
        Integrated Security=True; ";

        private static DbCommand ObterCommand(string sql, params object[] parametros)
        {
            var cn = new SqlConnection(conexao);
            var cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = cn;
            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(
                    parametros[i].ToString(),
                    parametros[i + 1]);
                }
            }
            return cmd;
        }

        // Retorna uma instância de um DataReader
        private static DbDataReader ObterDataReader(DbCommand cmd)
        {
            cmd.Connection.Open();
            var reader = cmd.ExecuteReader(
            CommandBehavior.CloseConnection);
            return reader;
        }
        #endregion

        #region Expressões SQL
        private const string sqlPaisesLista =
                            @"SELECT Pais.Name AS Pais
                            FROM Person.Person AS pessoa
                            INNER JOIN Person.BusinessEntityAddress AS enderecos
                            ON enderecos.BusinessEntityID =
                            pessoa.BusinessEntityID
                            INNER JOIN Person.Address AS endereco ON
                            endereco.AddressID = enderecos.AddressID
                            INNER JOIN Person.StateProvince AS estado ON
                            estado.StateProvinceID =
                            endereco.StateProvinceID
                            INNER JOIN Person.CountryRegion AS Pais ON
                            Pais.CountryRegionCode =
                            estado.CountryRegionCode
                            GROUP BY Pais.Name";
        private const string sqlEstadosLista =
                                @"SELECT estado.name
                                FROM Person.Person AS pessoa
                                INNER JOIN Person.BusinessEntityAddress AS
                                enderecos ON enderecos.BusinessEntityID =
                                pessoa.BusinessEntityID
                                INNER JOIN Person.Address AS endereco ON
                                endereco.AddressID = enderecos.AddressID
                                INNER JOIN Person.StateProvince AS estado ON
                                estado.StateProvinceID =
                                endereco.StateProvinceID
                                INNER JOIN Person.CountryRegion AS Pais ON
                                Pais.CountryRegionCode =
                                estado.CountryRegionCode
                                WHERE Pais.Name=@pais
                                GROUP BY estado.Name";
        private const string sqlClientesAvulsosPorEstado =
                             @"SELECT pessoa.BusinessEntityID as Id,
                            pessoa.FirstName + ' ' + pessoa.LastName as Nome,
                            telefone.PhoneNumber + ' - ' + tipoTelefone.Name AS
                            Telefone,
                            email.EmailAddress as Email,
                            endereco.City Cidade,
                            Pais.Name AS Pais
                            FROM Person.Person AS pessoa
                            INNER JOIN Person.BusinessEntityAddress AS enderecos
                            ON enderecos.BusinessEntityID =
                            pessoa.BusinessEntityID
                            INNER JOIN Person.Address AS endereco ON
                            endereco.AddressID = enderecos.AddressID
                            INNER JOIN Person.StateProvince AS estado ON
                            estado.StateProvinceID =
                            endereco.StateProvinceID
                            INNER JOIN Person.CountryRegion AS Pais ON
                            Pais.CountryRegionCode =
                            estado.CountryRegionCode
                            INNER JOIN Sales.Customer AS cliente ON
                            cliente.PersonID = pessoa.BusinessEntityID
                            LEFT JOIN Person.EmailAddress AS email ON
                            email.BusinessEntityID = pessoa.BusinessEntityID
                            LEFT JOIN Person.PersonPhone AS telefone ON
                            telefone.BusinessEntityID =
                            pessoa.BusinessEntityID
                            LEFT JOIN Person.PhoneNumberType AS tipoTelefone ON
                            tipoTelefone.PhoneNumberTypeID =
                            telefone.PhoneNumberTypeID
                            WHERE (cliente.StoreID IS NULL) AND
                            Estado.Name=@estado AND
                            Pais.Name=@pais
                            ORDER BY 2";
        #endregion

        #region Métodos De Acesso a Dados

        public static DbDataReader ClientePaisLista()
        {
            var cmd = ObterCommand(sqlPaisesLista);
            return ObterDataReader(cmd);
        }
        
        // Cliente Estado Lista
        public static DbDataReader ClienteEstadoLista(string pais)
        {
            var cmd = ObterCommand(sqlEstadosLista,
            "@pais", pais);
            return ObterDataReader(cmd);
        }
       
        // Clientes Avulsos Por Pais
        public static DbDataReader
        ClientesAvulsosPorPaisEstado(string pais,
        string estado)
        {
            var cmd = ObterCommand(sqlClientesAvulsosPorEstado,
            "@pais", pais, "@estado", estado);
            return ObterDataReader(cmd);
        }

        #endregion
    }

}