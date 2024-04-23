using System;
using System.Collections.Generic;

namespace APIWebDB.BaseDados.Models;

public enum TipoDocumento
{
    CPF = 0,
    CNPJ = 1,
    Passaporte = 2,
    CNH = 3,
    Outros = 99
}

public partial class TbCliente
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime? Nascimento { get; set; }

    public string Telefone { get; set; }

    public string Documento { get; set; }

    /// <summary>
    /// 0 - CPF, 1 - CNPJ, 2 - Passaporte 3 - CNH, 99 - Outros
    /// </summary>
    public int Tipodoc { get; set; }

    public DateTime Criadoem { get; set; }

    public DateTime Alteradoem { get; set; }

    public virtual ICollection<TbEndereco> TbEnderecos { get; set; } = new List<TbEndereco>();
}
