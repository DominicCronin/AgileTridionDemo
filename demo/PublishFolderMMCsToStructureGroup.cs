using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tridion.ContentManager;
using Tridion.ContentManager.ContentManagement;
using Tridion.ContentManager.ContentManagement.Fields;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace demoTest
{
    class PublishFolderMMCsToStructureGroup : ITemplate
    {
        public void Transform(Engine engine, Package package)
        {
            var logger = TemplatingLogger.GetLogger(typeof(PublishFolderMMCsToStructureGroup));
            // Get containing folder of the component
            var componentItem = package.GetByName(Package.ComponentName);
            var component = (RepositoryLocalObject)engine.GetObject(componentItem);
            var folder = component.OrganizationalItem;
            var folderMetadata = new ItemFields(folder.Metadata, folder.MetadataSchema);
            var sgURL = folderMetadata["sgForBinaryPublish"] as SingleLineTextField;
            if (sgURL == null || sgURL.Value == null)
            {
                logger.Debug("No sgForBinaryPublish configured for this folder. Doing nothing."); 
                return;
            }
            IdentifiableObject structureGroup = null;
            try
            {
                structureGroup = engine.GetObject(sgURL.Value);
            }
            catch (InvalidTcmUriException)
            {
                logger.Error("Folder metadata contains invalid value for sgForBinaryPublish.");
            }
            if (structureGroup == null) 
            {
                logger.Error("Folder metadata contains a value for sgForBinaryPublish which does not locate an item");
            }

            var filter = new OrganizationalItemItemsFilter(engine.GetSession());
            filter.ItemTypes = new ItemType[] {ItemType.Component};
            var components = folder.GetItems(filter).Cast<Component>().Where(c => c.BinaryContent != null);
            foreach (var comp in components)
            {
                engine.AddBinary( comp.Id, 
                                    engine.PublishingContext.ResolvedItem.Template.Id, 
                                    engine.LocalizeUri(structureGroup.Id), 
                                    comp.BinaryContent.GetByteArray(),
                                    comp.Title);
            }
            


        }
    }
}
