using AboveGallery.Model.Picture;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery.TabFilter
{
    public class TabFilterOdd : ITabFilter
    {
        public string Title => "Odd";
        public IEnumerable<IPictureModel> Filter(IEnumerable<IPictureModel> sourceModels)
        {
            foreach (IPictureModel sourceModel in sourceModels)
            {
                if (sourceModel.Id % 2 == 1)
                {
                    yield return sourceModel;
                }
            }
        }
    }
}