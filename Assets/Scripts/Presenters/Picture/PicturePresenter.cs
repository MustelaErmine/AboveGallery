using AboveGallery.Model.Picture;
using AboveGallery.Presenters.Picture.Providers;
using AboveGallery.View.Picture;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AboveGallery.Presenters.Picture
{
    /// <summary>
    /// ƒостаточно присвоить IsVisible, картинка загрузитс€.
    /// </summary>
    public class PicturePresenter : IPicturePresenter
    {
        public IPictureModel Model { get; private set; }
        public bool IsVisible 
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                if (_isVisible && !_isShowedOnce)
                {
                    _isShowedOnce = true;
                    ShowFirstTime();
                }
            }
        }

        private IPictureView View { get; set; }
        private IPictureProvider Provider { get; set; }

        private bool _isVisible;
        private bool _isShowedOnce;
        private Sprite _sprite;

        public PicturePresenter(IPictureModel model, IPictureView view, IPictureProvider provider)
        {
            Model = model;
            View = view;
            Provider = provider;

            _isVisible = false;
            _isShowedOnce = false;

            View.IsPremium = Model.IsPremium;
        }
        private void ShowFirstTime()
        {
            LoadAndShowImage().Forget();
        }
        private async UniTaskVoid LoadAndShowImage()
        {
            Debug.Log("Show image " + Model.Id);
            var texture = await Provider.GetPicture(Model);
            Debug.Log(texture);
            var sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            Debug.Log(sprite);
            View.Sprite = sprite;
        }
    }
}