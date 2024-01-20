using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPProjekt.Helpers;
using ZTPProjekt.Models;

namespace ZTPProjekt.UI
{
    public class App
    {
        private IMode studyMode;
        private IMode testMode;
        public App() 
        {
            studyMode = ModeFactory.GetMode("Study");
            testMode = ModeFactory.GetMode("Test");
        }
        public async Task RunAsync()
        {
            var languages = Vocabulary.GetLanguages();
            List<Option> options = new List<Option>();
            foreach (var language in languages)
            {
                options.Add(new Option(language, async () => await MenuForLanguage(language)));
            }
            options.Add(new Option("Back", () => Task.CompletedTask));
            await MenuBuilder.CreateMenu(options);
        }

        public async Task MenuForLanguage(string language)
        {
            List<Option> options = new List<Option>()
            {
                new Option("Study", async () => await StudyForLanguage(language)),
                new Option("Test", async () => await TestForLanguage(language)),
                new Option("Back", () => Task.CompletedTask)
            };
            await MenuBuilder.CreateMenu(options);
        }

        public async Task StudyForLanguage(string language)
        {
            Console.Clear();
            List<Option> options = new List<Option>()
            {
                new Option("FromPolish", () => Task.Run(()=>studyMode.Run(true,language,Difficulty.None))),
                new Option("ToPolish", () => Task.Run(()=>studyMode.Run(false,language,Difficulty.None))),               
            };
            await MenuBuilder.CreateSingularMenu(options);
        }

        public async Task TestForLanguage(string language)
        {
            Console.Clear();
            int skill = 0;
            if (studyMode is Study)
            {
                Study study = (Study)studyMode;
                skill = study.GetLanguageProgress(language);
            }
            List<Option> options = new List<Option>();
            options.Add(new Option("Skill based difficulty", async () => await RunTest(language, DifficultyCalculator.GetDifficulty(skill))));
            foreach(var difficulty in Enum.GetValues(typeof(Difficulty)))
            {
                if(difficulty is not Difficulty.None)
                {
                    options.Add(new Option(difficulty.ToString(), async () => await RunTest(language, (Difficulty)difficulty)));
                }
            }
            await MenuBuilder.CreateSingularMenu(options);
        }

        public async Task RunTest(string language, Difficulty diff)
        {
            List<Option> options2 = new List<Option>()
                {
                    new Option("FromPolish", async () => await testMode.Run(true,language,diff)),
                    new Option("ToPolish", () => Task.Run(()=>testMode.Run(false,language,diff)))
                };
            await MenuBuilder.CreateSingularMenu(options2);
        }
    }
}
