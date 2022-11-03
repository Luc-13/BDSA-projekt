using System.Collections;
using System.ComponentModel;
using CommandLine;
using GitInsight;
using LibGit2Sharp;
using Npgsql;

var lookup = new Lookup();

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(o =>
    {
        switch (o.Mode)
        {
            case Modes.Author:
                lookup.authorMode(o.RepoPath);
                break;

            case Modes.Frequency:
            default:
                lookup.commitFrequency(o.RepoPath);
                break;
        }

        Pgsql().GetAwaiter().GetResult();
    });

async Task Pgsql() {
    var connString = "Host=host.docker.internal:54320;Username=root;Password=root;Database=gitinsight";

    await using var conn = new NpgsqlConnection(connString);
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
