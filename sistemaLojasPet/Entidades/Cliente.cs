using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistemaLojasPet.Entidades
{
    public class Cliente
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}