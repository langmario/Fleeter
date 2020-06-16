using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services.Results;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Fleeter.Core.Services
{
    public class FleeterService : IFleeterService
    {
        private readonly IBusinessUnitRepository _businessUnits;
        private readonly IEmployeeRepository _employees;
        private readonly IVehicleRepository _vehicles;

        public FleeterService(IBusinessUnitRepository businessUnits, IVehicleRepository vehicles, IEmployeeRepository employees)
        {
            _businessUnits = businessUnits;
            _vehicles = vehicles;
            _employees = employees;
        }

        public BaseResult CreateOrUpdateBusinessUnit(BusinessUnit bu)
        {
            if (bu.Id > 0) // Update
            {
                try
                {
                    _businessUnits.Update(bu);
                    return new BaseResult
                    {
                        Status = Status.Updated
                    };
                }
                catch (StaleObjectStateException ex)
                {
                    return new BaseResult
                    {
                        Status = Status.Conflict,
                        Message = "Beim Speichern ist ein Konflikt aufgetreten"
                    };
                }
                catch (Exception ex)
                {
                    return new BaseResult
                    {
                        Status = Status.InternalServerError,
                        Message = ex.Message
                    };
                }
            }
            else // Create
            {
                try
                {
                    _businessUnits.Create(bu);
                    return new BaseResult
                    {
                        Status = Status.Created
                    };
                }
                catch (Exception ex)
                {
                    return new BaseResult
                    {
                        Status = Status.InternalServerError,
                        Message = ex.Message
                    };
                }
            }
        }

        public BaseResult CreateOrUpdateEmployee(Employee e)
        {
            throw new NotImplementedException();
        }

        public BaseResult CreateOrUpdateVehicle(Vehicle v)
        {
            throw new NotImplementedException();
        }

        public BaseResult DeleteBusinessUnit(BusinessUnit bu)
        {
            try
            {
                _businessUnits.Delete(bu);
                return new BaseResult
                {
                    Status = Status.Deleted
                };
            }
            catch (Exception ex)
            {
                return new BaseResult
                {
                    Status = Status.InternalServerError,
                    Message = ex.Message
                };
            }
        }

        public BaseResult DeleteEmployee(Employee e)
        {
            throw new NotImplementedException();
        }

        public BaseResult DeleteVehicle(Vehicle v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessUnit> GetBusinessUnits()
        {
            return _businessUnits.FindAll();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees.FindAll();
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicles.FindAll();
        }
    }
}
