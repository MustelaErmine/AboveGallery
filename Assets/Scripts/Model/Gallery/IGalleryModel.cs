using AboveGallery.Model.Picture;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery
{
    public interface IGalleryModel
    {
        IEnumerable<IPictureModel> Pictures { get; }
        int PictureCount { get; }
    }
}