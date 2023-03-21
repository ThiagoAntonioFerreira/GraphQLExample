using GraphQL.Types;
using GraphQLExample.Infra;
using System.Xml.Linq;

namespace GraphQLExample.Types
{
    public class UsuarioType : ObjectGraphType<User>
    {
        public UsuarioType()
        {
            Name = "Usuario";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id usuário");
        }
    }
}
