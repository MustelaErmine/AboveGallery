using AboveGallery.Model.Settings;

namespace AboveGallery.Model
{
    public class PictureModel : IPictureModel
    {
        public string WWWPicturePath => $"{baseUrl}{Number}.{extension}";
        public int Number { get; private set; }
        public bool IsPremium => Number % 4 == 0;

        private string baseUrl;
        private string extension;

        public PictureModel(int number, PictureSourceSettings pictureSourceSettings)
        {
            Number = number;
            baseUrl = pictureSourceSettings.baseUrl;
            extension = pictureSourceSettings.picturesExtension;
        }
    }
}