using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace SecureNote
{
    public partial class MainWindow : Window
    {
        private readonly string _password;
        private string? _currentFilePath;

        public MainWindow(string password)
        {
            InitializeComponent();
            _password = password;
            UpdateWindowTitle();
        }

        private void UpdateWindowTitle()
        {
            Title = $"Безопасный блокнот - {_currentFilePath ?? "Новый файл"}";
        }

        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Создать новый файл? Несохраненные изменения будут потеряны.", 
                              "Подтверждение", 
                              MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                NoteTextBox.Clear();
                _currentFilePath = null;
                UpdateWindowTitle();
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Зашифрованные заметки (*.snote)|*.snote|Все файлы (*.*)|*.*",
                DefaultExt = ".snote"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var encryptedData = File.ReadAllBytes(dialog.FileName);
                    var decryptedData = ProtectedData.Unprotect(encryptedData, 
                                                              Encoding.UTF8.GetBytes(_password), 
                                                              DataProtectionScope.CurrentUser);
                    NoteTextBox.Text = Encoding.UTF8.GetString(decryptedData);
                    _currentFilePath = dialog.FileName;
                    UpdateWindowTitle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", 
                                  "Ошибка", 
                                  MessageBoxButton.OK, 
                                  MessageBoxImage.Error);
                }
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Зашифрованные заметки (*.snote)|*.snote|Все файлы (*.*)|*.*",
                DefaultExt = ".snote"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var noteBytes = Encoding.UTF8.GetBytes(NoteTextBox.Text);
                    var encryptedData = ProtectedData.Protect(noteBytes, 
                                                            Encoding.UTF8.GetBytes(_password), 
                                                            DataProtectionScope.CurrentUser);
                    File.WriteAllBytes(dialog.FileName, encryptedData);
                    _currentFilePath = dialog.FileName;
                    UpdateWindowTitle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", 
                                  "Ошибка", 
                                  MessageBoxButton.OK, 
                                  MessageBoxImage.Error);
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
} 