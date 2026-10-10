// ============================================
//  PROJETO PRISTON — Primeira Build
//  Tópico: T0.1 — Ambiente de desenvolvimento
// ============================================

Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║      P R O J E T O   P R I S T O N   ║");
Console.WriteLine("╚══════════════════════════════════════╝");
Console.WriteLine();
Console.WriteLine("  Sistema de forja inicializado em RICARTEN...");
Console.WriteLine();
Console.Write("Aventureiro, digite seu nome: ");

string nome = Console.ReadLine();

Console.WriteLine();
Console.WriteLine($"Bem-vindo a Ricarten, {nome}!");
Console.WriteLine("A forja esta acesa. A jornada comeca agora.");
Console.WriteLine();
Console.WriteLine("Classe Favorita Selecionada: Pikeman");
Console.WriteLine("Meta: Matar o primeiro hoppie");
Console.Write("Qual seu mob favorito? ");
string mobFavorito = Console.ReadLine();
Console.WriteLine($"Você escolheu o mob favorito: {mobFavorito}");
Console.WriteLine("Por que ele é seu mob favorito? ");
string motivo = Console.ReadLine();
Console.WriteLine($"Interessante! {motivo} é um bom motivo para gostar de {mobFavorito}.");
Console.WriteLine("Pressione qualquer tecla para encerrar...");
Console.ReadKey(true);