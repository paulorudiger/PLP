using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoPraticoT2.Classes;

namespace TrabalhoPraticoT2.Interfaces
{
    public interface IRelatorio
    {

        List<Produto> Imprimir(List<Produto> produtos);

    }
}
