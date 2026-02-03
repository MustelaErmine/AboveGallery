namespace AboveGallery.Model
{
    public interface IPictureModel
    {
        string WWWPicturePath { get; }
        int Number { get; }
        bool IsPremium { get; }
    }
}