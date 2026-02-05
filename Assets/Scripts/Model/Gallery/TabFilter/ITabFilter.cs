using AboveGallery.Model.Picture;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery.TabFilter
{
    public interface ITabFilter
    {
        string Title { get; }
        bool Filter(IPictureModel picture);
    }
}