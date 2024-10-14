using System;
using System.Threading;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            int player = 0;
            int dealer = 0;
            int balance = 5000;
            int milliseconds = 1000;
            int playerResult = 0;
            int dealerResult = 0;
            Console.WriteLine($"Ваш баланс: {balance}$");

            Thread.Sleep(milliseconds);
            int bet;
            do
            {
                Console.Write("Сделайте ставку: ");
                bet = Convert.ToInt32(Console.ReadLine());

                if (bet > balance)
                {
                    Console.WriteLine("Ставка превышает баланс. Попробуйте снова.");
                }
                else if (bet <= 0)
                {
                    Console.WriteLine("Ставка должна быть больше 0. Попробуйте снова.");
                }
                else
                {
                    Console.WriteLine($"Вы сделали ставку: {bet}");
                    break;
                }

            } while (true);

            Random rnd = new Random();
            int playerCard = rnd.Next(2, 12);
            int dealerCard = rnd.Next(2, 12);
            int playerSecondCard = rnd.Next(2, 12);
            int dealerSecondCard = rnd.Next(2, 12);
            Console.WriteLine($"Ваши карты: {playerCard}, {playerSecondCard} = {playerCard + playerSecondCard}");
            Console.WriteLine($"Карта диллера: {dealerCard}, ?");
            Console.WriteLine("Хотите еще одну карту? Да : Нет");
            Console.ReadLine();
            string userInput = "";
            if (userInput == "Да" || userInput == "да")
            {
                int playerThirdCard = rnd.Next(2, 12);
                Console.WriteLine($"Ваш набор карт: {playerCard}, {playerSecondCard}, {playerThirdCard} = {playerCard + playerSecondCard + playerThirdCard}");
                playerResult = playerCard + playerSecondCard + playerThirdCard;
            }
            else
            {
                Console.WriteLine($"Ваш набор карт: {playerCard}, {playerSecondCard} = {playerCard + playerSecondCard}");
                playerResult = playerCard + playerSecondCard;
            }

            if(dealerCard + dealerSecondCard < 21)
            {
                int dealerThirdCard = rnd.Next(2, 12);
                dealerResult = playerCard + playerSecondCard + dealerThirdCard;
            }

            if(playerResult > dealerResult && playerResult <= 21)
            {
                balance = balance + bet + bet;
                Console.WriteLine($"Вы выйграли! ваш баланс {balance}");
                Console.WriteLine($"Карты диллера {dealerResult}");
            }
            else if(playerResult < dealerResult && dealerResult <= 21)
            {
                balance = balance - bet;
                Console.WriteLine($"Вы проиграли! ваш баланс {balance}");
                Console.WriteLine($"Карты диллера {dealerResult}");
            }
            else if (playerResult == dealerResult)
            {
                Console.WriteLine("Ничья!");
                Console.WriteLine($"Карты диллера {dealerResult}");
            }
        }
    }
}
