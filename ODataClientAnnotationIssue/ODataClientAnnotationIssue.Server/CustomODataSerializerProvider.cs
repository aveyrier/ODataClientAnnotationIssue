using Microsoft.OData.Edm;
using System.Web.OData.Formatter.Serialization;

namespace ODataClientAnnotationIssue.Server
{
    internal class CustomODataSerializerProvider : DefaultODataSerializerProvider
    {
        private readonly ODataEntityTypeSerializer m_entityTypeSerializer;

        public CustomODataSerializerProvider()
            : base()
        {
            m_entityTypeSerializer = new CustomODataEntityTypeSerializer(this);
        }

        public override ODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
        {
            if (edmType.TypeKind() == EdmTypeKind.Entity)
            {
                return m_entityTypeSerializer;
            }

            return base.GetEdmTypeSerializer(edmType);
        }
    }
}