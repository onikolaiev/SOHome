using SOHome.Common.Models;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SOHome.Common.DataModels
{
    public class PersonModel : ObservableObject
    {
        #region Variaveis privadas
        private int code;
        private string name;
        private string? document;
        private string? email;
        private DateTime? birthDay;
        #endregion
        #region Propriedades
        [Display(Name = "Código")]
        public int Code { get => code; set => SetProperty(ref code, value); }
        [Required]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais que {1} caracteres.")]
        [Display(Name = "Nome")]
        public string Name { get => name; set => SetProperty(ref name, value); }
        [StringLength(20, ErrorMessage = "O documento não pode ter mais que {1} caracteres.")]
        [Display(Name = "CPF / CNPJ")]
        public string? Document { get => document; set => SetProperty(ref document, value); }
        [EmailAddress]
        [ReadOnly(true)]
        [Display(Name = "Email")]
        public string? Email { get => email; set => SetProperty(ref email, value); }
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get => birthDay; set => SetProperty(ref birthDay, value); }
        #endregion
    }
}
