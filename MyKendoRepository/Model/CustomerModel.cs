using System;
using System.ComponentModel.DataAnnotations;

namespace MyKendoRepository.Model
{
    
    public class CustomerModel
    {
        
        public Nullable<int> Id { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage="Name is require.")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Name is require.")]
        //public string Address { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter Proper Email address")]
        [Required(ErrorMessage = "Email is require.")]
        public string Email { get; set; }

        [StringLength(6,ErrorMessage="Pincode must be six(6) digits.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter valid Pincode.")]
        [Required(ErrorMessage = "Pincode is require.")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "City is require.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Phone is require.")]
        public string Phone { get; set; }

        public Nullable<bool> IsActive { get; set; }
    }
}
