using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace UserManagerAPI.Domain.Entities
{
    public class GrupoUsuario
    {
        [Key]
        public int IdGrupo { get; set; }
        public string? Descricao { get; set; }
        public bool Administrador { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
