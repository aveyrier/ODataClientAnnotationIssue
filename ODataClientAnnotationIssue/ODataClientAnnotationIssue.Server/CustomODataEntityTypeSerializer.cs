using Microsoft.OData.Core;
using System.Linq;
using System.Web;
using System.Web.OData;
using System.Web.OData.Formatter.Serialization;

namespace ODataClientAnnotationIssue.Server
{
    internal class CustomODataEntityTypeSerializer : ODataEntityTypeSerializer
    {
        public CustomODataEntityTypeSerializer(ODataSerializerProvider serializerProvider)
            : base(serializerProvider)
        {
        }

        public override ODataEntry CreateEntry(SelectExpandNode selectExpandNode, EntityInstanceContext entityInstanceContext)
        {
            ODataEntry entry = base.CreateEntry(selectExpandNode, entityInstanceContext);

            if (HttpContext.Current.Response.Headers["Preference-Applied"] == null)
            {
                string[] preferences = HttpContext.Current.Request.Headers.GetValues("Prefer");
                HttpContext.Current.Response.Headers.Add("Preference-Applied", string.Join(",", preferences));
            }
            
            entry.InstanceAnnotations.Add(new ODataInstanceAnnotation("foo.bar", new ODataPrimitiveValue(true)));

            foreach (ODataProperty property in entry.Properties)
            {
                property.InstanceAnnotations.Add(new ODataInstanceAnnotation("foo.bar", new ODataPrimitiveValue(true)));
            }

            return entry;
        }
    }
}