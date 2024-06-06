namespace UserManagerAPI.Domain.Entities
{
    public class GrupoUsuario
    {
        public int IdGrupo { get; set; }
        public string? Descricao { get; set; }
        public bool Administrador { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

    }
}
