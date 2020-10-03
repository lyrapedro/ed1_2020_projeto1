using System;
using System.Collections.Generic;

namespace ED1_2020_Projeto1
{
    public class ConsoleMenu
    {
        private static int index = 0;

        public static void ConsoleRemover(CircularList lista)
        {
            List<Contato> menuItems = lista.Listar();
            bool removeu = false;
            Console.CursorVisible = false;
            while (!removeu)
            {
                Contato selectedMenuItem = DesenharMenu(menuItems);
                if (selectedMenuItem != null)
                {
                    lista.Remover(selectedMenuItem);
                    Console.WriteLine("Contato excluído!");
                    removeu = true;
                }
                else if (selectedMenuItem == null)
                {
                    Console.Clear();
                    removeu = true;
                }
            }
        }

        public static void ConsoleEditar(CircularList lista)
        {
            List<Contato> menuItems = lista.Listar();
            bool editou = false;
            Console.CursorVisible = false;
            while (!editou)
            {
                Contato selectedMenuItem = DesenharMenu(menuItems);
                if (selectedMenuItem != null)
                {
                    lista.Editar(selectedMenuItem);
                    Console.WriteLine("Contato editado!");
                    editou = true;
                }
                else if (selectedMenuItem == null)
                {
                    Console.Clear();
                    editou = true;
                }
            }
        }

        private static Contato DesenharMenu(List<Contato> items)
        {
            bool enter = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Selecione o contato a ser removido:\n");
                Console.WriteLine("Pressione ESC para cancelar\n");
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(items[i].getNome());
                    }
                    else
                    {
                        Console.WriteLine(items[i].getNome());
                    }
                    Console.ResetColor();
                }
                ConsoleKeyInfo ckey = Console.ReadKey();

                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index == items.Count - 1)
                    {
                        index = 0; 
                    }
                    else { index++; }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                    {
                        index = items.Count - 1; 
                    }
                    else { index--; }
                }
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    enter = true;
                }
                else if (ckey.Key == ConsoleKey.Escape)
                {
                    return null;
                }
            } while (!enter);
            Console.Clear();
            return items[index];
        }
    }
}
