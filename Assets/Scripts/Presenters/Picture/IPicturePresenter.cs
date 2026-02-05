using AboveGallery.Model.Picture;
using AboveGallery.View.Picture;
using UnityEngine.Events;
using Zenject;

namespace AboveGallery.Presenters.Picture
{
    public interface IPicturePresenter
    {
        IPictureModel Model { get; }
        bool IsVisible { get; set; }

        public class Factory : PlaceholderFactory<IPictureModel, IPictureView, IPicturePresenter> { }
    }
}