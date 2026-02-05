using AboveGallery.Model.Picture;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery.TabFilter
{
    public class TabFilterOdd : ITabFilter
    {
        public string Title => "Odd";
        public bool Filter(IPictureModel picture)
        {
            return picture.Id % 2 == 1;
        }
    }
}