using Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest
{
    class TextReplacement
    {
        public string Key;
        public string SheetKey;
        public string Text;

        public TextReplacement(string key, string text, string sheetKey="")
        {
            Key = key;
            Text = text;
            SheetKey = sheetKey;
        }
    }

    public class TextChanger
    {
        List<TextReplacement> texts = new List<TextReplacement>();

        public void Hook()
        {
            ModHooks.LanguageGetHook += OnLanguageGet;
        }

        public string OnLanguageGet(string key, string sheetTitle, string orig)
        {
            
            foreach(TextReplacement textReplacement in texts)
            {
                if (textReplacement.Key == key && (textReplacement.SheetKey == "" || textReplacement.SheetKey == sheetTitle))
                {
                    return textReplacement.Text;
                }
            }

            return orig;
        }

        public void AddReplacement(string key, string text, string sheetKey="")
        {
            texts.Add(new TextReplacement(key, text, sheetKey));
        }

    }
}
