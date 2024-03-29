﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }


        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
          return  _context.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return employeeChanges;


        }
    }
}
