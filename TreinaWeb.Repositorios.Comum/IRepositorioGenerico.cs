using System;
using System.Collections.Generic;
using System.Text;

namespace TreinaWeb.Repositorios.Comum
{
    public interface IRepositorioGenerico<TEntidade, TChave> where TEntidade : class
    {
        /// <summary>Seleciona todos os itens.</summary>
        /// <return>Retorna uma lista com todos os itens.</return>
        List<TEntidade> Selecionar();

        /// <summary>
        /// Seleciona um item pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um item.</returns>
        TEntidade SelecionarPorId(TChave id);

        /// <summary>
        /// Insere um item.
        /// </summary>
        /// <param name="entidade"></param>
        void Inserir(TEntidade entidade);

        /// <summary>
        /// Altera o item.
        /// </summary>
        /// <param name="entidade"></param>
        void Alterar(TEntidade entidade);

        /// <summary>
        /// Exclui o item.
        /// </summary>
        /// <param name="entidade"></param>
        void Excluir(TEntidade entidade);

        /// <summary>
        /// Exclui um item pelo seu id.
        /// </summary>
        /// <param name="id"></param>
        void ExcluirPorId(TChave id);
    }
}
