using AboveGallery.Model.Settings;
using Zenject;

namespace AboveGallery.Model.Picture
{
    public class PictureModel : IPictureModel, IPictureDownloadable
    {
        public string WWWPicturePath => $"{_baseUrl}{Id}.{_extension}";
        public int Id { get; private set; }
        public bool IsPremium => Id % 4 == 0;

        private string _baseUrl;
        private string _extension;

        public PictureModel(int number, PictureSourceSettings pictureSourceSettings)
        {
            Id = number;
            _baseUrl = pictureSourceSettings.baseUrl;
            _extension = pictureSourceSettings.picturesExtension;
        }

        public class Factory : PlaceholderFactory<int, PictureModel> { }
    }
}