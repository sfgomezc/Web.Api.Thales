using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Api.Thales.Interfaces
{
    public interface IEmployees
    {

        /// <summary>
        /// Consulta todos los empleados
        /// </summary>
        /// <param name=""></param>
        /// <returns>Lista de emepleados/returns>
        Task<EmployeesResult> GerEmployees();

        /// <summary>
        /// Consulta un empleado por id
        /// </summary>
        /// <param name="id">ID del empleado</param>
        /// <returns>Emepleado/returns>
        Task<EmployeeResult> GerEmployee(int id);
    }
}