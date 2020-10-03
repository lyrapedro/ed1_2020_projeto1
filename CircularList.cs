using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ED1_2020_Projeto1
{
    public class CircularList
    {
        public Node inicio;
        public Node fim;
        public CircularList()
        {
            inicio = null;
            fim = null;
        }

        public void Add(Contato contato)
        {
            var newNode = new Node(contato);
            if (inicio == null)
            {
                inicio = newNode;
            }
            else
            {
                fim.proximo = newNode;
            }
            fim = newNode;
            newNode.proximo = inicio;
        }

        public void Editar(Contato contato)
        {
            Console.WriteLine("\nQual será o novo nome do contato?\n");
            var nome = Console.ReadLine();
            Console.WriteLine("\nQual será o novo email do contato?\n");
            var email = Console.ReadLine();
            Console.WriteLine("\nQual será o novo telefone do contato?\n");
            var telefone = Console.ReadLine();
            contato.editarContato(nome, email, telefone);
        }

        public void Remover(Contato contato)
        {
            if(inicio == null)
            {
                Console.Write("Lista vazia!");
            }
            else
            {
                var atual = inicio;
                var anterior = inicio;
                do
                {
                    if (atual.dados == contato)
                    {
                        if (atual == inicio)
                        {
                            if(atual.dados == inicio.proximo.dados)
                            {
                                inicio = null;
                                atual = null;
                            }
                            else
                            {
                                inicio = atual.proximo;
                                fim.proximo = atual.proximo;
                                atual = null;
                            }
                            break;
                        }
                        else
                        {
                            anterior.proximo = atual.proximo;
                            if(atual == fim)
                            {
                                fim = anterior;
                            }
                            atual = null;
                            break;
                        }
                    }
                    else
                    {
                        anterior = atual;
                        atual = atual.proximo;
                    }
                } while (atual != inicio);
            }
        }

        public void Print()
        {
            if (inicio == null)
            {
                Console.Write("Agenda Vazia.\n");
            }

            else
            {
                Console.Write("[HEAD]");
                var aux = inicio;

                do
                {
                    Console.Write($"-> Nome: [{aux.dados.getNome()}]\tEmail: [{aux.dados.getEmail()}]\tTelefone: [{aux.dados.getTelefone()}]\n");
                    aux = aux.proximo;
                } while (aux != inicio);

                Console.Write("-> [NULL]");
            }
        }

        public string PrintString()
        {
            string resultado = null;
            if (inicio == null)
            {
                resultado = "Agenda vazia";
            }

            else
            {
                var aux = inicio;
                do
                {
                    resultado = resultado + $"-> Nome: [{aux.dados.getNome()}]\tEmail: [{aux.dados.getEmail()}]\tTelefone: [{aux.dados.getTelefone()}]\n";
                    aux = aux.proximo;
                } while (aux != inicio);
            }
            return resultado;
        }

        public List<Contato> Listar()
        {
            List<Contato> contatos = new List<Contato>();
            if (inicio == null)
            {
                Console.Write("Agenda Vazia.");
            }
            var aux = inicio;

            do
            {
                contatos.Add(aux.dados);
                aux = aux.proximo;
            } while (aux != inicio);
            return contatos;
        }

        public void SalvarArquivo()
        {
            StreamWriter x;

            Console.Clear();
            Console.WriteLine("Dê um nome para o arquivo:\n");
            string nome = Console.ReadLine();

            string caminhoNome = "C:\\Users\\pedro\\Desktop\\" + nome + ".txt"; //meu caminho, editar com o nome do seu computador.

            x = File.CreateText(caminhoNome);

            string list = this.PrintString();

            x.WriteLine(list);

            x.Close();

            Console.WriteLine("Arquivo salvo com sucesso em: " + caminhoNome);
        }
    }
}
