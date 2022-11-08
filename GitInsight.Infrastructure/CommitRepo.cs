using Microsoft.EntityFrameworkCore;

namespace GitInsight.Infrastructure;

class CommitRepo
{
    private readonly DbContext _context;

    public CommitRepo(DbContext context)
    {
        this._context = context;
    }

    public (String msg, int id) Create()
    {
        Console.WriteLine("");

        return ("hello", 1);
    }

    public (String msg, int id) Read()
    {
        Console.WriteLine("");

        return ("hello", 1);
    }

    public (String msg, int id) Update()
    {
        Console.WriteLine("");

        return ("hello", 1);
    }

    public (String msg, int id) Delete()
    {
        Console.WriteLine("");

        return ("hello", 1);
    }
}
