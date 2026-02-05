using AboveGallery.Model.Picture;
using AboveGallery.Model.Settings;
using System;
using System.Collections.Generic;

namespace AboveGallery.Model.Gallery
{
    public class GalleryModel : IGalleryModel
    {
        public IEnumerable<IPictureModel> Pictures => GetPictures();
        public int PictureCount => Math.Max(_settings.maxNumber - _settings.minNumber + 1, 0);

        private EnumerableGallerySettings _settings;
        private PictureModel.Factory _pictureModelFactory;

        public GalleryModel(EnumerableGallerySettings settings, PictureModel.Factory factory)
        {
            _settings = settings;
            _pictureModelFactory = factory;
        }

        private IEnumerable<IPictureModel> GetPictures()
        {
            for (int i = _settings.minNumber; i <= _settings.maxNumber; i++)
            {
                yield return _pictureModelFactory.Create(i);
            }
        }
    }
}