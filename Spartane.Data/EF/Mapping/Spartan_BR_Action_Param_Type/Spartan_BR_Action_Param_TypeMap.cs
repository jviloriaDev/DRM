using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Action_Param_Type
{
    public partial class Spartan_BR_Action_Param_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type>
    {
        public Spartan_BR_Action_Param_TypeMap()
        {
            this.ToTable("Spartan_BR_Action_Param_Type");
            this.HasKey(a => a.ParameterTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
