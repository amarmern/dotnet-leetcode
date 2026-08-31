public interface IEmployeeRepository
{
    Task<Employee?> GetEmployeeByIdAsync(int id);
}

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}