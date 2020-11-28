using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chess2._0
{
    class Program
    {
        private static bool InputNotTheSame( string start, string end)
        {
            return start[0] == end[0] && start[1] == end[1];
        }
        private static bool CheckCorrectOfCoord(string coord)
        {
            if (coord.Length == 2)
            {
                char letter = coord[0];
                char num = coord[1];

                return letter >= 'A' && letter <= 'H' && num >= '1' && num <= '8';
            }
            else return (false);
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
            Knight = 1,
            Bishop = 2,
            Rook = 3,
            Queen = 4,
            King = 5, 
            Pawn = 6
        }
        private static FigureType ReadFigureType()
        {
            do
            {
                Console.WriteLine("Введите тип фигуры \n (Конь / 1), (Слон / 2), (Ладья / 3), (Королева / 4), (Король / 5), (Пешка / 6)");
                string input = Console.ReadLine();

                if (input == "1" || input.ToLower() == "knight" || input.ToLower() == "конь")
                    return FigureType.Knight;
                else if (input == "2" || input.ToLower() == "bishop" || input.ToLower() == "слон")
                    return FigureType.Bishop;
                else if (input == "3" || input.ToLower() == "rook" || input.ToLower() == "ладья")
                    return FigureType.Rook;
                else if (input == "4" || input.ToLower() == "queen" || input.ToLower() == "королева")
                    return FigureType.Queen;
                else if (input == "5" || input.ToLower() == "king" || input.ToLower() == "король")
                    return FigureType.King;
                else if (input == "6" || input.ToLower() == "pawn" || input.ToLower() == "пешка")
                    return FigureType.Pawn;
                else
                    Console.WriteLine("Название фигуры не корректно");
            }
            while (true);
        }

        private static bool IsKnightCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            return dx + dy == 3 && dx * dy == 2;
        }

        private static bool IsBishopCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            return (dx - dy) == 0;
        }

        private static bool IsRookCorrect(string start, string end)
        {
            return start[0] == end[0] || start[1] == end[1];
        }

        private static bool IsQueenCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            if (dx - dy == 0)
                return IsBishopCorrect(start, end);
            else if (dx == 0 || dy == 0)
                return IsRookCorrect(start, end);
            else
                return (false);
        }

        private static bool IsKingCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            return dx + dy == 1 || dx * dy == 1;
        }

        private static bool IsPawnCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            return (dy == 1 || dy == 2) || (dy - dx == 1);
        }
        static void Main()
        {
            FigureType figure = ReadFigureType();

            Console.WriteLine("Введите стартовую координату:");
            string start = ReadCoord();

            Console.WriteLine("Введите конечную координаты:");
            string end = ReadCoord();

            if (InputNotTheSame(start, end))
            {
                Console.WriteLine("Не корректный ввод координат");
                Thread.Sleep(1000);
                Console.Clear();
                Main();
            }
            bool isCorrect = false;
            switch(figure)
            {
                case FigureType.Knight:
                    isCorrect = IsKnightCorrect(start, end);
                    break;
                case FigureType.Bishop:
                    isCorrect = IsBishopCorrect(start, end);
                    break;
                case FigureType.Rook:
                    isCorrect = IsRookCorrect(start, end);
                    break;
                case FigureType.Queen:
                    isCorrect = IsQueenCorrect(start, end);
                    break;
                case FigureType.King:
                    isCorrect = IsKingCorrect(start, end);
                    break;
                case FigureType.Pawn:
                    isCorrect = IsPawnCorrect(start, end);
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
