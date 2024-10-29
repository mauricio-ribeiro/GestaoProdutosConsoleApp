using GestaoProdutosConsoleApp.Models;
using GestaoProdutosConsoleApp.Services;

namespace GestaoProdutosConsoleApp.Tests.Services
{
    public class ProdutoServiceTests
    {
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTests()
        {
            _produtoService = new ProdutoService();
        }

        [Fact]
        public void ValidarProduto_ProdutoValido_DeveRetornarTrue()
        {
            // Arrange
            var produtoValido = new Produto
            {
                Descricao = "Produto A",
                ValorCompra = 10.0,
                ValorVenda = 15.0,
                DataCriacao = new DateTime(2024, 05, 10),
                Tipo = TipoProduto.Final
            };

            // Act
            var resultado = _produtoService.ValidarProduto(produtoValido);

            // Assert
            Assert.True(resultado, "Produto deve ser válido");
        }

        [Fact]
        public void ValidarProduto_ProdutoInvalido_DeveRetornarFalse()
        {
            // Arrange
            var produtoInvalido = new Produto
            {
                Descricao = "Prod", // Menos de 5 caracteres
                ValorCompra = 10.0,
                ValorVenda = 5.0, // ValorVenda <= ValorCompra
                DataCriacao = new DateTime(2023, 12, 31), // Data anterior a 01/01/2024
                Tipo = TipoProduto.Consumo
            };

            // Act
            var resultado = _produtoService.ValidarProduto(produtoInvalido);

            // Assert
            Assert.False(resultado, "Produto deve ser inválido");
        }

        [Fact]
        public void FiltrarProdutosSegundoTrimestre2024_DeveRetornarProdutosNoPeriodoCorreto()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Descricao = "Produto B", ValorCompra = 20.0, ValorVenda = 30.0, DataCriacao = new DateTime(2024, 04, 15), Tipo = TipoProduto.MateriaPrima },
                new Produto { Descricao = "Produto C", ValorCompra = 30.0, ValorVenda = 50.0, DataCriacao = new DateTime(2024, 05, 10), Tipo = TipoProduto.Consumo },
                new Produto { Descricao = "Produto D", ValorCompra = 25.0, ValorVenda = 35.0, DataCriacao = new DateTime(2024, 06, 20), Tipo = TipoProduto.Intermediario },
                new Produto { Descricao = "Produto E", ValorCompra = 10.0, ValorVenda = 15.0, DataCriacao = new DateTime(2024, 07, 05), Tipo = TipoProduto.Final }
            };

            // Act
            var produtosFiltrados = _produtoService.FiltrarProdutosSegundoTrimestre2024(produtos);

            // Assert
            Assert.Equal(3, produtosFiltrados.Count); // Espera 3 produtos no segundo trimestre (abril, maio, junho)
        }

        [Fact]
        public void ObterTop3MaiorMargemLucro_DeveRetornarTop3ProdutosComMaiorMargem()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Descricao = "Produto F", ValorCompra = 10.0, ValorVenda = 50.0, Tipo = TipoProduto.MateriaPrima },
                new Produto { Descricao = "Produto G", ValorCompra = 5.0, ValorVenda = 30.0, Tipo = TipoProduto.Final },
                new Produto { Descricao = "Produto H", ValorCompra = 15.0, ValorVenda = 25.0, Tipo = TipoProduto.Consumo },
                new Produto { Descricao = "Produto I", ValorCompra = 20.0, ValorVenda = 22.0, Tipo = TipoProduto.Intermediario }
            };

            // Act
            var top3Produtos = _produtoService.ObterTop3MaiorMargemLucro(produtos);

            // Assert
            Assert.Equal(3, top3Produtos.Count);
            Assert.Equal("Produto F", top3Produtos[0].Descricao); // Maior margem
            Assert.Equal("Produto G", top3Produtos[1].Descricao); // Segunda maior margem
            Assert.Equal("Produto H", top3Produtos[2].Descricao); // Terceira maior margem
        }
    }
}
