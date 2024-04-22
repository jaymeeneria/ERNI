using TechExam3.Model;

namespace TechExam3.Interface
{
    public interface IEmployeeRepository
    {
        List<EmployeeModel> GetEmployee(int id);
        EmployeeModel EditEmployee(EditEmployeeRequest request);
        EmployeeModel AddEmployee(AddEmployeeRequest request);
        EmployeeModel DeleteEmployee(int id);

    }
}
