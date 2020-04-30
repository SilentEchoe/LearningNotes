using GrpcServer.Web.Protos;
using System.Collections.Generic;

namespace GrpcServer.Web.Data
{
    public class InMemoryData
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee
            {
                Id =1 ,
                No=1994,
                FirstName = "Chandler",
                LastName = "Bing",
                Salary = 2200
            },
        new Employee
            {
                Id =2 ,
                No=1995,
                FirstName = "LASH",
                LastName = "ROAP",
                Salary = 2500
            },
        new Employee
            {
                Id =3 ,
                No=1996,
                FirstName = "AWDhandler",
                LastName = "AGAWg",
                Salary = 2800
            },
        };





    }
}
