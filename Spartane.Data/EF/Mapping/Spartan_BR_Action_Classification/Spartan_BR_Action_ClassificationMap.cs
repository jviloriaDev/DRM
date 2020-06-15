using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Action_Classification
{
    public partial class Spartan_BR_Action_ClassificationMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>
    {
        public Spartan_BR_Action_ClassificationMap()
        {
            this.ToTable("Spartan_BR_Action_Classification");
            this.HasKey(a => a.ClassificationId);
            this.Ignore(a => a.Id);
        }
    }
}
