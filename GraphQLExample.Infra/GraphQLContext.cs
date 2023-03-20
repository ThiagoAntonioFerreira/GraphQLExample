using Microsoft.EntityFrameworkCore;

namespace GraphQLExample.Infra
{
    public class GraphQLContext : DbContext
    {
        public GraphQLContext(DbContextOptions<GraphQLContext> opcoes) : base(opcoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}