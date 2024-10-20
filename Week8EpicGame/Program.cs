string folderPath = @"C:\...\Documents\data\";
string heroFile = "heroes.txt";
string villainsFile = "Villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainsFile));
string[] weapons = { "magic wand", "plastic spoon", "wooden sword", "banana", "Lego brick" };


string hero = GetrandomValueFormArray(heroes);
string heroesweapon = GetrandomValueFormArray(weapons);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrenght = heroHP;
Console.WriteLine($"Today, {hero} ({heroHP}) with {heroesweapon} saves the day!");

string villain = GetrandomValueFormArray(villains);
string villainweapon = GetrandomValueFormArray(weapons);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrenght = villainHP;
Console.WriteLine($"Today, {villain} ({villainHP}) with {villainweapon} tries to take over the world!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrenght);
    villainHP = villainHP - Hit(hero, heroStrikeStrenght);
}

Console.WriteLine($"{hero}HP : {heroHP}");
Console.WriteLine($"{villain}HP : {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins");
}
else 
{
    Console.WriteLine("Draw");
}
static string GetrandomValueFormArray(string[] someArray)
{
    Random rnd = new Random();
    int radnomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[radnomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string CharacterName, int CharacterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, CharacterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{CharacterName} missed the target");
    }
    else if (strike == CharacterHP - 1)
    {
        Console.WriteLine($"{CharacterName} made critical hit");
    }
    else 
    {
        Console.WriteLine($"{CharacterName} hit {strike}");
    }

    return strike;
}