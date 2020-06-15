using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Detalle_de_Ingredientes
{
    public class Detalle_de_IngredientesPagingModel
    {
        public List<Spartane.Core.Classes.Detalle_de_Ingredientes.Detalle_de_Ingredientes> Detalle_de_Ingredientess { set; get; }
        public int RowCount { set; get; }
    }
}
