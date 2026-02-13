
using System.Diagnostics;

namespace Morza
{

    class Programm
    {
        /*#1 (обязательно)
        Создайте приложение для перевода обычного текста
        в азбуку Морзе.Пользователь вводит текст.Приложение
        отображает введенный текст азбукой Морзе.Используйте
        механизмы пространств имён.*/

        static void Main()
        {
            while (true)
            {
                string text ="";
                int cod = 0;
                Console.WriteLine("Введите текст для шифрования/расшифрования");
                text = Console.ReadLine()!;
          
                Console.Write(@"Зашифровать или расшифровать введенный текст?
1-Зашифровать
0-Расшифровать
3-Закончить
Ввод: ");
                cod = Convert.ToInt32(Console.ReadLine());
                if (cod < 0 && cod > 3) throw new Exception("Введен не корректный выбор");


                try
                {

                    if (cod == 1)
                    {
                        text = Direct.Code(text);
                        Console.WriteLine($"Зашифрованный код:\n{text}");
                    }
                    else if (cod == 3)
                    {
                        Console.WriteLine("----Завершение программы----");
                        break;
                    }
                    else
                    {
                        text = Direct.UnCode(text);
                        Console.WriteLine($"Расшифрованный код:\n{text}");
                    }
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine((ex.Message)+"\nПопробуйте еще раз");

                }
            }
        }
    }
}