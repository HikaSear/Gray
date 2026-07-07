using System;
using System.Collections.Generic;
using System.Text;

namespace Gray.Core
{
    internal static class ResManager
    {
        public static string GetFileText(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Путь к файлу не может быть пустым", nameof(path));

            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            try
            {
                return File.ReadAllText(path, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                throw new IOException($"Ошибка при чтении файла: {ex.Message}", ex);
            }
        }
    }
}
