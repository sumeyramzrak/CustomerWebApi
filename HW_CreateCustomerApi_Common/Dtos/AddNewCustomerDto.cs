using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HW_CreateCustomerApi_Common.Dtos
{
    public class AddNewCustomerDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [MaxLength(5)]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Country { get; set; }
    }
}
