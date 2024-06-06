using System.ComponentModel.DataAnnotations;

namespace UserManagerAPI.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public required string Nome {  get; set; }
        public required string Senha { get; set; }
        public required string CPF { get; set; }
        public int IdGrupo { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
