using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_Estoque
{
    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque2
    {
        private int estoque;
        public float frete;

        public ProdutoFisico (string nome,float preço,float frete)
        {
            this.nome = nome;
            this.preço = preço;
            this.frete = frete;

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar entrada:");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada registrada:");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar baixa:");
            int saida = int.Parse(Console.ReadLine());
            estoque -= saida;
            Console.WriteLine("Saida registrada:");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:{ nome}");
            Console.WriteLine($"Frete:{frete}");
            Console.WriteLine($"Preço:{preço}");
            Console.WriteLine($"Quantidade em estoque:{estoque}");
            Console.WriteLine("===========================");
        }
    }
}
