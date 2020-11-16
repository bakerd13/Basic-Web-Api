using System.Collections.Generic;
using System.Xml.Serialization;

namespace DABTechs.eCommerce.Sales.Providers.Menu.Models
{
    public class MegaNav
    {
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
