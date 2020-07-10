using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ASP.NET_WEB_API_FOR_CRUD_OPERATION.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}