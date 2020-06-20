using Fleeter.Core.Models;
using Fleeter.Core.Repositories;
using Fleeter.Core.Services.Results;
using NHibernate;
using NHibernate.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Fleeter.Core.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FleeterService : IFleeterService
    {
        private readonly IBusinessUnitRepository _businessUnits;
        private readonly IEmployeeRepository _employees;
        private readonly IVehicleRepository _vehicles;

        public FleeterService(IBusinessUnitRepository businessUnits,
                              IVehicleRepository vehicles,
                              IEmployeeRepository employees)
        {
            _businessUnits = businessUnits;
            _vehicles = vehicles;
            _employees = employees;
        }

        public BaseResult CreateEmployeeRelation(Vehicle v, VehicleToEmployeeRelation r)
        {
            if (r.EndDate != null && r.StartDate > r.EndDate)
            {
                return new BaseResult
                {
                    Status = Status.BadRequest,
                    Message = "Startdatum muss vor dem Enddatum liegen"
                };
            }

            try
            {
                var vehicle = _vehicles.FindById(v.Id);

                if (vehicle is null)
                {
                    return new BaseResult
                    {
                        Status = Status.BadRequest,
                        Message = "Fahrzeug existiert nicht"
                    };
                }

                if (r.StartDate > vehicle.LeasingTo || r.StartDate < vehicle.LeasingFrom || r.EndDate > vehicle.LeasingTo || r.EndDate < vehicle.LeasingFrom)
                {
                    return new BaseResult
                    {
                        Status = Status.BadRequest,
                        Message = $"Relationen können nur während des Leasingzeitraumes erstellt werden ({vehicle.LeasingFrom} - {vehicle.LeasingTo})"
                    };
                }

                vehicle.AddRelation(r);

                _vehicles.Update(vehicle);

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
                    Message = "Verknüpfung konnte nicht erstellt werden:" + Environment.NewLine + ex.Message + Environment.NewLine + ex.InnerException?.Message
                };
            }
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
                        Message = "Beim Speichern ist ein Konflikt aufgetreten, laden sie die Daten neu"
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
            if (e.Firstname != null)
                e.Firstname = e.Firstname.Trim();
            if (e.Lastname != null)
                e.Lastname = e.Lastname.Trim();
            if (e.Title != null)
                e.Title = e.Title.Trim();
            if (e.Salutation != null)
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
                        Message = "Beim Speichern ist ein Konflikt aufgetreten, laden sie die Daten neu"
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
                    v.EmployeeRelations = null;
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
                        Message = "Beim Speichern ist ein Konflikt aufgetreten, laden sie die Daten neu"
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

        public BaseResult DeleteEmployeeRelation(Vehicle v, VehicleToEmployeeRelation r)
        {
            try
            {
                var vehicle = _vehicles.FindById(v.Id);

                if (vehicle is null)
                {
                    return new BaseResult
                    {
                        Status = Status.BadRequest,
                        Message = "Fahrzeug existiert nicht"
                    };
                }

                var wasRemoved = vehicle.RemoveRelation(r);

                if (!wasRemoved)
                {
                    return new BaseResult
                    {
                        Status = Status.InternalServerError,
                        Message = "Verknüpfung konnte nicht gelöscht werden"
                    };
                }

                _vehicles.Update(vehicle);

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
                    Message = ex.Message + Environment.NewLine + ex.InnerException?.Message
                };
            }
        }

        public BaseResult DeleteVehicle(Vehicle v)
        {
            try
            {
                var vehicle = _vehicles.FindById(v.Id);

                if (vehicle is null)
                {
                    return new BaseResult
                    {
                        Status = Status.BadRequest,
                        Message = "Fahrzeug existiert nicht"
                    };
                }

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

        public Dictionary<DateTime, MonthCostDetails> GetCostsPerMonth()
        {
            var vehicles = _vehicles.FindAll();
            var min = vehicles.Min(v => v.LeasingFrom);
            var max = vehicles.Max(v => v.LeasingTo);

            Dictionary<DateTime, MonthCostDetails> costsPerMonth = new Dictionary<DateTime, MonthCostDetails>();

            for (var act = new DateTime(min.Year, min.Month, 1); act < max; act = act.AddMonths(1))
            {
                var vehiclesForMonth = vehicles.Where(v => v.LeasingFrom <= act && v.LeasingTo >= act);
                var calc = new MonthCostDetails
                {
                    Count = vehiclesForMonth.Count(),
                    Costs = vehiclesForMonth.Select(v => v.LeasingRate + v.Insurance / 12).Sum()
                };
                costsPerMonth.Add(act, calc);
            }

            return costsPerMonth;
        }

        public IEnumerable<BusinessUnitCostDetails> GetCostsPerMonthPerBusinessUnit()
        {
            var vehicles = _vehicles.FindAll();
            var employees = _employees.FindAll();
            var businessUnits = _businessUnits.FindAll();
            var min = vehicles.Min(v => v.LeasingFrom);
            var max = vehicles.Max(v => v.LeasingTo);

            var relations = vehicles.SelectMany(v => v.EmployeeRelations);

            var result = businessUnits
                .Join(employees, b => b.Id, e => e.BusinessUnit.Id, (b, e) => new { BusinessUnit = b, Employee = e })
                .Join(relations, be => be.Employee.Id, ve => ve.Employee.Id, (be, ve) => new { BusinessUnitEmployee = be, VehicleEmployee = ve })
                .Join(vehicles, beve => beve.VehicleEmployee.Vehicle.Id, v => v.Id, (beve, v) => new { beve.BusinessUnitEmployee.BusinessUnit, beve.VehicleEmployee, Vehicle = v })
                .Select(m => new { m.BusinessUnit, Costs = GetCostsPerVehicle(m.VehicleEmployee, m.Vehicle) })
                .SelectMany(bv => bv.Costs.Select(c => new { VehicleCost = c, bv.BusinessUnit }))
                .GroupBy(cb => new { cb.VehicleCost.Month, cb.BusinessUnit })
                .Select(cb => new BusinessUnitCostDetails { Month = cb.Key.Month, BusinessUnit = cb.Key.BusinessUnit, Costs = cb.Sum(c => c.VehicleCost.Costs) });

            return result;
        }

        private IEnumerable<(DateTime Month, int Count, decimal Costs)> GetCostsPerVehicle(VehicleToEmployeeRelation vehicleEmployee, Vehicle vehicle)
        {
            for (DateTime i = vehicleEmployee.StartDate; i < (vehicleEmployee.EndDate ?? DateTime.Now); i = i.AddMonths(1))
            {
                yield return (new DateTime(i.Year, i.Month, 1), 1, vehicle.Insurance / 12 + vehicle.LeasingRate);
            }
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

    public class MonthCostDetails
    {
        public int Count { get; set; }
        public decimal Costs { get; set; }
    }

    public class BusinessUnitCostDetails
    {
        public DateTime Month { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public decimal Costs { get; set; }
    }
}
