using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.ContentManager.CoreService.Client;
using System.Configuration;

namespace demoTest
{
    [TestClass]
    public class TBBTests
    {
        [TestMethod]
        public void AddReversedFieldToPackageTest()
        {

            var templateId = "/webdav/04%20Web/Building%20Blocks/System/Templates/Test/TestCT-ReversedString.tctcmp";
            var itemId = "/webdav/04%20Web/Building%20Blocks/Test/PerSchema/Dummy/GeneratedTestData_1.xml";

            var client = new SessionAwareCoreServiceClient("wsHttp_2013");
            client.ClientCredentials.Windows.ClientCredential.Domain = ConfigurationManager.AppSettings.Get("domain");
            client.ClientCredentials.Windows.ClientCredential.Password = ConfigurationManager.AppSettings.Get("password");
            client.ClientCredentials.Windows.ClientCredential.UserName = ConfigurationManager.AppSettings.Get("username");

            var publishInstruction = new PublishInstructionData
            {
                RenderInstruction = new RenderInstructionData { RenderMode = RenderMode.PreviewDynamic },
                ResolveInstruction = new ResolveInstructionData { StructureResolveOption = StructureResolveOption.OnlyItems }
            };

            try
            {
                client.RenderItem(itemId, templateId, publishInstruction, ConfigurationManager.AppSettings.Get("publicationTargetId"));
            }
            catch (Exception ex)
            {

                Assert.Fail("Rendering {0} with {1} failed: {2}", templateId, itemId, ex.Message);
            }

        }
    }
}
