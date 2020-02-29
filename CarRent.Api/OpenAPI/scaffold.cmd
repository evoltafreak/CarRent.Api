dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=admin;database=carrent" MySql.Data.EntityFrameworkCore -o EF -f
