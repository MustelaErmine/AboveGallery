using AboveGallery.Model.Picture;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery.TabFilter
{
    public class TabFilterEven : ITabFilter
    {
        public string Title => "Even";
        public IEnumerable<IPictureModel> Filter(IEnumerable<IPictureModel> sourceModels)
        {
            foreach (IPictureModel sourceModel in sourceModels)
            {
                if (sourceModel.Id % 2 == 0)
                {
                    yield return sourceModel;
                }
            }
        }
    }
}