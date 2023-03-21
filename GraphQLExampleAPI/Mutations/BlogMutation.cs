using GraphQL;
using GraphQL.Types;
using GraphQLExample.Infra;
using GraphQLExampleAPI.Types;
using System.Xml.Linq;

namespace GraphQLExampleAPI.Mutations
{
    public class BlogMutation : ObjectGraphType<object>
    {
        public BlogMutation(UserRepository repositorio)
        {
            Name = "Mutation";
            Field<UserType>("criarUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UserInputType>> { Name = "usuario" }
                ),
                resolve: context =>
                {
                    var usuario = context.GetArgument<User>("usuario");
                    return repositorio.Adicionar(usuario);
                });

            Field<UserType>("alterarUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UserInputType>> { Name = "usuario" },
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "usuarioId" }
                ),
                resolve: context =>
                {
                    var usuario = context.GetArgument<User>("usuario");
                    var id = context.GetArgument<int>("usuarioId");

                    var dbUsuario = repositorio.ObterUsuarioPorId(id);
                    if (dbUsuario == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    return repositorio.Alterar(dbUsuario, usuario);
                });

            Field<StringGraphType>("removerUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "usuarioId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("usuarioId");
                    var dbUsuario = repositorio.ObterUsuarioPorId(id);
                    if (dbUsuario == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    repositorio.Remover(dbUsuario);
                    return $"O usuario com id {id} foi removido";
                });
        }
    }
}
