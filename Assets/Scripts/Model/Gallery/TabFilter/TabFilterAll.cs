using AboveGallery.Model.Picture;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery.TabFilter
{
    public class TabFilterAll : ITabFilter
    {
        public string Title => "All";

        public IEnumerable<IPictureModel> Filter(IEnumerable<IPictureModel> sourceModels)
        {
            return sourceModels;
        }
    }
}