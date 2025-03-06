using System.ComponentModel.DataAnnotations;

namespace STI_Entrevista_03_03_2025.CQRS.DTOs
{
    public class CadastroVeiculoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A placa � obrigat�ria.")]
        [StringLength(10, ErrorMessage = "A placa deve ter no m�ximo 10 caracteres.")]
        public required string Placa { get; set; }

        [Required(ErrorMessage = "A marca � obrigat�ria.")]
        [StringLength(20, ErrorMessage = "A marca deve ter no m�ximo 20 caracteres.")]
        public required string Marca { get; set; }

        [Required(ErrorMessage = "O modelo � obrigat�rio.")]
        [StringLength(35, ErrorMessage = "O modelo deve ter no m�ximo 35 caracteres.")]
        public required string Modelo { get; set; }

        [Required(ErrorMessage = "A cor � obrigat�ria.")]
        [StringLength(20, ErrorMessage = "A cor deve ter no m�ximo 20 caracteres.")]
        public required string Cor { get; set; }

        [Required(ErrorMessage = "O porte � obrigat�rio.")]
        [StringLength(20, ErrorMessage = "O porte deve ter no m�ximo 20 caracteres.")]
        public required string Porte { get; set; }

        [Required(ErrorMessage = "O tipo de carga � obrigat�rio.")]
        [StringLength(20, ErrorMessage = "O tipo de carga deve ter no m�ximo 20 caracteres.")]
        [Display(Name = "Tipo de Carga")]
        public required string TipoDeCarga { get; set; }

        [Required(ErrorMessage = "O chassis � obrigat�rio.")]
        [StringLength(20, ErrorMessage = "O chassis deve ter no m�ximo 20 caracteres.")]
        public required string Chassis { get; set; }
    }
}
