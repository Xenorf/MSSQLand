﻿using System;
using System.Linq;

namespace MSSQLand.Utilities
{
    /// <summary>
    /// Provides logging functionality with compact and visually intuitive output.
    /// </summary>
    internal static class Logger
    {
        /// <summary>
        /// Indicates whether debug messages should be printed.
        /// </summary>
        public static bool IsDebugEnabled { get; set; } = false;

        /// <summary>
        /// Indicates whether all output should be suppressed.
        /// </summary>
        public static bool IsSilentModeEnabled { get; set; } = false;

        public static void NewLine()
        {
            if (IsSilentModeEnabled) return;
            Console.WriteLine();
        }

        public static void Banner(string message, char borderChar = '=')
        {
            if (IsSilentModeEnabled) return;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(new string(borderChar, 30)); // Default width for empty or null messages
                return;
            }

            string[] lines = message.Split('\n');
            int maxLineLength = lines.Max(line => line.Length);
            int padding = 2; // Padding on each side of the message
            int totalWidth = maxLineLength + (padding * 2);

            string border = new string(borderChar, totalWidth);
            Console.WriteLine(border);
            foreach (string line in lines)
            {
                string paddedLine = line.PadLeft((line.Length + padding), ' ').PadRight(totalWidth, ' ');
                Console.WriteLine(paddedLine);
            }
            Console.WriteLine(border);
            Console.ResetColor();
        }

        public static void Info(string message)
        {
            if (IsSilentModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[i] {message}");
            Console.ResetColor();
        }

        public static void Task(string message)
        {
            if (IsSilentModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"[>] {message}");
            Console.ResetColor();
        }

        public static void Success(string message)
        {
            if (IsSilentModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[+] {message}");
            Console.ResetColor();
        }

        public static void Debug(string message)
        {
            if (IsSilentModeEnabled || !IsDebugEnabled) return;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[*] {message}");
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            if (IsSilentModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[!] {message}");
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            if (IsSilentModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[-] {message}");
            Console.ResetColor();
        }

        public static void InfoNested(string message, int indentLevel = 0, string symbol = "|->")
        {
            if (IsSilentModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.White;
            string indent = new(' ', indentLevel * 4);
            Console.WriteLine($"{indent}{symbol} {message}");
            Console.ResetColor();
        }

        public static void SuccessNested(string message, int indentLevel = 0, string symbol = "|->")
        {
            if (IsSilentModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.Green;
            string indent = new(' ', indentLevel * 4);
            Console.WriteLine($"{indent}{symbol} {message}");
            Console.ResetColor();
        }

        public static void TaskNested(string message, int indentLevel = 0, string symbol = "|->")
        {
            if (IsSilentModeEnabled) return;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string indent = new(' ', indentLevel * 4);
            Console.WriteLine($"{indent}{symbol} {message}");
            Console.ResetColor();
        }

        public static void DebugNested(string message, int indentLevel = 0, string symbol = "|->")
        {
            if (IsSilentModeEnabled || !IsDebugEnabled) return;
            string indent = new(' ', indentLevel * 4);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{indent}{symbol} {message}");
            Console.ResetColor();
        }

        public static void ErrorNested(string message, int indentLevel = 0, string symbol = "|->")
        {
            if (IsSilentModeEnabled) return;
            string indent = new(' ', indentLevel * 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{indent}{symbol} {message}");
            Console.ResetColor();
        }

        public static void WarningNested(string message, int indentLevel = 0, string symbol = "|->")
        {
            if (IsSilentModeEnabled) return;
            string indent = new(' ', indentLevel * 4);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{indent}{symbol} {message}");
            Console.ResetColor();
        }
    }
}
