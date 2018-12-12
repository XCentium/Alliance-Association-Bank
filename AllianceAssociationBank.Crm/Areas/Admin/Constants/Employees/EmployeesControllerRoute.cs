using AllianceAssociationBank.Crm.Constants;

namespace AllianceAssociationBank.Crm.Areas.Admin.Constants.Employees
{
    public static class EmployeesControllerRoute
    {
        public const string GetEmployees = ControllerName.Employees + "GetEmployees";
        public const string CreateEmployee = ControllerName.Employees + "CreateEmployee";
        public const string CreateEmployeeHttpPost = ControllerName.Employees + "CreateEmployeeHttpPost";
        public const string ConfirmDeleteEmployee = ControllerName.Employees + "ConfirmDeleteEmployee";
        public const string DeleteEmployee = ControllerName.Employees + "DeleteEmployee";
    }
}