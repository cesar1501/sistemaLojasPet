using Newtonsoft.Json;
using sistemaLojasPet.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaLojasPet.Entidades
{
    public class Loja
    {
        public int ID { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string HorarioFuncionamento { get; set; }

        public IList<Endereco> Endereco { get; set; }
        public int EnderecoID { get; set; }
        [JsonIgnore]
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

        public virtual ICollection<LojaProduto> LojaProduto { get; set; }
    }
}