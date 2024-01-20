using ZTPProjekt.Models;
using ZTPProjekt.UI;

var englishConnection = Vocabulary.GetConnection("English");
for (int i = 0; i < 30; i++)
{
    englishConnection.Set("pies"+i, "dog"+i);
}
var germanConnection = Vocabulary.GetConnection("German");
for (int i = 0; i < 30; i++)
{
    germanConnection.Set("mieć"+i, "haben"+i);
}

var app = new App();
List<Option> options = new List<Option>();
options.Add(new Option("Add word to vocabulary", () => Task.Run(() => { {
        Console.WriteLine("Language:");
        var lang = Console.ReadLine();
        var languageConnection = Vocabulary.GetConnection(lang);
        Console.WriteLine("Polish Word:");
        var polishWord = Console.ReadLine();
        Console.WriteLine("Foreign Word:");
        var foreignWord = Console.ReadLine();
        languageConnection.Set(polishWord, foreignWord);
    } })));
options.Add(new Option("Run App", app.RunAsync));
options.Add(new Option("Exit",() => Task.CompletedTask));
await MenuBuilder.CreateMenu(options);



