using System;
using System.Reflection;

namespace ASP.NET_WEB_API_FOR_CRUD_OPERATION.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}