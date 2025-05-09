# SecureNote

Безопасный текстовый редактор с шифрованием файлов.

## Возможности

- 🔐 Регистрация и авторизация с паролем
- 🔒 Шифрование файлов с использованием AES-256
- 🌓 Поддержка темной и светлой темы
- ⏱️ Автоматическая блокировка при неактивности
- 📥 Импорт/экспорт текстовых файлов
- 🖱️ Drag & Drop поддержка
- 🎨 Простой и понятный интерфейс

## Что нового в версии 1.1.0

### Улучшения безопасности
- 🔐 Усиленное хеширование паролей с использованием SHA-512
- 🔑 Возможность смены пароля (требуется знание текущего пароля)
- 🔒 Увеличенный размер соли для шифрования
- ⚡ Увеличено количество итераций для генерации ключа

### Новые функции
- 🌓 Добавлена поддержка темной и светлой темы
- 📥 Добавлен импорт обычных текстовых файлов
- 📤 Добавлен экспорт заметок в обычные текстовые файлы
- 🎯 Упрощен интерфейс для удобства использования

## Требования

- Windows 7 или новее
- .NET 7.0 Runtime

## Установка

### Вариант 1: Установщик (рекомендуется)
1. Скачайте `SecureNote-Setup.exe ` из раздела [Releases](https://github.com/snofine/SecureNote/releases)
2. Запустите установщик и следуйте инструкциям
3. Программа будет установлена в Program Files и добавлена в меню Пуск

### Вариант 2: Портативная версия
1. Скачайте `SecureNote-Portable.zip` из раздела [Releases](https://github.com/snofine/SecureNote/releases)
2. Распакуйте архив в любую папку
3. Запустите `SecureNote.exe`

## Сборка из исходного кода

1. Клонируйте репозиторий:
```bash
git clone https://github.com/yourusername/SecureNote.git
```

2. Откройте решение в Visual Studio 2022 или новее

3. Восстановите пакеты NuGet:
```bash
dotnet restore
```

4. Соберите проект:
```bash
dotnet build
```

5. Запустите приложение:
```bash
dotnet run
```

## Безопасность

- 🔒 Все файлы шифруются с использованием AES-256
- 🔐 Пароли хешируются с использованием PBKDF2 и SHA-512
- 🎲 Соль генерируется криптографически стойким генератором случайных чисел
- ⚡ 100,000 итераций для генерации ключа
- ⏱️ Автоматическая блокировка через 3 минуты неактивности

## Лицензия

MIT License - подробности в файле [LICENSE](LICENSE) 
