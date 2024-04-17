using APIWebDB.BaseDados.Models;
using System.Collections.Generic;
using System;

namespace APIWebDB.Services.DTOs
{
    public class ClienteDTO
    {

        public string Nome { get; set; }

        public DateOnly? Nascimento { get; set; }

        public string Telefone { get; set; }

        public string Documento { get; set; }

        /// <summary>
        /// 0 - CPF, 1 - CNPJ, 2 - Passaporte 3 - CNH, 99 - Outros
        /// </summary>
        public int Tipodoc { get; set; }

    }
}
