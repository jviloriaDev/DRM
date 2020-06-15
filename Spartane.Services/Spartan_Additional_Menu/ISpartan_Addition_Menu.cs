using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Additional_Menu;

namespace Spartane.Services.Spartan_Additional_Menu
{
    public interface ISpartan_Additional_Menu
    {
        IList<Spartane.Core.Classes.Spartan_Additional_Menu.Spartan_Additional_Menu> GetMenu(int user, int languageId);
    }
}
