using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Traduction_Concept_Type
{
    public partial class Spartan_Traduction_Concept_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type>
    {
        public Spartan_Traduction_Concept_TypeMap()
        {
            this.ToTable("Spartan_Traduction_Concept_Type");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.IdConcept);
        }
    }
}
