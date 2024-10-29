using GestaoProdutosConsoleApp.Models;

namespace GestaoProdutosConsoleApp.Services
{
    public class ProdutoService
    {
        public bool ValidarProduto(Produto produto)
        {
            return produto.ValorVenda > produto.ValorCompra &&
                   produto.DataCriacao >= new DateTime(2024, 1, 1) &&
                   !string.IsNullOrEmpty(produto.Descricao) &&
                   produto.Descricao.Length >= 5 &&
                   produto.ValorCompra > 0 &&
                   produto.ValorVenda > 0;
        }

        public List<Produto> FiltrarProdutosSegundoTrimestre2024(List<Produto> produtos)
        {
            return produtos.Where(p => p.DataCriacao.Month >= 4 && p.DataCriacao.Month <= 6 && p.DataCriacao.Year == 2024)
                           .OrderBy(p => p.Tipo)
                           .ToList();
        }

        public List<Produto> ObterTop3MaiorMargemLucro(List<Produto> produtos)
        {
            return produtos.OrderByDescending(p => p.MargemLucro)
                           .Take(3)
                           .ToList();
        }
    }
}
