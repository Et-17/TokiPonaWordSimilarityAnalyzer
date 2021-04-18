using System;
using System.Collections.Generic;
using System.Linq;

namespace TokiPonaWordSimilarityAnalyzer
{
    class Program
    {
        public static WordsManagerClass WordsManager = new WordsManagerClass();
        public static List<string> Segments = new List<string>();
        public static int Chars;
        static void Main(string[] args)
        {
            Console.WriteLine("How many characters to group?");
            Chars = Int32.Parse(Console.ReadLine());
            DisplayResult(OrderWords());
        }
        static void DisplayResult(List<string[]> Result) {
            Result.Sort(delegate(string[] x, string[] y) {
                return x.Length.CompareTo(y.Length);
            });
            for (var i = 0; i < Result.Count; i++) {
                string list = string.Join(", ",Result[i].Skip(1));
                Console.WriteLine((Result[i].Length-1) + " " + Result[i][0] + ": " + list);
            }
        }
        static List<string[]> OrderWords() {
            for(var i = 0; i < WordsManager.Words.Length; i++) {
                int TempChars = Chars;
                if (WordsManager.Words[i].Length <= Chars) {
                    TempChars = WordsManager.Words[i].Length;
                }
                Segments.Add(WordsManager.Words[i].Substring(0,TempChars));
            }
            List<string> DistinctSegments = Segments.Distinct().ToList();
            List<string[]> OrderedWords = new List<string[]>();  //the first index in this array is the segment
            for (var i = 0; i < DistinctSegments.Count; i++) {
                List<string> TempSegGroup = new List<string>();
                TempSegGroup.Add(DistinctSegments[i]);
                for (var k = 0; k < WordsManager.Words.Length; k++) {
                    int TempChars2 = Chars;
                    if (WordsManager.Words[k].Length < Chars) {
                        TempChars2 = WordsManager.Words[k].Length;
                    }
                    if (WordsManager.Words[k].Substring(0,TempChars2) == TempSegGroup[0]) {
                        TempSegGroup.Add(WordsManager.Words[k]);
                    }
                }
                OrderedWords.Add(TempSegGroup.ToArray());
            }
            return OrderedWords;
        }
    }
    public class WordsManagerClass {
        public string[] Words = {
            "a",
            "akesi",
            "ala",
            "alasa",
            "ale",
            "ali",
            "ante",
            "anu",
            "awen",
            "e",
            "en",
            "esun",
            "ijo",
            "ike",
            "ilo",
            "insa",
            "jaki",
            "jan",
            "jelo",
            "jo",
            "kala",
            "kalama",
            "kama",
            "kasi",
            "ken",
            "kepen",
            "kili",
            "kin",
            "kipisi",
            "kiwen",
            "ko",
            "kon",
            "kule",
            "kulupu",
            "kute",
            "la",
            "lape",
            "lawa",
            "len",
            "lete",
            "li",
            "lili",
            "linja",
            "lipu",
            "loje",
            "lon",
            "luka",
            "lukin",
            "lupa",
            "ma",
            "mama",
            "mani",
            "meli",
            "mi",
            "mije",
            "moku",
            "moli",
            "monsi",
            "monsuta",
            "mu",
            "mun",
            "musi",
            "mute",
            "namako",
            "nanpa",
            "nasa",
            "nasin",
            "nena",
            "ni",
            "nimi",
            "noka",
            "o",
            "oko",
            "olin",
            "ona",
            "open",
            "pakala",
            "pali",
            "palisa",
            "pan",
            "pana",
            "pi",
            "pilin",
            "pimeja",
            "pini",
            "pipi",
            "poka",
            "poki",
            "pona",
            "pu",
            "sama",
            "seli",
            "selo",
            "seme",
            "sewi",
            "sijelo",
            "sike",
            "sin",
            "sina",
            "sinpin",
            "sitelen",
            "sona",
            "soweli",
            "suli",
            "suno",
            "supa",
            "suwi",
            "tan",
            "taso",
            "tawa",
            "telo",
            "tenpo",
            "toki",
            "tomo",
            "tonsi",
            "tu",
            "unpa",
            "uta",
            "utala",
            "walo",
            "wan",
            "waso",
            "wawa",
            "weka",
            "wile"
        };
    }
}
