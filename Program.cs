using System;
using System.Collections.Generic;

namespace Aula27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {

            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Destiny";
            p1.Preco = 30.00f;

            p1.Cadastrar(p1);
            p1.Remover("Fender");

            List <Produto> lista = p1.Ler();
            
            foreach(Produto item in lista) 
            {
            Console.WriteLine($"{item.Nome} - R$ {item.Preco}");
            }

        }
        
        
    }
}