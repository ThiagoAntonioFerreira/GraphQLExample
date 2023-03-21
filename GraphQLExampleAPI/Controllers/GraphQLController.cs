using GraphQL;
using GraphQLExampleAPI.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GraphQLExampleAPI.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly BlogSchema _schema;

        public GraphQLController(BlogSchema schema)
        {
            _schema = schema;
        }
        

    }
}