using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    public class ConsoleReader : IConsoleReader
    {
        public long[] ReadClientIds()
        {
            while (true)
            {
                Console.WriteLine("Введите id клиентов через пробел:");
                var input = Console.ReadLine();

                if (input is null)
                {
                    Console.WriteLine("Ошибка: необходимо ввести хотя бы один id клиента.");
                    continue;
                }

                var values = input.Split(new[] { ' ', '\t', '\n', '\r' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 0)
                {
                    Console.WriteLine("Ошибка: необходимо ввести хотя бы один id клиента.");
                    continue;
                }

                var clientIds = new long[values.Length];
                var isValid = true;

                for (var i = 0; i < values.Length; i++)
                {
                    if (!long.TryParse(values[i], out clientIds[i]))
                    {
                        Console.WriteLine($"Ошибка: '{values[i]}' не является корректным id клиента.");
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    return clientIds;
                }
            }
        }
    }
}
