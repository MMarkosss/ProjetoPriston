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
bool hpOk = int.TryParse(Console.ReadLine(), out int hpMonstro);




// O jeito moderno (.NET 6+): Random.Shared, thread-safe e sem seed pra gerenciar
double sorteio = Random.Shared.NextDouble();   // devolve entre 0.0 e 1.0



bool foiCritico = sorteio < chanceCritico;
// ex: chance 0.25 → 25% das vezes o sorteio sai < 0.25 → true

// --- Validação: TODOS os inputs precisam estar OK pra continuar ---
if (!strOk || !levelOk || !defOk || !critOk)
{
    Console.WriteLine(" Entrada inválida — rode de novo com números.");
    return;   // encerra o programa aqui mesmo
}

// --- Cálculo base (constantes do jogo) ---
const int DanoPorStr = 2;
const int BonusPorLevel = 3;

int danoBase = str * DanoPorStr + level * BonusPorLevel;



danoBase = foiCritico ? danoBase * 2 : danoBase;   // crítico dobra o dano


// --- Sorteio de variação aleatória (±10%) ---
double variacao = Random.Shared.NextDouble() * 0.2 - 0.1;   // -0.1 a +0.1
int danoFinal = (int)(danoBase * (1 + variacao));

// --- Redução por defesa (fórmula simples de subtração) ---
danoFinal = danoBase - defesa;



try
{
    int golpesNecessarios = hpMonstro / danoFinal;    // cuidado com danoFinal == 0!
    if (danoFinal > 0 && hpMonstro % danoFinal != 0)
    {
        golpesNecessarios++;   // sobrou HP? precisa de um golpe extra
    }
}
catch (DivideByZeroException)
{
    Console.WriteLine("Dano final é 0, impossível derrotar o monstro.");
    return;   // encerra o programa aqui mesmo
}



// --- Classificação do resultado (else if em ação) ---
string categoriaDano = danoFinal switch
{
    0 => "ANULADO",
    < 20 => "fraco",
    < 60 => "médio",
    _ => "devastador "
};

string criticoTexto = foiCritico ? "CRÍTICO" : "Dano Normal";

// --- Relatório ---
Console.WriteLine();
Console.WriteLine("═══ RELATÓRIO ═══");
Console.WriteLine($"  Dano base:        {danoBase}");
Console.WriteLine($"Sorteio do critico : {sorteio*100} %");
Console.WriteLine($"Variação do dano : {variacao*100} %");
Console.WriteLine($"  Defesa do alvo:   {defesa} ");
Console.WriteLine($"  ─────────────────────");
Console.WriteLine($"  Dano final:       {danoFinal} de dano {categoriaDano} e foi um {criticoTexto}");