using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Matrix_of_States
{
    public partial class Spartan_WorkFlow_Matrix_of_StatesMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>
    {
        public Spartan_WorkFlow_Matrix_of_StatesMap()
        {
            this.ToTable("Spartan_WorkFlow_Matrix_of_States");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Matrix_of_StatesId);
        }
    }
}
