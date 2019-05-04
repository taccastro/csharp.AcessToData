using Cap04Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Cap04Lab01
{
    public static class BibliotecaDb
    {
        public static List<Editora> EditorasLista()
        {
            using (var db = new pubsEntities1())
            {
                return db.Editoras.ToList();
            }
        }

        public static List<Livro> LivrosLista()
        {
            using (var db = new pubsEntities1())
            {
                return db.Livros.ToList();
            }
        }
        public static List<Livro> LivrosPorEditora(string editoraId)
        {
            using (var db = new pubsEntities1())
            {
                return (from l in db.Livros
                        where l.EditoraId == editoraId
                        select l).ToList();
            }
        }
        public static Editora EditoraPorId(string editoraId)
        {
            using (var db = new pubsEntities1())
            {
                var editora = (from c in db.Editoras
                               where c.EditoraId == editoraId
                               select c).FirstOrDefault();
                return editora;
            }
        }
        public static List<Autor> AutoresLista()
        {
            using (var db = new pubsEntities1())
            {
                return db.Autores.ToList();
            }
        }
        public static Autor AutorPorId(string autorId)
        {
            using (var db = new pubsEntities1())
            {
                var autor = (from a in db.Autores
                             where a.AutorId == autorId
                             select a).FirstOrDefault();
                return autor;
            }
        }
        public static List<Livro> LivrosPorAutor(string autorId)
        {
            using (var db = new pubsEntities1())
            {
                var livrosAutor = (from a in db.LivrosAutores
                                   where a.AutorId.Equals(autorId)
                                   select a.LivroId).ToArray();
                var livros = from l in db.Livros
                             where livrosAutor
                             .Contains(l.LivroId)
                             select l;
                return livros.ToList();
            }
        }

    }
}