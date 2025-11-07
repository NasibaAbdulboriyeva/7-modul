using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;

class Program
{
    static void Main()
    {
        // Excel fayl manzili
        string filePath = @"C:\Users\user\Downloads\Перекличка 10-2025.xlsx";

        // Faylni o‘qish
        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheet("records");

        // Username ustunini topamiz
        var usernames = new List<string>();

        // 2-qator (headerdan keyin) dan boshlab o‘qish
        foreach (var row in worksheet.RowsUsed().Skip(1))
        {
            string username = row.Cell(1).GetString().Trim(); // 1-ustun "Username"
            if (!string.IsNullOrWhiteSpace(username) &&
                username != "Датчик двери" &&
                username != "ПРЕДУПРЕЖДЕНИЕ!")
            {
                usernames.Add(username);
            }
        }

        // Unikal xodimlarni olish
        var uniqueEmployees = usernames.Distinct().ToList();

        // Raqam bilan chiqarish
        Console.WriteLine("Unikal ishchilar ro‘yxati:\n");
        for (int i = 0; i < uniqueEmployees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {uniqueEmployees[i]}");
        }

        Console.WriteLine($"\nJami: {uniqueEmployees.Count} ta xodim topildi.");
    }
}
