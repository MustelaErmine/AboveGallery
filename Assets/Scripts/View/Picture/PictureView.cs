using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace AboveGallery.View.Picture
{
    public class PictureView : MonoBehaviour, IPictureView
    {
        public UnityEvent OnClick { get; private set; }
        public Sprite Sprite { set => _image.sprite = value; }
        public bool IsPremium { set => _premiumBadge.SetActive(value); }
        public Transform Parent { set => transform.SetParent(value); }

        [SerializeField] Image _image;
        [SerializeField] GameObject _premiumBadge;
        [SerializeField] Button _button;

        [Inject]
        void Construct()
        {
            OnClick = new UnityEvent();
        }

        private void Awake()
        {
            _button.onClick.AddListener(InvokeOnClick);
        }
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(InvokeOnClick);
        }
        private void InvokeOnClick()
        {
            OnClick?.Invoke();
        }

        public class Factory : PlaceholderFactory<PictureView> { }
    }
}