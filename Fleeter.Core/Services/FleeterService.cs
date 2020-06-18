using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services.Results;
using NHibernate;
using NHibernate.Exceptions;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Fleeter.Core.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FleeterService : IFleeterService
    {
        private readonly IBusinessUnitRepository _businessUnits;
        private readonly IEmployeeRepository _employees;
        private readonly IVehicleToEmployeeRelationRepository _vehicleToEmployeeRelations;
        private readonly IVehicleRepository _vehicles;

        public FleeterService(IBusinessUnitRepository businessUnits,
                              IVehicleRepository vehicles,
                              IEmployeeRepository employees,
                              IVehicleToEmployeeRelationRepository vehicleToEmployeeRelations)
        {
            _businessUnits = businessUnits;
            _vehicles = vehicles;
            _employees = employees;
            _vehicleToEmployeeRelations = vehicleToEmployeeRelations;
        }

        public BaseResult CreateEmployeeRelation(VehicleToEmployeeRelation r)
        {
            throw new NotImplementedException();
        }

        public BaseResult CreateOrUpdateBusinessUnit(BusinessUnit bu)
        {
            bu.Name = bu.Name.Trim();
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
                    var saved = _businessUnits.FindByName(bu.Name);
                    if (!(saved is null))
                    {
                        return new BaseResult
                        {
                            Status = Status.BadRequest,
                            Message = "Es existiert bereits eine Abteilung mit diesem Namen"
                        };
                    }
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
            e.Firstname = e.Firstname.Trim();
            e.Lastname = e.Lastname.Trim();
            e.Title = e.Title.Trim();
            e.Salutation = e.Salutation.Trim();

            if (e.Id > 0) // Update
            {
                try
                {
                    _employees.Update(e);
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
                    var saved = _employees.FindByEmployeeNumber(e.EmployeeNumber);
                    if (!(saved is null))
                    {
                        return new BaseResult
                        {
                            Status = Status.BadRequest,
                            Message = "Es existiert bereits ein Mitarbeiter mit dieser Personalnummer"
                        };
                    }
                    _employees.Create(e);
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

        public BaseResult CreateOrUpdateVehicle(Vehicle v)
        {
            if (v.Id > 0) // Update
            {
                try
                {
                    _vehicles.Update(v);
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
            else // Save
            {
                try
                {
                    var saved = _vehicles.FindByLicensePlate(v.LicensePlate);
                    if (!(saved is null))
                    {
                        return new BaseResult
                        {
                            Status = Status.BadRequest,
                            Message = "Es existiert bereits ein Fahrzeug mit diesem Nummernschild"
                        };
                    }
                    _vehicles.Create(v);
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
            catch (GenericADOException ex)
            {
                return new BaseResult
                {
                    Status = Status.Cascade,
                    Message = "Geschäftsbereich kann nicht gelöscht werden, möglicherweise existieren noch verknüpfte Datensätze"
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
            try
            {
                _employees.Delete(e);
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

        public BaseResult DeleteEmployeeRelation(VehicleToEmployeeRelation r)
        {
            try
            {
                _vehicleToEmployeeRelations.Delete(r);
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

        public BaseResult DeleteVehicle(Vehicle v)
        {
            try
            {
                _vehicles.Delete(v);
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
