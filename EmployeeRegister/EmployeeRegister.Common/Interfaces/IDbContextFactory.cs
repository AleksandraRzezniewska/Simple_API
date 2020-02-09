namespace EmployeeRegister.Common.Interfaces
{
    public interface IDbContextFactory<T>
    {
        T Create();
    }
}
