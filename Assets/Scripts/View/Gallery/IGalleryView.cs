using UnityEngine;

namespace AboveGallery.View.Gallery
{
    public interface IGalleryView
    {
        public Transform PictureParent { get; }
        public bool IsNearEnd { get; }
    }
}