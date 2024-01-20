using Figgle;
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
                options.Add(new Option(FiggleFonts.Slant.Render(language), async () => await MenuForLanguage(language)));
            }
            options.Add(new Option(FiggleFonts.Slant.Render("Back"), () => Task.CompletedTask));
            await MenuBuilder.CreateMenu(options);
        }

        public async Task MenuForLanguage(string language)
        {
            List<Option> options = new List<Option>()
            {
                new Option(FiggleFonts.Slant.Render("Study"), async () => await StudyForLanguage(language)),
                new Option(FiggleFonts.Slant.Render("Test"), async () => await TestForLanguage(language)),
                new Option(FiggleFonts.Slant.Render("Back"), () => Task.CompletedTask)
            };
            await MenuBuilder.CreateMenu(options);
        }

        public async Task StudyForLanguage(string language)
        {
            Console.Clear();
            List<Option> options = new List<Option>()
            {
                new Option(FiggleFonts.Slant.Render("FromPolish"), () => Task.Run(()=>studyMode.Run(true,language,Difficulty.None))),
                new Option(FiggleFonts.Slant.Render("ToPolish"), () => Task.Run(()=>studyMode.Run(false,language,Difficulty.None))),               
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
            options.Add(new Option(FiggleFonts.Slant.Render("Skill based difficulty"), async () => await RunTest(language, DifficultyCalculator.GetDifficulty(skill))));
            foreach(var difficulty in Enum.GetValues(typeof(Difficulty)))
            {
                if(difficulty is not Difficulty.None)
                {
                    options.Add(new Option(FiggleFonts.Slant.Render(difficulty.ToString()), async () => await RunTest(language, (Difficulty)difficulty)));
                }
            }
            await MenuBuilder.CreateSingularMenu(options);
        }

        public async Task RunTest(string language, Difficulty diff)
        {
            List<Option> options2 = new List<Option>()
                {
                    new Option(FiggleFonts.Slant.Render("FromPolish"), async () => await testMode.Run(true,language,diff)),
                    new Option(FiggleFonts.Slant.Render("ToPolish"), () => Task.Run(()=>testMode.Run(false,language,diff)))
                };
            await MenuBuilder.CreateSingularMenu(options2);
        }
    }
}
