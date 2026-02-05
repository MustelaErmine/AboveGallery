using AboveGallery.View.Picture;
using System.Collections.Generic;
using UnityEngine;

namespace AboveGallery.View.Gallery
{
    public interface IGalleryView
    {
        public Transform PictureParent { get; }
        public IEnumerable<IPictureView> PictureViews { get; }
        public bool IsNearEnd { get; }
        public IPictureView AddNewPicture();
    }
}