using GraphQL.Types;
using GraphQLExample.Infra;
using System.Xml.Linq;

namespace GraphQLExampleAPI.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "Usuario";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id usuário");
            Field(x => x.Age).Description("Idade do usuário");
            Field(x => x.Name).Description("Nome do usuário");
            Field(x => x.DateCreate).Description("Data criação usuário");
            Field(x => x.DateUpdate).Description("Data alteração usuário");
        }
    }
}
