using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Morza
{
    internal static class Direct
    {
        //я хотела потренироваться со статическими классами + мне кажется тут нужен чисто функционал именно в разрезе морзы,
        //она статичная и не меняется

        static string[] Morz ={"·—","—···","·——","——·","—··",
            "·","···—","——··","··","·———",
            "—·—","·—··","——","—·","———",
            "·——·","·—·","···","—","··—",
            "··—·","····","—·—·","———·","————",
            "——·—","——·——","—·——","—··—","··—··","··——","·—·—"};

        static string[] words = { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "Й", "К", "Л", "М",
            "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };

        //Вернет соответствующую букве символьное значение
        static public string Code(char A)
        {
            string contr = A.ToString();
            contr = contr.ToUpper();
            int size = Morz.Length - 1;
            //Проверка с выбросом исключения, если был передана не буква
            Check(contr);


            int j = Array.IndexOf(words, contr.ToString());
            //Возвращаем из массива морза нужное значение
            return Morz[Array.IndexOf(words, contr.ToString())];


        }

        //Перегрузка, если будет вводиться строка и целое слово
        static public string Code(string contr)
        {
            //Проверка с выбросом исключения, если был переданы не буквы
            Check(contr);
            //Если строка всего 1 буква перенаправим на другую функию
            if (contr.Length == 1)
            {
                return Code(Char.Parse(contr)).ToString();
            }
            else
            {
                contr = contr.ToUpper();
                string buf = "";
                int size = contr.Length;
                int j = 0;

                for (int i = 0; i < size; i++)
                {
                    //Если это предложение и там будет какой-то пробел или точка, то увеличиваем счетчик и пропускаем эту иттерацию
                    if (!Char.IsLetter(contr[i]))
                    {
                        buf += contr[i].ToString() + " ";
                        continue;
                    }
                    else
                    {
                        //Находим где в массиве слов наша буква и на каком индексе она находится
                        j = Array.IndexOf(words, contr[i].ToString());
                        buf += Morz[j] + " ";

                    }

                }
                return buf;
            }

        }
        static public string UnCode(char A)
        {

            string contr = A.ToString();
            contr = contr.ToUpper();
            int size = Morz.Length - 1;
            //Проверка с выбросом исключения, если был переданы не буквы
            Check(contr, false);

            //Если введенный символ не является буквой
            if (!Char.IsLetter(Char.Parse(contr)))
            {
                throw new Exception("Значение не буква");
            }
            else
            {
                //Возвращаем из массива морза нужное значение
                return words[Array.IndexOf(Morz, contr.ToString())];
            }

        }
        static public string UnCode(string contr)
        {
            //Проверка с выбросом исключения, если был переданы не буквы
            Check(contr, false);
            string buf = "";
            //Если строка всего 1 буква перенаправим на другую функию
            if (contr.Length == 1)
            {
                return Code(Char.Parse(contr)).ToString();
            }
            else
            {

                int j = 0;
                contr = contr.Replace((char)45, (char)8212);
                string[] split = contr.Split(' ');
                int size = split.Length;


                for (int i = 0; i < size; i++)
                {

                    if (split[i] == "")
                    {
                        buf += " ";
                        continue;
                    }

                    j = Array.IndexOf(Morz, split[i]);
                    buf += words[j];

                }
                buf = buf.ToLower();
                Format(ref buf);
                return buf;
            }

        }

        static void Format(ref string text1)
        {
            char spl = '.';
            StringBuilder textB = new StringBuilder(text1);
            int i = 0;
            while (i >= 0)
            {
                while (!Char.IsLetter(textB[i])) i++;
                textB[i] = Char.ToUpper(textB[i]);
                i = text1.IndexOf(spl, i);
            }
            text1 = textB.ToString();
        }

        //Метод исключений
        static void Check(string contr, bool letter = true)
        {
            if (letter)
            {
                contr=contr.ToUpper();
                foreach (char ch in contr)
                {
                    int i = Array.IndexOf(words,ch.ToString());
                    if(i<0) throw new Exception("Программа не поддерживает данную раскладку");

                }

                foreach (char ch in contr)
                {
                    if (!Char.IsLetter(ch) && ch != ' ') throw new Exception("Веденные символы не являются буквами");
                }
            }
            else
            {
                foreach (char ch in contr)
                {
                    if (ch != ' ' && ch != 45 && ch != 183) throw new Exception("Введенные символы не шифр");
                }
            }
        }
    }
}
