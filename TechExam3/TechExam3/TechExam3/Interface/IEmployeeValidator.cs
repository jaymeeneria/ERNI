using TechExam3.Model;

namespace TechExam3.Interface
{
    public interface IEmployeeValidator
    {
        ValidatorResponse ValidateRequest(AddEmployeeRequest createEmployee);
        ValidatorResponse ValidateRequest(EditEmployeeRequest editEmployeeRequest);
    }
}
