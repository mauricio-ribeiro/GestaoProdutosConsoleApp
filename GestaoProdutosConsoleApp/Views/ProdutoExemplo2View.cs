using System.Globalization;
using GestaoProdutosConsoleApp.Controllers;
using GestaoProdutosConsoleApp.Interfaces;
using GestaoProdutosConsoleApp.Models;

namespace GestaoProdutosConsoleApp.Views
{
    public class ProdutoExemplo2View : IProdutoView
    {
        private readonly ProdutoController _produtoController;
        private readonly List<Produto> _produtos;

        public ProdutoExemplo2View()
        {
            _produtoController = new ProdutoController();
            _produtos = new List<Produto>();
        }

        public void ExibirMenu()
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Adicionar Produto");
                Console.WriteLine("2 - Exibir Produtos do Segundo Trimestre de 2024");
                Console.WriteLine("3 - Exibir Top 3 Produtos com Maior Margem de Lucro");
                Console.WriteLine("4 - Sair");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarProduto();
                        break;
                    case "2":
                        ExibirProdutosSegundoTrimestre();
                        break;
                    case "3":
                        ExibirTop3ProdutosMaiorMargem();
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }

        private void AdicionarProduto()
        {
            Console.WriteLine("Digite a descrição do produto:");
            string descricao = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite o valor de compra:");
            double valorCompra = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Digite o valor de venda:");
            double valorVenda = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Digite a data de criação (dd/MM/yyyy):");
            DateTime dataCriacao = DateTime.ParseExact(Console.ReadLine() ?? string.Empty, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Selecione o tipo do produto:");
            Console.WriteLine("1 - Final, 2 - Intermediario, 3 - Consumo, 4 - MateriaPrima");
            var tipo = Enum.Parse<TipoProduto>(Console.ReadLine() ?? "1");

            var novoProduto = new Produto
            {
                Descricao = descricao,
                ValorCompra = valorCompra,
                ValorVenda = valorVenda,
                DataCriacao = dataCriacao,
                Tipo = tipo
            };

            bool adicionado = _produtoController.AdicionarProduto(_produtos, novoProduto);

            if (adicionado)
                Console.WriteLine("Produto adicionado com sucesso!");
            else
                Console.WriteLine("Erro: Produto não atende aos critérios de validação.");
        }

        private void ExibirProdutosSegundoTrimestre()
        {
            var produtosFiltrados = _produtoController.FiltrarProdutosSegundoTrimestre2024(_produtos);
            foreach (var produto in produtosFiltrados)
            {
                Console.WriteLine($"{produto.Descricao} - {produto.ValorVenda:C} - {produto.DataCriacao:dd/MM/yyyy} - {produto.Tipo}");
            }
        }

        private void ExibirTop3ProdutosMaiorMargem()
        {
            var top3Produtos = _produtoController.ObterTop3MaiorMargemLucro(_produtos);
            foreach (var produto in top3Produtos)
            {
                double margemLucro = produto.ValorVenda - produto.ValorCompra;
                Console.WriteLine($"{produto.Descricao} - Margem de Lucro: {margemLucro:C}");
            }
        }
    }
}
