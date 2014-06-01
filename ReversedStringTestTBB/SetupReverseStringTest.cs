using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Tridion.Extensions.Testing;
using Tridion.ContentManager.Templating;

namespace ReversedStringTestTBB
{
    class SetupReverseStringTest : BaseSetup
    {
        public override void Setup()
        {
            // load xml document from embedded resource
            XmlDocument itemDoc = new XmlDocument();
            using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ReversedStringTestTBB.SetupComponent.xml"))
            {
                using (XmlTextReader reader = new XmlTextReader(manifestResourceStream))
                {
                    itemDoc.Load(reader);
                }
            }
            SetPackageItem(Package.ComponentName, itemDoc, ContentType.Component);
        }
    }
}
