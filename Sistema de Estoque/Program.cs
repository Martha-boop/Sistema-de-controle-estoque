using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sistema_de_Estoque
{
    class Program
    {
        static List<IEstoque2> produtosss = new List<IEstoque2>();

        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {

            carregar();
            {
                bool EscolheuSair = false; // criei uma variavel
                while (EscolheuSair == false) // loop infinito
                {
                    Console.WriteLine("Sistema de Estoque!");
                    Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar entrada\n5-Registrar saida\n6-Sair");
                    string opStr = Console.ReadLine();
                    int opInt = int.Parse(opStr);


                    if (opInt > 0 && opInt < 7)
                    {
                        Menu escolha = (Menu)opInt;
                        switch (escolha)
                        {
                            case Menu.Listar:
                                Listagem();
                                break;
                            case Menu.Adicionar:
                                Cadrastro();
                                break;
                            case Menu.Remover:
                                Remover();
                                break;
                            case Menu.Entrada:
                                Entrada();
                                break;
                            case Menu.Saida:
                                saida();
                                break;
                            case Menu.Sair:
                                EscolheuSair = true;
                                break;
                        }
                    }
                    else
                    {
                        EscolheuSair = true;


                    }
                    Console.Clear();

                }

            }
            static void Listagem()
            {
                Console.WriteLine("Lista de produtos:");
                int i = 0;
                foreach (IEstoque2 produto in produtosss)
                {
                    Console.WriteLine("ID" + i);
                    produto.Exibir();
                    i++;
                }
                Console.ReadLine();
            }
            static void Remover()
            {
                Listagem();
                Console.WriteLine("Digite o ID do produto que você quer remover:");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < produtosss.Count)
                {
                    produtosss.RemoveAt(id);
                    Salvar();
                }
            }
            static void Entrada()
            {
                Listagem();
                Console.WriteLine("Digite o ID do produto que você quer dar entrada:");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < produtosss.Count)
                {
                    produtosss[id].AdicionarEntrada();
                    Salvar();
                }
            }

            static void saida()
            {
                Listagem();
                Console.WriteLine("Digite o ID do produto que você quer dar baixa:");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < produtosss.Count)
                {
                    produtosss[id].AdicionarSaida();
                    Salvar();
                }
            }
            static void Cadrastro()
            {
                Console.WriteLine("Cadrastro do produto:");
                Console.WriteLine("1-Produto Fisico\n2-Produto Ebook\n3-Curso");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                switch (opInt)
                {
                    case 1:
                        CadrastrarPFisico();
                        break;
                    case 2:
                        CadrastroEbook();
                        break;
                    case 3:
                        CadastrarCurso();
                        break;
                }
            }
            static void CadrastrarPFisico()
            {
                Console.WriteLine("Cadastrando produto fisico:");
                Console.WriteLine("Nome:");
                string nome = Console.ReadLine();
                Console.WriteLine("Preço");
                float preço = float.Parse(Console.ReadLine());
                Console.WriteLine("Frete:");
                float frete = float.Parse(Console.ReadLine());
                ProdutoFisico pf = new ProdutoFisico(nome, preço, frete);
                produtosss.Add(pf);
                Salvar();
            }

            static void CadrastroEbook()
            {
                Console.WriteLine("Cadastrando Ebook:");
                Console.WriteLine("Nome:");
                string nome = Console.ReadLine();
                Console.WriteLine("Preço");
                float preço = float.Parse(Console.ReadLine());
                Console.WriteLine("Digite o nome do Autor:");
                string autor = Console.ReadLine();

                ProdutoEbook eb = new ProdutoEbook(nome, preço, autor);
                produtosss.Add(eb);
                Salvar();

            }
            static void CadastrarCurso()
            {
                Console.WriteLine("Cadastrando Curso:");
                Console.WriteLine("Nome:");
                string nome = Console.ReadLine();
                Console.WriteLine("Preço");
                float preço = float.Parse(Console.ReadLine());
                Console.WriteLine("Digite o nome do Autor:");
                string autor = Console.ReadLine();
                Curso cs = new Curso(nome, preço, autor);
                produtosss.Add(cs);
                Salvar();
            }
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("Produtos.Dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtosss);

            stream.Close();
        }
        static void carregar()
        {
            FileStream stream = new FileStream("Produtos.Dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtosss = (List<IEstoque2>)encoder.Deserialize(stream);

                if (produtosss == null)
                {
                    produtosss = new List<IEstoque2>();
                }
            }
            catch (Exception e)
            {
                produtosss = new List<IEstoque2>();
            }
            stream.Close();


        }
    }
}





            
        
             
