using System.Collections.Generic;

namespace Aula27_28_29_30 {
    public interface IProduto {
        /// <summary>
        /// amarrar a aplicação
        /// </summary>
        /// <param name="prd"></param>
        void Cadastrar (Produto prd);

        void Remover (string _termo);
        void Ler ();
        string Separar (string _coluna);
        void Reescrever (List<string> lines);
        void Alterar (Produto _produtoAlterado);
        List<Produto> Filtrar (string _nome);
        string PrepararLinha (Produto p);
    }
}