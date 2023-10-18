using System.ComponentModel.DataAnnotations;

namespace Valhahalha_Blazor_ServerSide.Model
{
    public class Albun : Generics
    {
        [Required(ErrorMessage = "Informe o Titulo do albúm")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Informe o nome do Artista do albúm")]
        public string Artista { get; set; }
        [Required(ErrorMessage = "Informe o Ano de lançamento do albúm")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Informe uam Url pública com a imagem da capa do albúm")]
        public string CoverUrl { get; set; }
        public int Likes { get; set; }

        
    }
}
