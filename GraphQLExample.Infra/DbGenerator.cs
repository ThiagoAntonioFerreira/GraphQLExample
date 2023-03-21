using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLExample.Infra
{
    public class DbGenerator
    {
        public static void Iniciar(IServiceProvider serviceProvider)
        {
            using (var contexto = new GraphQLContext(serviceProvider.GetRequiredService<DbContextOptions<GraphQLContext>>()))
            {
                if (contexto.Usuarios.Any())
                {
                    return;   // Dados ja foram providos
                }

                contexto.Usuarios.AddRange(
                    new User()
                    {
                        Id = 1,
                        Email = "thiago@teste.com.br",
                        Age = 40,
                        Name = "Thiago Antonio",
                        DateCreate = new DateTime(2019, 7, 7, 9, 50, 20)
                    },
                    new User()
                    {
                        Id = 2,
                        Email = "joao@teste.com.br",
                        Age = 29,
                        Name = "João Paulo",
                        DateCreate= new DateTime(2019, 7, 12, 9, 53, 12)
                    }
                    );
                contexto.SaveChanges();
            }
        }
    }
}
