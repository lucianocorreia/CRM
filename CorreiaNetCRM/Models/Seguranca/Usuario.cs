using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CorreiaNetCRM.Lib.Helpers;

namespace CorreiaNetCRM.Models
{
    [Table("crm_Usuarios")]
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [MaxLength(256)]
        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string Nome { get; set; }

        [MaxLength(256)]
        [Required(ErrorMessage = "Informe o login de acesso do usuário")]
        public string Login { get; set; }

        [MaxLength(256)]
        public string Senha { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [MaxLength(256)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[DataType(DataType.DateTime)]
        public Nullable<DateTime> UltimoAcesso { get; set; }

        #region Not mapped columns

        [NotMapped]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string SenhaProtegida
        {
            get
            {
                if (!string.IsNullOrEmpty(Senha))
                {
                    return Helper.Security.Decrypt(this.Senha);
                }
                else return string.Empty;
            }
            set
            {
                this.Senha = Helper.Security.Encrypt(value);
            }
        }

        #endregion

    }
}