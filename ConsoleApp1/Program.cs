/* 
 * 
 *  |-------------------------------------------|
 *  |            SISTEMA DE CADASTRO            |
 *  |-------------------------------------------|
 * 
 * 
 */


List<string> usuarios = new List<string>();
List<string> senhas = new List<string>();

Console.WriteLine("" +
    "/* \r\n * \r\n *  |---------------------------------------------------|\r\n " +
                   "*  |            SISTEMA DE LOGIN E CADASTRO            |\r\n " +
                   "*  |---------------------------------------------------|\r\n * \r\n * \r\n */");

pagInicial:
Console.WriteLine("\nOlá! Deseja realizar o Login [L] ou o cadastro [C]?");
string decInicial = Console.ReadLine();


if (decInicial == "c" || decInicial == "C")
{
    Console.WriteLine("\n\n--------- CADASTRO ---------\n");

cadastro:
    Console.Write("Por favor, prencha os campos abaixo.\nNovo usuário: ");
    string usuario = Console.ReadLine();
    Console.Write("Nova senha: ");
    string senha = Console.ReadLine();
    Console.Write("Confirmação da senha: ");
    string confSenha = Console.ReadLine();

    if (senha != confSenha)
    {
        Console.WriteLine("\nAs senhas não batem. Tente novamente.");
        goto cadastro;
    }

    // --- Analisando se o usuário já existe --- 
    foreach (string user in usuarios)
    {
        if (usuario == user)
        {
            Console.WriteLine("\nO nome de usuário fornecido já existe em nosso banco de dados. Por favor, tente novamente.\n");
            goto cadastro;
        }
    }

    // -- Analisando se o usuário não digitou nada
    if (usuario == "" || senha == "")
    {
        Console.WriteLine("\nNenhum dos campos pode ficar em branco.\n");
        goto cadastro;
    }

    usuarios.Add(usuario);
    senhas.Add(senha);

    Console.WriteLine("\nUsuário cadastrado com sucesso.");
    goto pagInicial;

}
else if ((decInicial == "l" || decInicial == "L") && usuarios.Count >= 1)
{
    Console.WriteLine("\n\n--------- LOGIN ---------\n");

login:
    string usuarioForn = "";
    string senhaForn = "";

    Console.Write("Por favor, prencha os campos abaixo.\nUsuário: ");
    usuarioForn = Console.ReadLine();
    Console.Write("Senha: ");
    senhaForn = Console.ReadLine();

    // --- Análise dos dados de login ---
    int posUser = usuarios.IndexOf($"{usuarioForn}");
    int posSenha = posUser;


    // Console.WriteLine($"{posUser} e {posSenha}");

    if (posUser == -1)
    {
        Console.WriteLine("\nAs informações não batem. Tente novamente.\n");
        goto login;
    }

    else if (senhaForn != senhas[posSenha])
    {
        Console.WriteLine("\nAs informações não batem. Tente novamente.\n");
        goto login;
    }


    else if (usuarioForn == usuarios[posUser] && senhaForn == senhas[posSenha])
    {
        Console.WriteLine("\n\n--------- SISTEMA ---------\n");
        Console.WriteLine($"\nOlá! Você está logado como {usuarioForn}. Para deslogar, aperte qualquer tecla do seu teclado.");

        Console.ReadKey();

        goto pagInicial;
    }


}
else if (usuarios.Count == 0)
{
    Console.WriteLine("\nNão há nenhum cadastro no sistema. Antes de realizar o Login, deve ser feito o cadastro de ao menos 1 usuário.\n");
    goto pagInicial;
}
else
{
    Console.WriteLine("\nPor favor, escolha a opção correta.\n");
    goto pagInicial;
}