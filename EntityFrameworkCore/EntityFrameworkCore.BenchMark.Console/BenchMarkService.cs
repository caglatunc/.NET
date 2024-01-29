using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.BenchMark.Console;
public class BenchMarkService
{
    AppDbContext context = new();

    [Benchmark(Baseline = true)]
    public async Task ToListAsync()
    {
        await context.ShoppingCarts.ToListAsync();
    }

    [Benchmark]
    public void ToList()
    {
       context.ShoppingCarts.ToList();
    }
}
