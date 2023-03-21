using GraphQL.Types;
using GraphQLExample.Infra;
using System.Xml.Linq;

namespace GraphQLExampleAPI.Types
{
    public class UserInputType : InputObjectGraphType<User>
    {
        public UserInputType()
        {
            Name = "UserInput";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id usuário");
            Field(x => x.Age).Description("Idade do usuário");
            Field(x => x.Name).Description("Nome do usuário");
            Field(x => x.DateCreate, type: typeof(DateTimeGraphType)).Description("Data criação usuário");
            Field(x => x.DateUpdate, type: typeof(DateTimeGraphType)).Description("Data alteração usuário");
        }
    }
}
