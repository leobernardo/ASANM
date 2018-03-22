namespace ASANM.Dominio
{
    public class ArquivoConvenio
    {
        public int IDArquivoConvenio { get; set; }
        public Convenio Convenio { get; set; }
        public string NMArquivo { get; set; }
        public string DSArquivo { get; set; }
    }
}
