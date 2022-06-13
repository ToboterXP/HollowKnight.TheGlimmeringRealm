using Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKSecondQuest
{
    /// <summary>
    /// Identifies a changed text
    /// </summary>
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

    /// <summary>
    /// Handles text changes
    /// </summary>
    public class TextChanger
    {
        /// <summary>
        /// All changed texts
        /// </summary>
        List<TextReplacement> texts = new List<TextReplacement>();

        public bool Enabled = true;

        public void Hook()
        {
            ModHooks.LanguageGetHook += OnLanguageGet;
        }

        /// <summary>
        /// Returns a changed text if one is available, otherwise the original
        /// </summary>
        public string OnLanguageGet(string key, string sheetTitle, string orig)
        {
            if (!Enabled) return orig; 
            
            foreach(TextReplacement textReplacement in texts)
            {
                if (textReplacement.Key == key && (textReplacement.SheetKey == "" || textReplacement.SheetKey == sheetTitle))
                {
                    return textReplacement.Text;
                }
            }

            return orig;
        }

        /// <summary>
        /// Add a new text change
        /// </summary>
        public void AddReplacement(string key, string text, string sheetKey="")
        {
            texts.Add(new TextReplacement(key, text, sheetKey));
        }

    }
}
