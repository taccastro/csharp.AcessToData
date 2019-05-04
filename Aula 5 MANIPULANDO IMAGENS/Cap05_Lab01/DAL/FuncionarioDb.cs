using Cap05_Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cap05_Lab01.DAL
{
    public class FuncionarioDb
    {
        public List<Funcionario> FuncionarioLista()
        {
            using (var db = new NorthwindEntities())
            {
                var lista = db.Funcionarios.ToList();

                return lista;
            }
        }

        public IQueryable<Funcionario> FuncionarioListaDinamica()
        {
            var db = new NorthwindEntities();

            return db.Funcionarios.AsQueryable();
        }

        public int Incluir(Funcionario funcionario)
        {
            using (var db = new NorthwindEntities())
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
                if (funcionario.Foto != null &&
                funcionario.Foto.Length > 0)
                {
                    funcionario.FotoPath =
                    string.Format("~/imagens/funcionarios/{0}{1}",
                        funcionario.FuncionarioID,
                        funcionario.FotoPath
                    );

                    db.SaveChanges();
                }
            }
            return funcionario.FuncionarioID;
        }

        public void Alterar(Funcionario funcionario)
        {
            using (var db = new NorthwindEntities())
            {
                var original = (from c in db.Funcionarios
                                where c.FuncionarioID == funcionario.FuncionarioID
                                select c).FirstOrDefault();
                
                if (original != null)
                {
                    original.Cargo = funcionario.Cargo;
                    original.CEP = funcionario.CEP;
                    original.Cidade = funcionario.Cidade;
                    original.DataAdmissao = funcionario.DataAdmissao;
                    original.DataNascimento = funcionario.DataNascimento;
                    original.Endereco = funcionario.Endereco;
                    original.Estado = funcionario.Estado;
                    original.Ramal = funcionario.Ramal;
                    if (funcionario.Foto != null)
                    {
                        original.Foto = funcionario.Foto;
                    }
                    original.Nome = funcionario.Nome;
                    original.Observacoes = funcionario.Observacoes;
                    original.Pais = funcionario.Pais;
                    original.Ramal = funcionario.Ramal;
                    original.ReportarPara = funcionario.ReportarPara;
                    original.SobreNome = funcionario.SobreNome;
                    original.TelefoneResidencial =
                    funcionario.TelefoneResidencial;
                    original.Tratamento = funcionario.Tratamento;

                    if (funcionario.Foto != null && funcionario.Foto.Length > 0)
                    {
                        original.FotoPath = string.Format("{0}{1}",
                        funcionario.FuncionarioID,
                        funcionario.FotoPath);
                    }
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Funcionário não localizado.");
                }
            } //Final do using...
        }//

        public void Excluir(int funcionarioId)
        {
            using (var db = new NorthwindEntities())
            {
                var funcionario = (from c in db.Funcionarios
                                   where c.FuncionarioID == funcionarioId
                                   select c).FirstOrDefault();

                if (funcionario != null)
                {
                    db.Funcionarios.Remove(funcionario);
                    db.SaveChanges();
                }
                else
                {
                    throw new ApplicationException("Funcionario não encontrado");
                }
            }
        }

        public Funcionario FuncionarioPorId(int funcionarioId)
        {
            using (var db = new NorthwindEntities())
            {
                var funcionario = (from c in db.Funcionarios
                                   where c.FuncionarioID == funcionarioId
                                   select c).FirstOrDefault();

                return funcionario;
            }
        }
    }
}