using GraphQL.Types;
using System.Xml.Linq;

namespace GraphQLExampleAPI.Types
{
    public class UserInputType : InputObjectGraphType<User>
    {
        public UserInputType()
        {
            Name = "UserInput";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id usuário");
            Field(x => x.Idade).Description("Idade do usuário");
            Field(x => x.Nome).Description("Nome do usuário");
            Field(x => x.DataCriacao, type: typeof(DateTimeGraphType)).Description("Data criação usuário");
            Field(x => x.DataAlteracao, type: typeof(DateTimeGraphType)).Description("Data alteração usuário");
        }
    }
}
