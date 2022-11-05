using CommandLine;
using GitInsight;
using Npgsql;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var lookup = new Lookup();

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(o =>
    {
        Pgsql().GetAwaiter().GetResult();

        // switch (o.Mode)
        // {
        //     case Modes.Author:
        //         lookup.authorMode(o.RepoPath);
        //         break;

        //     case Modes.Frequency:
        //     default:
        //         lookup.commitFrequency(o.RepoPath);
        //         break;
        // }
    });

async Task Pgsql() {
    var connString = "Host=db:5432;Username=;Password=root;Database=gitinsight";

    using IHost host = Host.CreateDefaultBuilder(args).Build();

    // Ask the service provider for the configuration abstraction.
    IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

    // Get values from the config given their key and their target type.
    var hostname = config.GetValue<string>("HOST");
    var username = config.GetValue<string>("USERNAME");
    var password = config.GetValue<string>("PASSWORD");

    var builder = new NpgsqlConnectionStringBuilder(connString);

    builder.Host = hostname;
    builder.Username = username;
    builder.Password = username;

    var connection = builder.ConnectionString;

    await using var conn = new NpgsqlConnection(connection);
    await conn.OpenAsync();

    // Insert some data
    await using (var cmd = new NpgsqlCommand("INSERT INTO data (some_field) VALUES ($1)", conn))
    {
        cmd.Parameters.AddWithValue("Hello world");
        await cmd.ExecuteNonQueryAsync();
    }

    // Retrieve all rows
    await using (var cmd = new NpgsqlCommand("SELECT some_field FROM data", conn))
    await using (var reader = await cmd.ExecuteReaderAsync())
    {
        while (await reader.ReadAsync())
        {
            Console.WriteLine(reader.GetString(0));
        }
    }
}
