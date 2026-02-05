using AboveGallery.Model.Picture;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery.TabFilter
{
    public interface ITabFilter
    {
        string Title { get; }
        IEnumerable<IPictureModel> Filter(IEnumerable<IPictureModel> sourceModels);
    }
}