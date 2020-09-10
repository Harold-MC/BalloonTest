# Pasos de Instalación:

## Backend:

- cd balloon-backend/Balloon
- Verificar que connectionString "MainConnection" sea correcto.
- dotnet ef database update
- Validar que el puerto 5000 este disponible
- dotnet run

## Frontend:

- cd balloon-frontend
- yarn install / npm install
- Validar que el puerto 8080 este disponible
- yarn serve / npm run serve
