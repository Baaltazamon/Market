using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Market.ViewModels
{
    public class UserViewModel
    {
        
        public int Id { get; set; }

        [Display(Name = "Логин")]
        [StringLength(maximumLength: 25, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 25 символов")]
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Логин не может быть пустым!")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [StringLength(maximumLength: 25, MinimumLength = 3, ErrorMessage = "Пароль должен быть от 3 до 25 символов")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пароль не может быть пустым!")]
        public string Password { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Фамилия должена быть от 2 до 25 символов")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия обязательное поле!")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Имя")]
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 25 символов")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя не может быть пустым!")]
        public string FirstName { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата рождения не может быть пустой!")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Счёт")]
        public double Score { get; set; }
    }
}
