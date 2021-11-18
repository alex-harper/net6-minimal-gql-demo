global using GraphQL;
global using GraphQL.Types;
global using GraphQL.SystemTextJson;
global using GraphQL.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<StarWarsSchema>();
builder.Services.AddGraphQL((options, provider) =>
{
    options.EnableMetrics = true;
}).AddSystemTextJson()
.AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
.AddGraphTypes(typeof(StarWarsSchema));

var app = builder.Build();

// add http for Schema at default url /graphql
app.UseGraphQL<StarWarsSchema>();

// use graphql-playground at default url /ui/playground
app.UseGraphQLPlayground();

app.Run();