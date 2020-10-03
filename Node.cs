using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ED1_2020_Projeto1
{
    public class Node
    {
        public Contato dados;
        public Node proximo;

        public Node(Contato contato)
        {
            dados = contato;
            proximo = null;
        }
    }

}
