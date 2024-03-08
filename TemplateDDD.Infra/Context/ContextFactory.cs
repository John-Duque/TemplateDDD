// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;

// namespace TemplateDDD.Infra.Context
// {
//     public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
//     { 
//         //Todo: Utilizado somente para migrações simples
//         public MyContext CreateDbContext(string[] args)
//         {
//             //Usado para Criar as Migrações
//             var connectionString = "";
//             var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
//             optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//             return new MyContext(optionsBuilder.Options);
//         }
//     }
// }
