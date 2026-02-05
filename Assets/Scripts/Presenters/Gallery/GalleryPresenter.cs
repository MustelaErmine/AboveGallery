using AboveGallery.Model.Gallery;
using AboveGallery.Model.Picture;
using AboveGallery.View.Gallery;
using AboveGallery.View.Picture;
using System.Collections.Generic;
using Zenject;

namespace AboveGallery.Presenters.Gallery
{
    public class GalleryPresenter : IGalleryPresenter
    {
        public IGalleryModel Model { get; private set; }
        private IGalleryView View { get; set; }
        public GalleryPresenter(IGalleryModel model, IGalleryView view) 
        {
            Model = model;
            View = view;
        }

        private Dictionary<IPictureModel, IPictureView> _modelToView;

        [Inject]
        public void Construct()
        {

        }
    }
}