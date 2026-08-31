public interface IEmployeeService
{
    Task<Employee?> GetEmployeeByIdAsync(int id);
}

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _repository.GetEmployeeByIdAsync(id);
    }
}