﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Platillos;
using Spartane.Core.Classes.Cantidad_fraccion_platillos;
using Spartane.Core.Classes.Ingredientes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Platillos
{
    /// <summary>
    /// Detalle_Platillos table
    /// </summary>
    public class Detalle_Platillos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Platillos { get; set; }
        public bool? Lleva_fracciones { get; set; }
        public int? Cantidad { get; set; }
        public int? Cantidad_fraccion { get; set; }
        public int? Unidad { get; set; }
        public int? Ingrediente { get; set; }
        public string Caracteristica { get; set; }
        public int? Unidad_SMAE { get; set; }
        public int? Equivalente_Unidad_SMAE { get; set; }
        public int? Porciones { get; set; }
        public string Detalle { get; set; }
        public string Detalle_Super { get; set; }

        [ForeignKey("Folio_Platillos")]
        public virtual Spartane.Core.Classes.Platillos.Platillos Folio_Platillos_Platillos { get; set; }
        [ForeignKey("Cantidad_fraccion")]
        public virtual Spartane.Core.Classes.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos Cantidad_fraccion_Cantidad_fraccion_platillos { get; set; }
        [ForeignKey("Ingrediente")]
        public virtual Spartane.Core.Classes.Ingredientes.Ingredientes Ingrediente_Ingredientes { get; set; }

    }
}

