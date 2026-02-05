using AboveGallery.View.Picture;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AboveGallery.View.Gallery
{
    public class GalleryView : MonoBehaviour, IGalleryView
    {
        [SerializeField] Transform _pictureParent;
        [SerializeField] RectTransform _contentRect;
        [SerializeField] ScrollRect _scrollRect;
        [SerializeField] GameObject _picturePrefab;

        [SerializeField] float throttle = 400f;
        public Transform PictureParent => _pictureParent;
        public IEnumerable<IPictureView> PictureViews { get => _pictureViews; }

        private List<IPictureView> _pictureViews;

        void Start()
        {
            _pictureViews = new List<IPictureView>();
            _picturePrefab.SetActive(false);
        }

        public bool IsNearEnd
        {
            get
            {
                var viewportBottomY = _scrollRect.viewport.rect.height;
                var contentHeight = _contentRect.rect.height;
                var contentBottomY = contentHeight - _contentRect.rect.y;
                
                return contentBottomY - throttle < viewportBottomY;
            }
        }

        public IPictureView AddNewPicture()
        {
            var gameObject = Instantiate(_picturePrefab, PictureParent);
            gameObject.SetActive(true);
            var view = gameObject.GetComponent<IPictureView>();
            _pictureViews.Add(view)

            return view;
        }
    }
}