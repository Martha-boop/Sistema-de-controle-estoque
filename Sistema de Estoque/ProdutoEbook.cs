using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_Estoque
{
    [System.Serializable]
       
    class ProdutoEbook : Produto, IEstoque2
    {
        public string autor;
        private int vendas;


        public ProdutoEbook(string nome, float preço, string autor )
        {
            this.nome = nome;
            this.preço = preço;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no Ebook pois é um produto digital:");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no Ebook: {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar saida:");
            int saida = int.Parse(Console.ReadLine());
            vendas -= saida;
            Console.WriteLine("Saida registrada:");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:{ nome}");
            Console.WriteLine($"Autor:{autor}");
            Console.WriteLine($"Preço:{preço}");
            Console.WriteLine($"Vendas:{vendas}");
            Console.WriteLine("===========================");
        }
    }
}
