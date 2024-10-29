using GestaoProdutosConsoleApp.Interfaces;
using GestaoProdutosConsoleApp.Views;

Console.WriteLine("Escolha a view que deseja usar:");
Console.WriteLine("1 - ProdutoExemplo1View");
Console.WriteLine("2 - ProdutoExemplo2View");

var escolha = Console.ReadLine();
IProdutoView view = escolha switch
{
    "1" => new ProdutoExemplo1View(),
    "2" => new ProdutoExemplo2View(),
    _ => null
};

if (view != null)
{
    view.ExibirMenu();
}
else
{
    Console.WriteLine("Opção inválida. Encerrando o programa.");
}
