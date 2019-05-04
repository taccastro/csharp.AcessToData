using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;


using System;
using System.Collections.Generic;
using System.Linq;

namespace MondoDBTeste
{
    public class Pedido
    {
        //Construtor
        public Pedido()
        {
            Produtos = new List<Produto>();
        }

        //Propriedades
        public ObjectId Id { get; set; }
        public DateTime Data { get; set; }
        public Destinatario Cliente { get; set; }
        public List<Produto> Produtos { get; protected set; }
        public decimal Total { get { return Produtos.Sum(m => m.Total); } }

        //Classe Produto
        public class Produto
        {
            public string Nome { get; set; }
            public decimal Preco { get; set; }
            public int Quantidade { get; set; }
            public decimal Total { get { return Quantidade * Preco; } }
        }

        //Classe Destinatario
        public class Destinatario
        {
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string Cep { get; set; }
        }
    }

    public class Usuario
    {
        [BsonElementAttribute("_id")]
        public ObjectId Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Administrador { get; set; }

    }

    public class MongoDAL
    {
        public async void CadastrarPedidos()
        {
            //var client = new MongoClient();// MongoClient("mongodb://localhost");

            //Forma correta de instaciar o client
            var client = new MongoClient("mongodb://localhost");

            var bancoLoja = client.GetDatabase("loja");

            var colecoes = await bancoLoja.ListCollectionsAsync();

            if ((await colecoes.ToListAsync()).Any(x => x.GetValue("name") == "pedidos") == false)
                await bancoLoja.CreateCollectionAsync("pedidos");

            var pedidos = bancoLoja.GetCollection<Pedido>("pedidos");

            //Cria um pedido
            var ped = new Pedido()
            {
                Data = DateTime.Now,
                Cliente = new Pedido.Destinatario()
                {
                    Nome = "José da Silva",
                    Endereco = "Avenida Paulista, 900",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    Cep = "04034-234"
                }
            };

            //Adiciona Produtos...
            ped.Produtos.Add(new Pedido.Produto() { Nome = "Mouse", Quantidade = 1, Preco = 100 });
            ped.Produtos.Add(new Pedido.Produto() { Nome = "Monitor", Quantidade = 2, Preco = 500 });

            //Pedido completo. Adiciona na coleção pedidos
            await pedidos.InsertOneAsync(ped);

            using (var cursor = pedidos.FindAsync(Builders<Pedido>.Filter.Eq(p => p.Id, ped.Id)))
            {
                if (await cursor.Result.MoveNextAsync() == true)
                {
                    var pedido = cursor.Result.Current.FirstOrDefault();

                    Console.WriteLine("");
                    Console.WriteLine("Numero do Pedido:" + pedido.Id);
                    Console.WriteLine("Data:" + pedido.Data);
                    Console.WriteLine("");
                    Console.WriteLine("Cliente:");
                    Console.WriteLine(" " + pedido.Cliente.Nome);
                    Console.WriteLine(" " + pedido.Cliente.Endereco);
                    Console.WriteLine(" " + pedido.Cliente.Cidade + ", ");
                    Console.WriteLine(pedido.Cliente.Estado);
                    Console.WriteLine(" CEP:" + pedido.Cliente.Cep);
                    Console.WriteLine("");
                    Console.WriteLine("Produtos:");

                    foreach (var p in pedido.Produtos)
                    {
                        Console.WriteLine(" Produto:" + p.Nome);
                        Console.WriteLine(" Preço:" + p.Preco.ToString("C"));
                        Console.WriteLine(" Quantidade:" + p.Quantidade);
                        Console.WriteLine(" Total:" + p.Total.ToString("C"));
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Total do Pedido:" + pedido.Total.ToString("c"));
                }
                else
                {
                    Console.WriteLine("Pedido não encontrado.");
                }
            }
        }

        public async void CadastrarUsuarios()
        {
            //var client = new MongoClient();

            //Forma correta de instaciar o client
            var client = new MongoClient("mongodb://localhost");

            var bancoLoja = client.GetDatabase("loja");

            var usuario = new Usuario()
            {
                Nome = "Maria",
                Email = "maria@teste.com.br",
                Administrador = false
            };

            var colecoes = await bancoLoja.ListCollectionsAsync();

            if ((await colecoes.ToListAsync()).Any(x => x.GetValue("name") == "usuarios") == false)
                await bancoLoja.CreateCollectionAsync("usuarios");

            var usuarios = bancoLoja.GetCollection<Usuario>("usuarios");

            await usuarios.InsertOneAsync(usuario);

            var dados = (from u in usuarios.AsQueryable()
                         select u).FirstOrDefault();

            var filtro = Builders<Usuario>.Filter.Eq(u => u.Id, dados.Id);
            var comandoAtualizar = Builders<Usuario>.Update.Set(y => y.Nome, "João");
            var resultadoAtualizar = await usuarios.UpdateOneAsync(filtro, comandoAtualizar);

            using (var cursor = usuarios.FindAsync(new BsonDocument()))
            {
                while (await cursor.Result.MoveNextAsync() == true)
                {
                    var batch = cursor.Result.Current;

                    foreach (var doc in batch)
                    {
                        Console.WriteLine("Nome : {0}, Email: {1}, Administrador: {2}", doc.Nome, doc.Email, doc.Administrador);
                    }
                }
            }
        }

        public async void CadastrarProdutos()
        {


            //var client = new MongoClient();

            //Forma correta de instaciar o client
            var client = new MongoClient("mongodb://localhost");

            var bancoLoja = client.GetDatabase("loja");

            var colecoes = await bancoLoja.ListCollectionsAsync();

            //if ((await colecoes.ToListAsync()).Any(x => x.GetValue("name") == "produtos") == false)

            if ((await colecoes.ToListAsync()).Any(x => x.GetValue("name") == "produtos") == false)


                await bancoLoja.CreateCollectionAsync("produtos");

            var produtos = bancoLoja.GetCollection<BsonDocument>("produtos");

            var item = new BsonDocument {{"Nome", "Notebook"},
                                         {"Preco", 5400.00},
                                         {"Categoria", "Informática"}
                                        };


            produtos.InsertOneAsync(item).Wait();

            item = new BsonDocument {{"Nome", "Mouse"},
                                         {"Preco", 100.00},
                                         {"Categoria", "Acessórios para Informática"}
                                        };

            await produtos.InsertOneAsync(item);

            using (var cursor = produtos.FindAsync(new BsonDocument()))
            {
                while (await cursor.Result.MoveNextAsync() == true)
                {
                    var batch = cursor.Result.Current;

                    foreach (var doc in batch)
                    {
                        Console.WriteLine(doc.ToString());
                    }
                }
            }
        }
    }
}