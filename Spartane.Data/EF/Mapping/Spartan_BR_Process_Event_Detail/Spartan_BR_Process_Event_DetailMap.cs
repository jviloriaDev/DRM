using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Process_Event_Detail
{
    public partial class Spartan_BR_Process_Event_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Process_Event_Detail.Spartan_BR_Process_Event_Detail>
    {
        public Spartan_BR_Process_Event_DetailMap()
        {
            this.ToTable("Spartan_BR_Process_Event_Detail");
            this.HasKey(a => a.ProcessEventDetailId);
            this.Ignore(a => a.Id);
        }
    }
}
