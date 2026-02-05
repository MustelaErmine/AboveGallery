using AboveGallery.Model.Picture;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery.TabFilter
{
    public class TabFilterEven : ITabFilter
    {
        public string Title => "Even";
        public bool Filter(IPictureModel picture)
        {
            return picture.Id % 2 == 0;
        }
    }
}