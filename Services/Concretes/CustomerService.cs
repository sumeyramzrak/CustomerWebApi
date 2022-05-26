using Data;
using Data.Context;
using HW_CreateCustomerApi_Common.Dtos;
using HW_CreateCustomerApi_Services.Abstractions;

namespace HW_CreateCustomerApi_Services.Concretes
{
    internal class CustomerService : ICustomerService
    {
        private readonly NorthwindDbContext dbContext;

        public CustomerService(NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<GetAllCustomersDto> GetAllCustomers()
        {
            var data = dbContext.Customers.Select(x => new GetAllCustomersDto
            {
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle
            }).ToList();

            return data;
        }

        public GetCustomerByIdDto GetCustomerById(string id)
        {
            return dbContext.Customers.Where(x => x.CustomerID == id.ToUpper())
                                       .Select(s => new GetCustomerByIdDto
                                       {
                                           CustomerID = s.CustomerID,
                                           CompanyName = s.CompanyName,
                                           ContactName = s.ContactName,
                                           ContactTitle = s.ContactTitle,
                                           Country = s.Country
                                       }).SingleOrDefault();
        }

        public bool AddNewCustomer(AddNewCustomerDto dto)
        {
            //var valid = dbContext.Customers.SingleOrDefault(x => x.CustomerID == id.ToUpper());
            //if (valid is not null)
            //{
            //    return false;
            //}
            var add = new Customer
            {
                CustomerID = dto.CustomerID.ToUpper(),
                CompanyName = dto.CompanyName,
                ContactName = dto.ContactName,
                ContactTitle = dto.ContactTitle,
                Country = dto.Country
            };
            dbContext.Customers.Add(add);
            return dbContext.SaveChanges() > 0;
        }

        public bool DeleteCustomer(string id)
        {
            var data = dbContext.Customers.SingleOrDefault(x => x.CustomerID == id.ToUpper());
            if (data is null)
            {
                return false;
            }
            dbContext.Customers.Remove(data);
            return dbContext.SaveChanges() > 0;
        }

        public bool UpdateCustomer(UpdateCustomerDto dto, string id)
        {
           var data=dbContext.Customers.SingleOrDefault(x => x.CustomerID == id.ToUpper());
            if (data is null)
            {
                return false;
            }

            data.ContactName = dto.ContactName;
            data.ContactTitle = dto.ContactTitle;
            dbContext.Update(data);
            return dbContext.SaveChanges() > 0;
             
        }
    }
}
