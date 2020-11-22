using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess2._0
{
    class Program
    {
        private static bool CheckCorrectOfCoord(string coord)
        {
            char letter = coord[0];
            char num = coord[1];
            return coord.Length == 2 && letter >= 'A' && letter <= 'H' && num >= '1' && num <= '8';
        }

        private static string ReadCoord()
        {
            do
            {
                string input = Console.ReadLine().ToUpper();
                if (CheckCorrectOfCoord(input))
                    return input;
                else
                    Console.WriteLine("Координата не корректна");
            }
            while (true);
        }
        enum FigureType
        {
            Knight = 1
        }
        private static FigureType ReadFigureType()
        {
            do
            {
                Console.WriteLine("Введите тип фигуры \n (Конь / 1), (Слон / 2), (Ладья / 3), (Королева / 4), (Король / 5), (Пешка / 6)");
                string input = Console.ReadLine();
                if (input == "1" || input.ToLower() == "knight" || input.ToLower() == "конь")
                    return FigureType.Knight;
                else
                    Console.WriteLine("Название фигуры не корректно");
            }
            while (true);
        }

        private static bool IsknightCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            return dx + dy == 3 && dx * dy == 2;
        }
        static void Main(string[] args)
        {
            FigureType figure = ReadFigureType();

            Console.WriteLine("Введите стартовую координату:");
            string start = ReadCoord();

            Console.WriteLine("Введите конечную координаты:");
            string end = ReadCoord();

            bool isCorrect = false;
            switch(figure)
            {
                case FigureType.Knight:
                    isCorrect = IsknightCorrect(start, end);
                    break;
            }

            if (isCorrect)
                Console.WriteLine("Ваша фигура ходит правильно.");
            else
                Console.WriteLine("Такой ход не возможен для данной фигуры.");

            Console.ReadLine();
        }
    }
}
