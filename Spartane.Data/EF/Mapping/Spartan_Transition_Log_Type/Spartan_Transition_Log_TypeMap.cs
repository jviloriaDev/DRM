using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Transition_Log_Type
{
    public partial class Spartan_Transition_Log_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Transition_Log_Type.Spartan_Transition_Log_Type>
    {
        public Spartan_Transition_Log_TypeMap()
        {
            this.ToTable("Spartan_Transition_Log_Type");
            this.HasKey(a => a.Transaction_Log_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
