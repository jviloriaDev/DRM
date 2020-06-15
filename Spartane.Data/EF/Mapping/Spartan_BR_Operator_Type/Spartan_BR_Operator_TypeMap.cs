using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Operator_Type
{
    public partial class Spartan_BR_Operator_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Operator_Type.Spartan_BR_Operator_Type>
    {
        public Spartan_BR_Operator_TypeMap()
        {
            this.ToTable("Spartan_BR_Operator_Type");
            this.HasKey(a => a.OperatorTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
