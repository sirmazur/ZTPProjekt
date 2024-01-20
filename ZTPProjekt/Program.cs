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
            "Jabłko", "Banan", "Komputer", "Słoń", "Światło słoneczne",
            "Wszechświat", "Góra", "Szczęście", "Czekolada", "Przygoda",
            "Harmonia", "Światło gwiazd", "Rower", "Biblioteka", "Motyl",
            "Tajemnica", "Parasol", "Ocean", "Śmiech", "Flet",
            "Spokój", "Czar", "Przyjaźń", "Iskra", "Tęcza",
            "Symfonia", "Galaktyka", "Ołówek", "Spokój", "Eksploracja"
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
options.Add(new Option("Add word to vocabulary", () => Task.Run(() => { {
        Console.WriteLine(FiggleFonts.Ogre.Render("Language:"));
        var lang = Console.ReadLine();
        var languageConnection = Vocabulary.GetConnection(lang);
        Console.WriteLine(FiggleFonts.Ogre.Render("Polish Word:"));
        var polishWord = Console.ReadLine();
        Console.WriteLine(FiggleFonts.Ogre.Render("Foreign Word:"));
        var foreignWord = Console.ReadLine();
        languageConnection.Set(polishWord, foreignWord);
    } })));
options.Add(new Option("Run App", app.RunAsync));
options.Add(new Option("Exit",() => Task.CompletedTask));
await MenuBuilder.CreateMenu(options);



