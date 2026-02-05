using AboveGallery.Model.Picture;
using AboveGallery.View.Picture;
using UnityEngine.Events;

namespace AboveGallery.Presenters.Picture
{
    public interface IPicturePresenter
    {
        IPictureModel Model { get; }
        bool IsVisible { get; set; }
    }
}