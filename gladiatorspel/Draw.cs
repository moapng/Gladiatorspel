﻿using System;
using System.Runtime.InteropServices;
namespace gladiatorspel
{
    public class Draw
    {
        const String Title = "[ GLADIATOR ]";
        private static int WIDTH;
        private static int HEIGHT;
        public static void InitWindow()
        {
            WIDTH = Console.WindowWidth;
            HEIGHT = Console.WindowHeight;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                Console.SetBufferSize(WIDTH + 1, HEIGHT + 1);
                Console.SetWindowSize(WIDTH + 1, HEIGHT + 1);
            }
            

            String topLeftCorner = "╔";
            String topRightCorner = "╗";
            String bottomRightCorner = "╝";
            String bottomLeftCorner = "╚";
            String standingEdge = "║";
            String lyingEdge = "═";

            for(int i = 0; i < WIDTH; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(lyingEdge);
                Console.SetCursorPosition(i, HEIGHT);
                Console.Write(lyingEdge);
            }
            for (int i = 0; i < HEIGHT; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(standingEdge);
                Console.SetCursorPosition(WIDTH, i);
                Console.Write(standingEdge);
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(topLeftCorner);
            Console.SetCursorPosition(WIDTH, 0);
            Console.Write(topRightCorner);
            Console.SetCursorPosition(0, HEIGHT);
            Console.Write(bottomLeftCorner);
            Console.SetCursorPosition(WIDTH, HEIGHT);
            Console.Write(bottomRightCorner);

            int TitlePos = (WIDTH / 2) - (Title.Length / 2);
            Console.SetCursorPosition(TitlePos, 0);
            Console.Write(Title);
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static void ShowText(String text, int line)
        {
            const int padding = 2;
            Console.SetCursorPosition(padding, line);
            Console.Write(text.PadRight(WIDTH - padding));
            Console.SetCursorPosition(WIDTH, line);
            Console.Write("║");
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static void ShowText(String text, int line, int paddingFromEnd)
        {
            const int padding = 2;
            Console.SetCursorPosition(padding, line);
            Console.Write(text.PadLeft(WIDTH - padding - 2));
            Console.SetCursorPosition(WIDTH, line);
            Console.Write("║");
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static String ShowTextInput(String text, int line)
        {
            ShowText(text, line);
            String input = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input += key.KeyChar;
                ShowText(text + input, line);
            }
            return input;
        }

        public static void ShowPlayerStats(Gladiator gladiator)
        {
            ShowText(gladiator.name + " [HP: " + gladiator.health + " Attack: " + gladiator.strength + "]", HEIGHT - 2);
        }

        public static void ShowPlayerInventory(Gladiator player)
        {
            int MaxWidth = 0;
            int Length = 10;
            foreach (Item item in player.inventory.inventoryList)
            {
                if (item.Name.Length > MaxWidth) {
                    MaxWidth = item.Name.Length;
                }
            }
            int MaxWidthFixed = MaxWidth + 8;
            String inventoryTitle = "[ INVENTORY ]";
            Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT - 2 - Length);
            Console.Write("╔" + inventoryTitle.PadBoth(MaxWidthFixed - 2, '═') + "╣");
            for (int i = 0; i < 10; i++)
            {
                String itemName = "";
                if (player.inventory.inventoryList.Count >= i + 1)
                {
                    itemName = (player.inventory.inventoryList[i] as Item).Name;
                }
                String drawString = "║ " + string.Format("{0:D2}", i + 1) + ") " + itemName.PadLeft(MaxWidth);
                Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT - 1 - Length + i);
                Console.Write(drawString);
                //Draw.ShowText(drawString, HEIGHT - 1 - Length + i, 10);
                
            }
            
            Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT);
            Console.Write("╩");
            Console.SetCursorPosition(WIDTH, HEIGHT);
        }

        public static void HidePlayerInventory(Gladiator player)
        {
            int MaxWidth = 0;
            int Length = 11;
            foreach (Item item in player.inventory.inventoryList)
            {
                if (item.Name.Length > MaxWidth)
                {
                    MaxWidth = item.Name.Length;
                }
            }
            int MaxWidthFixed = MaxWidth + 8;
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT - 2 - i);
                for(int n = WIDTH - MaxWidthFixed; n < WIDTH - 1; n++)
                {
                    Console.Write(" ");
                }

            }
            Console.SetCursorPosition(WIDTH - MaxWidthFixed, HEIGHT);
            Console.Write("═");
            Console.SetCursorPosition(WIDTH, HEIGHT - Length - 1);
            Console.Write("║");
            Console.SetCursorPosition(WIDTH, HEIGHT);

        }
    }
}
