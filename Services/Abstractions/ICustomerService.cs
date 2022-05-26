using HW_CreateCustomerApi_Common.Dtos;

namespace HW_CreateCustomerApi_Services.Abstractions
{
    public interface ICustomerService
    {
        List<GetAllCustomersDto> GetAllCustomers();
        GetCustomerByIdDto GetCustomerById(string id);
        bool AddNewCustomer(AddNewCustomerDto dto);
        bool DeleteCustomer(string id);
        bool UpdateCustomer(UpdateCustomerDto dto, string id);
    }
}
