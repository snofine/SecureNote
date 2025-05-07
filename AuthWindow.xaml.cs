using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace SecureNote
{
    public partial class AuthWindow : Window
    {
        private const string PasswordFile = "password.dat";
        private const string Salt = "SecureNoteSalt"; // В реальном приложении следует использовать случайную соль

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                StatusText.Text = "Введите пароль";
                return;
            }

            if (!File.Exists(PasswordFile))
            {
                StatusText.Text = "Сначала зарегистрируйтесь";
                return;
            }

            var hashedPassword = HashPassword(PasswordBox.Password);
            var savedHash = File.ReadAllText(PasswordFile);

            if (hashedPassword == savedHash)
            {
                var mainWindow = new MainWindow(PasswordBox.Password);
                mainWindow.Show();
                Close();
            }
            else
            {
                StatusText.Text = "Неверный пароль";
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                StatusText.Text = "Введите пароль";
                return;
            }

            if (File.Exists(PasswordFile))
            {
                StatusText.Text = "Пользователь уже зарегистрирован";
                return;
            }

            var hashedPassword = HashPassword(PasswordBox.Password);
            File.WriteAllText(PasswordFile, hashedPassword);

            StatusText.Text = "Регистрация успешна";
            LoginButton.IsEnabled = true;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = password + Salt;
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            return Convert.ToBase64String(hashedBytes);
        }
    }
} 