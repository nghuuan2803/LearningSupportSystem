using StackExchange.Redis;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");
builder.AddProject<Projects.Web>("web").WithReference(redis); ;
builder.Build().Run();
