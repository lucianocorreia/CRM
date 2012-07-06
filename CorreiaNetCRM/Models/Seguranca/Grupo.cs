using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CorreiaNetCRM.Models
{

    [Table("crm_Grupos")]
    public class Grupo
    {
        public int GrupoId { get; set; }

        [MaxLength(256)]
        [Required]
        public string Descricao { get; set; }

    }

}