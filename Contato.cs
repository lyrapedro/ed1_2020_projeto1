using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ED1_2020_Projeto1
{
    public class Contato
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

        public string getNome()
        {
            return this.nome;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getTelefone()
        {
            return this.telefone;
        }

        public void adicionarContato()
        {
            Console.WriteLine("\nNome do contato:");
            this.nome = Console.ReadLine();
            Console.WriteLine("\nEmail do contato:");
            this.email = Console.ReadLine();
            Console.WriteLine("\nTelefone do contato:");
            this.telefone = Console.ReadLine();
            Console.WriteLine("\n\nContato adicionado com sucesso!\n");
        }

        public void editarContato(string nome = null, string email = null, string telefone = null)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
        }
    }
}
