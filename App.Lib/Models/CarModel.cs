using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Lib.Models
{
    public class CarModel
    {
        [Required(ErrorMessage = "Поле марка не може бути пустим!"), StringLength(255, 
            ErrorMessage = "Перевищено ліміт введених символів!")]
        public string Mark { get; set; }
        [Required(ErrorMessage = "Поле модель не може бути пустим!"), StringLength(255, 
            ErrorMessage = "Перевищено ліміт введених символів!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Поле рік не може бути пустим!"), Range(0, 2021, ErrorMessage = "Поле рік введено не коректно!")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Поле об'єм не може бути пустим!"), Range(0, 6.0, ErrorMessage = "Поле об'єм введено не коректно!")]
        public float Capacity { get; set; }
        [Required(ErrorMessage = "Поле зображення не може бути пустим!"), StringLength(255, 
            ErrorMessage = "Перевищено ліміт введених символів!")]
        public string Image { get; set; }

        public bool IsNew { get; set; } = false;
    }
}
