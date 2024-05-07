namespace APIWebDB.Services.DTOs
{
    public class EnderecoDTO
    {
        /// <example>
        /// 89870000
        /// </example>
        public int Cep { get; set; }
        /// <example>
        /// Rua Florianopolis
        /// </example>
        public string Logradouro { get; set; }
        /// <example>
        /// 2830
        /// </example>
        public string Numero { get; set; }
        /// <example>
        /// Apto
        /// </example>
        public string Complemento { get; set; }
        /// <example>
        /// Santo Antonio
        /// </example>
        public string Bairro { get; set; }
        /// <example>
        /// Pinhalzinho
        /// </example>
        public string Cidade { get; set; }
        /// <example>
        /// SC
        /// </example>
        public string Uf { get; set; }
        /// <example>
        /// 1
        /// </example>
        public int Clienteid { get; set; }
        /// <example>
        /// 1
        /// </example>
        /// <summary>
        /// 0 - inativo\n1 - ativo
        /// </summary>
        public int Status { get; set; }
    }
}