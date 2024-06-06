using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MVC_LAB_2.Models
{
    public class StudentModel
    {
        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яё]*$",
            ErrorMessage = "Имя должно начинаться с заглавной буквы и состоять из кириллицы.")]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яё]*$",
            ErrorMessage = "Фамилия должно начинаться с заглавной буквы и состоять из кириллицы.")]
        public string? Surname { get; set; }

        [RegularExpression(@"^[А-ЯЁ][а-яё]*$",
            ErrorMessage = "Отчество должно начинаться с заглавной буквы и состоять из кириллицы.")]
        public string? Patronymic { get; set; }

        [Required]
        [RegularExpression(@"^[0-9M-]*$",
            ErrorMessage = "Группа может содержать только цифры, тире и заглавную букву 'М'.")]
        public string? GroupName { get; set; }

        [Required]
        [RegularExpression(@"([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+)",
            ErrorMessage = "Введите email формата symbol@symbol.domain")]
        public string? Email { get; set; }

        private string? _phone;

        [Required]
        [RegularExpression(@"^(\+7|8)?[\s-]?(\(?\d{3}\)?)[\s-]?(\d{3})[\s-]?(\d{2})[\s-]?(\d{2})$",
            ErrorMessage = "Номер телефона должен быть в следующем формате: 8 (999) 999-99-99.")]
        public string Phone
        {
            get => _phone!;
            set => _phone = FormatPhoneNumber(value);
        }

        private string FormatPhoneNumber(string phone)
        {
            string cleaned = Regex.Replace(phone, @"[\s-()]", string.Empty);
            Match match = Regex.Match(cleaned, @"^(\+7|8)?(\d{3})(\d{3})(\d{2})(\d{2})$");

            if (match.Success)
            {
                return $"+7({match.Groups[2].Value}){match.Groups[3].Value}{match.Groups[4].Value}{match.Groups[5].Value}";
            }

            return phone;
        }
    }
}