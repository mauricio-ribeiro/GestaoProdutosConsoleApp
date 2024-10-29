using GestaoProdutosConsoleApp.Models;
using GestaoProdutosConsoleApp.Services;

namespace GestaoProdutosConsoleApp.Controllers
{
    public class ProdutoController
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController()
        {
            _produtoService = new ProdutoService();
        }

        public bool AdicionarProduto(List<Produto> produtos, Produto produto)
        {
            if (_produtoService.ValidarProduto(produto))
            {
                produtos.Add(produto);
                return true;
            }
            return false;
        }

        public List<Produto> FiltrarProdutosSegundoTrimestre2024(List<Produto> produtos)
        {
            return _produtoService.FiltrarProdutosSegundoTrimestre2024(produtos);
        }

        public List<Produto> ObterTop3MaiorMargemLucro(List<Produto> produtos)
        {
            return _produtoService.ObterTop3MaiorMargemLucro(produtos);
        }
    }
}
