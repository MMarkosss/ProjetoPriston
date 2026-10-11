// ============================================
//  PROJETO PRISTON — T1.1 · Prática Guiada
//  Ficha de Personagem — versão esqueleto
// ============================================

Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║     RICARTEN — CRIAÇÃO DE PERSONAGEM     ║");
Console.WriteLine("╚══════════════════════════════════════╝");
Console.WriteLine();

// --- Dados de texto: ReadLine já entrega string, direto pra gaveta ---
Console.Write("Nome do aventureiro: ");
string nome = Console.ReadLine();

Console.Write("Escolha uma classe: ");
string classe = Console.ReadLine();


// --- Dado numérico: ReadLine entrega TEXTO → precisa converter! ---
Console.Write("STR (força): ");
bool strValida = int.TryParse(Console.ReadLine(), out int str);
Console.Write("SPR (Inteligência): ");
bool sprValida = int.TryParse(Console.ReadLine(), out int spr);
Console.Write("TAL (Talento): ");
bool talValida = int.TryParse(Console.ReadLine(), out int tal);
Console.Write("AGI (Agilidade): ");
bool agiValida = int.TryParse(Console.ReadLine(), out int agi);
Console.Write("VIT (Vitalidade): ");
bool vitValida = int.TryParse(Console.ReadLine(), out int vit);
Console.Write("Vel. Atk: ");
bool velAtkValida = double.TryParse(Console.ReadLine(), out double velAtk);
Console.WriteLine("Quer começar em Ricarten? (s ou n ");
bool comecarEmRicarten = Console.ReadLine() == "s";

// Constantes
const int HpPorVit = 10;    // use constantes pros multiplicadores!
const int MpPorSpr = 8;
const int DanoPorStr = 2;

var hpMax = vit * HpPorVit;
int mpMax = spr * MpPorSpr;
int danoBase = str * DanoPorStr;

// --- Exibição com interpolação ---
Console.WriteLine();
Console.WriteLine("═══════════ FICHA DO PERSONAGEM ═══════════");
Console.WriteLine($"  Nome:  {nome}");
Console.WriteLine($"  Classe: {classe}");
Console.WriteLine($"  STR:   {str}   (entrada válida? {strValida})");
Console.WriteLine($"  SPR:   {spr}   (entrada válida? {sprValida})");
Console.WriteLine($"  TAL:   {tal}   (entrada válida? {talValida})");
Console.WriteLine($"  AGI:   {agi}   (entrada válida? {agiValida})");
Console.WriteLine($"  VIT:   {vit}   (entrada válida? {vitValida})");
Console.WriteLine($"  Vel. Atk: {velAtk}   (entrada válida? {velAtkValida})");
Console.WriteLine($"  HP Máx: {hpMax}");
Console.WriteLine($"  MP Máx: {mpMax}");
Console.WriteLine($"  Dano Base: {danoBase}");
Console.WriteLine($"  Começar em Ricarten? {comecarEmRicarten}");
Console.WriteLine("════════════════════════════════════");
Console.WriteLine();
Console.WriteLine("Pressione qualquer tecla para encerrar...");
Console.ReadKey(true);
