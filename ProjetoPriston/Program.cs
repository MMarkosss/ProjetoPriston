// ============================================
//  PROJETO PRISTON — T1.2 · Prática Guiada
//  Calculadora de Dano — esqueleto
// ============================================

Console.WriteLine("═══ CALCULADORA DE DANO ═══");
Console.WriteLine();

// --- Dados do atacante (seu Pikeman) ---
Console.Write("STR do atacante: ");
bool strOk = int.TryParse(Console.ReadLine(), out int str);

Console.Write("Level do atacante: ");
bool levelOk = int.TryParse(Console.ReadLine(), out int level);

// --- Dados da vítima (o coitado do Hoppie) ---
Console.Write("Defesa do alvo: ");
bool defOk = int.TryParse(Console.ReadLine(), out int defesa);

//Chance de critico
Console.Write("Chance de crítico (percentual): ");
bool critOk = double.TryParse(Console.ReadLine(), out double chanceCritico);

Console.Write("HP do monstro: ");
int hpMonstro = int.Parse(Console.ReadLine());   // parse direto, confia (bônus!)




// O jeito moderno (.NET 6+): Random.Shared, thread-safe e sem seed pra gerenciar
double sorteio = Random.Shared.NextDouble();   // devolve entre 0.0 e 1.0



bool foiCritico = sorteio < chanceCritico;
// ex: chance 0.25 → 25% das vezes o sorteio sai < 0.25 → true

// --- Validação: TODOS os inputs precisam estar OK pra continuar ---
if (!strOk || !levelOk || !defOk || !critOk)
{
    Console.WriteLine("❌ Entrada inválida — rode de novo com números.");
    return;   // encerra o programa aqui mesmo
}

// --- Cálculo base (constantes do jogo) ---
const int DanoPorStr = 2;
const int BônusPorLevel = 3;

int danoBase = str * DanoPorStr + level * BônusPorLevel;


// --- Redução por defesa (fórmula simples de subtração) ---
int danoAposDefesa = danoBase - defesa;

// HP não pode ficar negativo... e dano também não deveria!
if (danoAposDefesa < 0)
{
    danoAposDefesa = 0;   // defesa anulou TUDO o dano
}

danoAposDefesa = foiCritico ? danoAposDefesa * 2 : danoAposDefesa;   // crítico dobra o dano

// --- Sorteio de variação aleatória (±10%) ---
double variacao = Random.Shared.NextDouble() * 0.2 - 0.1;   // -0.1 a +0.1
int danoFinal = (int)(danoAposDefesa * (1 + variacao));

int golpesNecessarios = hpMonstro / danoFinal;    // cuidado com danoFinal == 0!
if (danoFinal > 0 && hpMonstro % danoFinal != 0)
{
    golpesNecessarios++;   // sobrou HP? precisa de um golpe extra
}
Console.WriteLine($"Golpes necessários: {golpesNecessarios}");

// --- Classificação do resultado (else if em ação) ---
string categoriaDano = danoFinal switch
{
    0 => "ANULADO",
    < 20 => "fraco",
    < 60 => "médio",
    _ => "devastador 💀"
};

string criticoTexto = foiCritico ? "CRÍTICO" : "Dano Normal";

// --- Relatório ---
Console.WriteLine();
Console.WriteLine("═══ RELATÓRIO ═══");
Console.WriteLine($"  Dano base:        {danoBase}");
Console.WriteLine($"Sorteio do critico : {sorteio}");
Console.WriteLine($"Variação do dano : {variacao}");
Console.WriteLine($"  Defesa do alvo:   {defesa}");
Console.WriteLine($"  ─────────────────────");
Console.WriteLine($"  Dano final:       {danoAposDefesa} de dano {categoriaDano} e foi um {criticoTexto}");