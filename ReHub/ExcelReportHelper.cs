using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ReHub
{
    public static class ExcelReportHelper
    {
        public static void GenerateElectiveReport(DataTable data, string fileName)
        {
            try
            {
                // Генерируем CSV файл с правильным разделителем столбцов
                StringBuilder csvContent = new StringBuilder();

                // Заголовки (первая строка)
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    csvContent.Append(EscapeCsvValue(data.Columns[i].ColumnName));
                    if (i < data.Columns.Count - 1)
                        csvContent.Append(";"); // Используем точку с запятой как разделитель
                }
                csvContent.AppendLine();

                // Данные (каждая строка - отдельная запись)
                foreach (DataRow row in data.Rows)
                {
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        var value = row[i];
                        if (value != DBNull.Value)
                        {
                            csvContent.Append(EscapeCsvValue(value.ToString()));
                        }
                        else
                        {
                            csvContent.Append(""); // Пустое значение для NULL
                        }

                        if (i < data.Columns.Count - 1)
                            csvContent.Append(";");
                    }
                    csvContent.AppendLine(); // Переход на новую строку для следующей записи
                }

                // Сохраняем файл
                SaveCsvFile(csvContent.ToString(), fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void GenerateFullReport(DataTable electivesData, DataTable teachersData,
                                            DataTable studentsData, DataTable applicationsData, string fileName)
        {
            try
            {
                // Создаем ZIP архив с несколькими CSV файлами
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "ZIP files (*.zip)|*.zip";
                    saveDialog.FileName = fileName;
                    saveDialog.DefaultExt = ".zip";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string tempDir = Path.Combine(Path.GetTempPath(), "ReHub_Reports_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                        Directory.CreateDirectory(tempDir);

                        try
                        {
                            // Сохраняем каждый DataTable в отдельный CSV файл
                            if (electivesData.Rows.Count > 0)
                                SaveDataTableToCsv(electivesData, Path.Combine(tempDir, "Факультативы.csv"));

                            if (teachersData.Rows.Count > 0)
                                SaveDataTableToCsv(teachersData, Path.Combine(tempDir, "Преподаватели.csv"));

                            if (studentsData.Rows.Count > 0)
                                SaveDataTableToCsv(studentsData, Path.Combine(tempDir, "Студенты.csv"));

                            if (applicationsData.Rows.Count > 0)
                                SaveDataTableToCsv(applicationsData, Path.Combine(tempDir, "Заявки.csv"));

                            // Создаем ZIP архив
                            System.IO.Compression.ZipFile.CreateFromDirectory(tempDir, saveDialog.FileName);

                            MessageBox.Show($"Полный отчет успешно сохранен в ZIP архиве:\n{saveDialog.FileName}\n\n" +
                                          "Архив содержит CSV файлы, которые можно открыть в Excel.", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            // Очищаем временную директорию
                            if (Directory.Exists(tempDir))
                            {
                                try { Directory.Delete(tempDir, true); } catch { }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации полного отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void SaveDataTableToCsv(DataTable data, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();

            // Заголовки
            for (int i = 0; i < data.Columns.Count; i++)
            {
                csvContent.Append(EscapeCsvValue(data.Columns[i].ColumnName));
                if (i < data.Columns.Count - 1)
                    csvContent.Append(";");
            }
            csvContent.AppendLine();

            // Данные
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    var value = row[i];
                    if (value != DBNull.Value)
                    {
                        csvContent.Append(EscapeCsvValue(value.ToString()));
                    }

                    if (i < data.Columns.Count - 1)
                        csvContent.Append(";");
                }
                csvContent.AppendLine();
            }

            File.WriteAllText(filePath, csvContent.ToString(), Encoding.UTF8);
        }

        private static string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            // Если значение содержит точку с запятой, кавычки или перенос строки - обрамляем в кавычки
            if (value.Contains(";") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r") || value.Contains(","))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private static void SaveCsvFile(string content, string fileName)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    saveDialog.FileName = Path.ChangeExtension(fileName, ".csv");
                    saveDialog.DefaultExt = ".csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveDialog.FileName, content, Encoding.UTF8);

                        // Показываем инструкцию по открытию в Excel
                        MessageBox.Show($"Отчет успешно сохранен:\n{saveDialog.FileName}\n\n" +
                                      "Инструкция для открытия в Excel:\n" +
                                      "1. Откройте Excel\n" +
                                      "2. Выбете 'Данные' → 'Из текста/CSV'\n" +
                                      "3. Выберите файл и укажите разделитель 'точка с запятой'\n" +
                                      "4. Нажмите 'Загрузить'", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Альтернативный метод с табуляцией (лучше открывается в Excel)
        public static void GenerateTabDelimitedReport(DataTable data, string fileName, string reportName)
        {
            try
            {
                StringBuilder content = new StringBuilder();

                // Заголовки с табуляцией
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    content.Append(data.Columns[i].ColumnName);
                    if (i < data.Columns.Count - 1)
                        content.Append("\t");
                }
                content.AppendLine();

                // Данные с табуляцией
                foreach (DataRow row in data.Rows)
                {
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        var value = row[i];
                        if (value != DBNull.Value)
                        {
                            content.Append(value.ToString());
                        }

                        if (i < data.Columns.Count - 1)
                            content.Append("\t");
                    }
                    content.AppendLine();
                }

                SaveTabDelimitedFile(content.ToString(), fileName, reportName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void SaveTabDelimitedFile(string content, string fileName, string reportName)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialog.FileName = $"{reportName}_{DateTime.Now:yyyyMMdd}";
                    saveDialog.DefaultExt = ".txt";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveDialog.FileName, content, Encoding.UTF8);

                        MessageBox.Show($"Отчет успешно сохранен:\n{saveDialog.FileName}\n\n" +
                                      "Файл использует табуляцию как разделитель и должен правильно открываться в Excel.",
                                      "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для создания правильного CSV с запятыми (международный стандарт)
        public static void GenerateInternationalCsvReport(DataTable data, string fileName, string reportName)
        {
            try
            {
                StringBuilder csvContent = new StringBuilder();

                // Заголовки с запятыми
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    csvContent.Append(EscapeCsvValueInternational(data.Columns[i].ColumnName));
                    if (i < data.Columns.Count - 1)
                        csvContent.Append(",");
                }
                csvContent.AppendLine();

                // Данные с запятыми
                foreach (DataRow row in data.Rows)
                {
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        var value = row[i];
                        if (value != DBNull.Value)
                        {
                            csvContent.Append(EscapeCsvValueInternational(value.ToString()));
                        }

                        if (i < data.Columns.Count - 1)
                            csvContent.Append(",");
                    }
                    csvContent.AppendLine();
                }

                SaveInternationalCsvFile(csvContent.ToString(), fileName, reportName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeCsvValueInternational(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            // Экранируем кавычки и переносы строк
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        private static void SaveInternationalCsvFile(string content, string fileName, string reportName)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    saveDialog.FileName = $"{reportName}_{DateTime.Now:yyyyMMdd}";
                    saveDialog.DefaultExt = ".csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveDialog.FileName, content, Encoding.UTF8);

                        MessageBox.Show($"Отчет успешно сохранен:\n{saveDialog.FileName}\n\n" +
                                      "Это CSV файл международного формата с запятыми как разделителями.",
                                      "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}