using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLExample.Infra
{
    public class UserRepository
    {
        private readonly GraphQLContext _context;
        public UserRepository(GraphQLContext context)
        {
            _context = context;
        }
        public async Task<List<User>> ObterUsuarios(UserFilter filtro)
        {
            var query = _context.Usuarios.AsTracking();
            if (filtro.Id.HasValue && filtro.Id > 0)
                query = query.Where(w => w.Id == filtro.Id);
            if (!string.IsNullOrEmpty(filtro.Name))
                query = query.Where(w => filtro.Name.Contains(w.Name));
            return await query.ToListAsync();
        }

        public User Adicionar(User usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public User Alterar(User dbUsuario, User usuario)
        {

            dbUsuario.Name = usuario.Name;
            dbUsuario.Age = usuario.Age;

            _context.SaveChanges();

            return dbUsuario;
        }

        public User ObterUsuarioPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(f => f.Id == id);
        }

        public void Remover(User usuario)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
        }
    }
}

