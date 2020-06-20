using Fleeter.Core.Models;
using Fleeter.Core.Services.Results;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Fleeter.Core.Services
{
    [ServiceContract]
    public interface IFleeterService
    {
        // BUSINESS UNITS
        [OperationContract]
        IEnumerable<BusinessUnit> GetBusinessUnits();

        [OperationContract]
        BaseResult CreateOrUpdateBusinessUnit(BusinessUnit bu);

        [OperationContract]
        BaseResult DeleteBusinessUnit(BusinessUnit bu);


        // EMPLOYEES
        [OperationContract]
        IEnumerable<Employee> GetEmployees();

        [OperationContract]
        BaseResult CreateOrUpdateEmployee(Employee e);

        [OperationContract]
        BaseResult DeleteEmployee(Employee e);


        // VEHICLES
        [OperationContract]
        IEnumerable<Vehicle> GetVehicles();

        [OperationContract]
        BaseResult CreateOrUpdateVehicle(Vehicle v);

        [OperationContract]
        BaseResult DeleteVehicle(Vehicle v);


        // EMPLOYEE VEHICLE RELATIONS
        [OperationContract]
        BaseResult DeleteEmployeeRelation(Vehicle v, VehicleToEmployeeRelation r);

        [OperationContract]
        BaseResult CreateEmployeeRelation(Vehicle v, VehicleToEmployeeRelation r);

        // CALCULATIONS
        [OperationContract]
        Dictionary<DateTime, MonthCostDetails> GetCostsPerMonth();

        [OperationContract]
        IEnumerable<BusinessUnitCostDetails> GetCostsPerMonthPerBusinessUnit();
    }
}
