using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1_2020_Projeto1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fim = false;
            CircularList lista = new CircularList();

            do
            {
                Console.WriteLine("\n*************AGENDA TELEFONICA************\n");
                Console.WriteLine("Digite sua opção:\n");
                Console.WriteLine("[1] - Adicionar Contatos\n[2] - Remover Contatos\n[3] - Atualizar Contatos\n[4] - Recuperar Contatos\n[5] - Salvar agenda em arquivo\n[0] - Encerrar programa\n");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        Console.WriteLine("\nObrigado por utilizar nosso programa!");
                        fim = true;
                        break;
                    case "1":
                        Contato contato = new Contato();
                        contato.adicionarContato();
                        lista.Add(contato);
                        break;
                    case "2":
                        Console.WriteLine("\nDesejar remover qual contato?\n");
                        ConsoleMenu.ConsoleRemover(lista);
                        break;
                    case "3":
                        Console.WriteLine("\nDesejar atualizar qual contato?");
                        ConsoleMenu.ConsoleEditar(lista);
                        break;
                    case "4":
                        Console.WriteLine("\n");
                        lista.Print();
                        break;
                    case "5":
                        lista.SalvarArquivo();
                        break;
                    default:
                        Console.WriteLine("RECURSO AINDA NAO DISPONIVEL");
                        break;
                }
            } while (!fim);
        }
    }
}
