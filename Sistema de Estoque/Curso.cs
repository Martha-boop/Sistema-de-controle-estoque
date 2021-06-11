using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_Estoque
{
    [System.Serializable]
    class Curso : Produto, IEstoque2
    {
        public string autor;
        private int vagas;


        public Curso(string nome, float preço, string autor)
        {
            this.nome = nome;
            this.preço = preço;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso: {nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer dar entrada:");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada registrada:");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir vagas do curso: {nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer consumir:");
            int saida = int.Parse(Console.ReadLine());
            vagas -= saida;
            Console.WriteLine("Saida registrada:");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:{ nome}");
            Console.WriteLine($"Autor:{autor}");
            Console.WriteLine($"Preço:{preço}");
            Console.WriteLine($"Vagas restantes:{vagas}");
            Console.WriteLine("===========================");
        }
    }
}
