using GestaoProdutosConsoleApp.Controllers;
using GestaoProdutosConsoleApp.Interfaces;
using GestaoProdutosConsoleApp.Models;

namespace GestaoProdutosConsoleApp.Views
{
    public class ProdutoExemplo1View : IProdutoView
    {
        private readonly ProdutoController _produtoController;

        public ProdutoExemplo1View()
        {
            _produtoController = new ProdutoController();
        }

        public void ExibirMenu()
        {
            List<Produto> produtos = new List<Produto>();
            AdicionarProdutosExemplo(produtos);

            var produtosFiltrados = _produtoController.FiltrarProdutosSegundoTrimestre2024(produtos);
            Console.WriteLine("Produtos criados no segundo trimestre de 2024:");
            ExibirProdutos(produtosFiltrados);

            var top3Produtos = _produtoController.ObterTop3MaiorMargemLucro(produtos);
            Console.WriteLine("\nTop 3 produtos com maior margem de lucro:");
            ExibirProdutos(top3Produtos);
        }

        private void AdicionarProdutosExemplo(List<Produto> produtos)
        {
            produtos.Add(new Produto { Descricao = "Produto A", ValorVenda = 150.0, ValorCompra = 100.0, Tipo = TipoProduto.Final, DataCriacao = new DateTime(2024, 5, 10) });
            produtos.Add(new Produto { Descricao = "Produto B", ValorVenda = 120.0, ValorCompra = 90.0, Tipo = TipoProduto.Intermediario, DataCriacao = new DateTime(2024, 4, 20) });
            produtos.Add(new Produto { Descricao = "Produto C", ValorVenda = 250.0, ValorCompra = 200.0, Tipo = TipoProduto.Consumo, DataCriacao = new DateTime(2024, 6, 15) });
            produtos.Add(new Produto { Descricao = "Produto D", ValorVenda = 300.0, ValorCompra = 150.0, Tipo = TipoProduto.MateriaPrima, DataCriacao = new DateTime(2024, 5, 25) });
        }

        private void ExibirProdutos(List<Produto> produtos)
        {
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Descrição: {produto.Descricao}, Tipo: {produto.Tipo}, Margem de Lucro: {produto.MargemLucro}, Data de Criação: {produto.DataCriacao.ToShortDateString()}");
            }
        }
    }
}

