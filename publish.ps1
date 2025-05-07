# Очистка предыдущей сборки
Remove-Item -Path "bin\Release\net7.0-windows\publish" -Recurse -Force -ErrorAction SilentlyContinue

# Публикация приложения
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true

# Создание установщика
& "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" "setup.iss" 