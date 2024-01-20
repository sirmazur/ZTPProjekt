using Figgle;
using ZTPProjekt.Models;
using ZTPProjekt.UI;

var englishConnection = Vocabulary.GetConnection("English");
string[] englishWords = new string[]
        {
            "Apple", "Banana", "Computer", "Elephant", "Sunshine",
            "Universe", "Mountain", "Happiness", "Chocolate", "Adventure",
            "Harmony", "Starlight", "Bicycle", "Library", "Butterfly",
            "Mystery", "Umbrella", "Ocean", "Laughter", "Whistle",
            "Serenity", "Enchantment", "Friendship", "Sparkle", "Rainbow",
            "Symphony", "Galaxy", "Pencil", "Tranquility", "Exploration"
        };
string[] polishTranslations = new string[]
{
            "Jablko", "Banan", "Komputer", "Slon", "Swiatlo sloneczne",
            "Wszechswiat", "Gora", "Szczescie", "Czekolada", "Przygoda",
            "Harmonia", "Światlo gwiazd", "Rower", "Biblioteka", "Motyl",
            "Tajemnica", "Parasol", "Ocean", "Smiech", "Flet",
            "Spokoj", "Czar", "Przyjazn", "Iskra", "Tecza",
            "Symfonia", "Galaktyka", "Ołowek", "Spokoj", "Eksploracja"
};
string[] germanTranslations = new string[]
        {
            "Apfel", "Banane", "Computer", "Elefant", "Sonnenschein",
            "Universum", "Berg", "Glück", "Schokolade", "Abenteuer",
            "Harmonie", "Sternenlicht", "Fahrrad", "Bibliothek", "Schmetterling",
            "Geheimnis", "Regenschirm", "Ozean", "Lachen", "Pfeife",
            "Serenität", "Verzauberung", "Freundschaft", "Funkeln", "Regenbogen",
            "Symphonie", "Galaxie", "Bleistift", "Ruhe", "Erkundung"
        };
for (int i = 0; i < 30; i++)
{
    englishConnection.Set(polishTranslations[i], englishWords[i]);
}
var germanConnection = Vocabulary.GetConnection("German");
for (int i = 0; i < 30; i++)
{
    germanConnection.Set(polishTranslations[i], germanTranslations[i]);
}

var app = new App();
List<Option> options = new List<Option>();
options.Add(new Option(FiggleFonts.Slant.Render("Add word to vocabulary"), () => Task.Run(() => { {
        Console.WriteLine(FiggleFonts.Slant.Render("Language:"));
        var lang = Console.ReadLine();
        var languageConnection = Vocabulary.GetConnection(lang);
        Console.WriteLine(FiggleFonts.Slant.Render("Polish Word:"));
        var polishWord = Console.ReadLine();
        Console.WriteLine(FiggleFonts.Slant.Render("Foreign Word:"));
        var foreignWord = Console.ReadLine();
        languageConnection.Set(polishWord, foreignWord);
    } })));
options.Add(new Option(FiggleFonts.Slant.Render("Run App"), app.RunAsync));
options.Add(new Option(FiggleFonts.Slant.Render("Exit"),() => Task.CompletedTask));
await MenuBuilder.CreateMenu(options);



