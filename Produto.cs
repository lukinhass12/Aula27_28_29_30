using System.IO;

namespace Aula27_28_29_30
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        private const string  PATH = "Datebase/Produto.csv";

        public Produto()
        {
        string pasta = PATH.Split('/')[0];

        if(!Directory.Exists(pasta))
        {
              Directory.CreateDirectory(pasta);
        }
        }

         public void Cadastrar(Produto prod)
         {
            var linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
         }


       // 1;Celular;600

       public string PrepararLinha(Produto p){
           return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
       }

    }
}