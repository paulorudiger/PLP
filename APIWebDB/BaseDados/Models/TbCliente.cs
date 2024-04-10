using System;
using System.Collections.Generic;

namespace APIWebDB.BaseDados.Models;

public partial class TbCliente
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime? Nascimento { get; set; }

    public string Telefone { get; set; }

    public string Documento { get; set; }

    /// <summary>
    /// 0 - CPF\n1 - CNPJ\n2 - Passaporte\n3 - CNH\n99 - Outros
    /// </summary>
    public int Tipodoc { get; set; }

    public DateTime Criadoem { get; set; }

    public DateTime Alteradoem { get; set; }

    public virtual ICollection<TbEndereco> TbEnderecos { get; set; } = new List<TbEndereco>();
}
