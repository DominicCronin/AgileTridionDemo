using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tridion.ContentManager.ContentManagement;
using Tridion.ContentManager.ContentManagement.Fields;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace demo
{
    public class AddReversedFieldToPackage : ITemplate
    {
        public void Transform(Engine engine, Package package)
        {
            string fieldName = package.GetValue("fieldName");
            Item componentItem = package.GetByType(ContentType.Component);
            var component = (Component)engine.GetObject(componentItem);
            ItemFields itemFields = new ItemFields(component.Content, component.Schema);
            var field = (TextField)itemFields[fieldName];
            char[] chars = field.Value.ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);
            package.PushItem("reversed_" + fieldName ,package.CreateStringItem(ContentType.Text, reversed));
        }
    }
}
