using System;
using System.Collections.Generic;
using System.Text;

namespace ASANM
{
    public static class Util
    {
        public static string formataNomeArquivo(string _NomeArquivo)
        {
            if (_NomeArquivo == null)
            { return ""; }
            else
            {
                _NomeArquivo = _NomeArquivo.ToLower();
                _NomeArquivo = _NomeArquivo.Replace(" ", "-");
                _NomeArquivo = _NomeArquivo.Replace("Á", "A");
                _NomeArquivo = _NomeArquivo.Replace("Ã", "A");
                _NomeArquivo = _NomeArquivo.Replace("Â", "A");
                _NomeArquivo = _NomeArquivo.Replace("À", "A");
                _NomeArquivo = _NomeArquivo.Replace("É", "E");
                _NomeArquivo = _NomeArquivo.Replace("Ê", "E");
                _NomeArquivo = _NomeArquivo.Replace("È", "E");
                _NomeArquivo = _NomeArquivo.Replace("Í", "I");
                _NomeArquivo = _NomeArquivo.Replace("Î", "I");
                _NomeArquivo = _NomeArquivo.Replace("Ì", "I");
                _NomeArquivo = _NomeArquivo.Replace("Ó", "O");
                _NomeArquivo = _NomeArquivo.Replace("Ô", "O");
                _NomeArquivo = _NomeArquivo.Replace("Ò", "O");
                _NomeArquivo = _NomeArquivo.Replace("Õ", "O");
                _NomeArquivo = _NomeArquivo.Replace("Ú", "U");
                _NomeArquivo = _NomeArquivo.Replace("Û", "U");
                _NomeArquivo = _NomeArquivo.Replace("Ù", "U");
                _NomeArquivo = _NomeArquivo.Replace("Ü", "U");
                _NomeArquivo = _NomeArquivo.Replace("Ç", "C");
                return _NomeArquivo;
            }
        }

        public static string formataTexto(string _Texto, bool _Upper)
        {
            if (_Texto == null)
            { return ""; }
            else
            {
                string strTexto;
                strTexto = _Texto.Replace("'", "");

                if (_Upper)
                { strTexto = strTexto.ToUpper(); }

                return strTexto;
            }
        }

        public static string getAtivo(bool _Ativo)
        {
            if (_Ativo)
            { return "<span class=\"label label-success\">Sim</span>"; }
            else
            { return "<span class=\"label label-danger\">Não</span>"; }
        }

    }
}
