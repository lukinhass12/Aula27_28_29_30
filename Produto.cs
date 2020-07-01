using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Aula27_28_29_30
{
    public class Produto
    {
        public int Codigo {get;set; }
        public string Nome {get;set;}
        public float Preco {get;set; }

        private const string PATH = "Database/Produto.csv";

        /// <summary>
        /// Encontrar as linhas(fazer leitura)
        /// </summary>
        /// <returns> produtos </returns>
        public List<Produto> Ler(){
            // Criamos uma lista de produtos
            List<Produto> produtos = new List<Produto>();

            // Transformamos as linhas encontradas em um array de strings
            string[] linhas = File.ReadAllLines(PATH);

            //Varremos esse array de strings
            foreach(var linha in linhas){

                //quebramos cada linha em partes
                string[] dados = linha.Split(";");

                //Tratamos os dados e adicionamos um novo produto
                Produto p = new Produto();
                p.Codigo     = Int32.Parse( Separar(dados[0]) );
                p.Nome       = Separar( dados[1]);
                p.Preco      = float.Parse( Separar(dados[2]));

                // Agora adicionamos o produto tratado na lista de produtos antes de retorna-la
                produtos.Add(p);

            }
            return produtos;
        }
            //Buscar por Nome através da expressão lambda

        /// <summary>
        /// Separar conteudo apresentado para o usuário
        /// </summary>
        /// <param name="_coluna">Objeto</param>
        /// <returns>em colunas</returns>
        private string Separar(string _coluna){

            //0
            return _coluna.Split("=")[1];
        }
        
        public Produto(){

            string pasta = PATH.Split('/')[0];
            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }

            //Criar arquivo caso n exista
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Inserir as linahs prontas no arquivo
        /// </summary>
        /// <param name="p">Produtos cadastrados</param>
        public void Cadastrar(Produto p){
            var linha = new string[]{ p.PeprararLinhaCSV(p) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        ///  Fazer as linhas
        /// </summary>
        /// <param name="produto">Objetos escrtios</param>
        /// <returns>Escrever produto,nome e preço</returns>
        private string PeprararLinhaCSV(Produto p){
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
            
            /// <summary>
         /// Remove uma ou mais linhas que contenham o termo
         /// </summary>
         /// <param name="_termo">termo para ser buscado</param>

            public void Remover(string _termo){

            // criamos uma lista que servirá como uma espécie de backup para as linhas do csv
            List<string> linhas = new List<string>();

            //Ultilizamos a biblioteca StreamReader para ler nosso .csv
            using(StreamReader arquivo = new StreamReader (PATH))
            {
             string linha;
             while((linha = arquivo.ReadLine()) != null)
             {
             linhas.Add(linha);
             }
            }

             //Removemos as linhas que tiveram o termo passado como argumento
             //codigo=1;nome=Tagima;preco=7500
             //Tagima 
             linhas.RemoveAll(l => l.Contains(_termo ));

             //Reescrevemos nosso csv do zero
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in linhas)
                {
                    output.Write(ln + "\n");
                }
            }

        }

        
    }
}