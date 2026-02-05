using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AboveGallery.View.UIModules
{
    public class SlidesView : MonoBehaviour
    {
        public List<GameObject> Slides
        {
            get
            {
                return _slidesPrefabs;
            }
            set
            {
                _slidesPrefabs = value;
                SetNewSlides();
            }
        }

        [SerializeField] private List<GameObject> _initSlides;

        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private AspectRatioFitter _viewAspectRatio;
        [SerializeField] private RectTransform _scrollTransform;
        [SerializeField] private SlidesContentHandler _slidesContentHandler;
        [SerializeField] private TabsView _tabsView;
        private RectTransform _contentTransform;
        private AspectRatioFitter _contentFitter;

        private List<GameObject> _slidesPrefabs;
        private List<GameObject> _slides;
        private Vector2? _contentPosition;
        private bool _isInUse;

        private int _currentSlideIndex;

        private int SlideCount { get =>  _slides.Count; }

        void Awake()
        {
            _contentTransform = _slidesContentHandler.ContentTransform;
            _contentFitter = _slidesContentHandler.ContentFitter;

            _slides = new List<GameObject>();
            _slidesPrefabs = new List<GameObject>();

#if UNITY_EDITOR
            if (_contentTransform.childCount != 0)
            {
                _slides = Enumerable.Range(0, _contentTransform.childCount).ToList()
                    .Select((int _, int index)
                        => _contentTransform.GetChild(index).gameObject)
                    .ToList();
            }
#endif
            if (_initSlides.Count > 0)
            {
                Slides = _initSlides;
            }

            _scrollRect.onValueChanged.AddListener(OnValueChanged);
            _currentSlideIndex = 0;
            _isInUse = false;

            AutoRefLoop().Forget();
        }

        private async UniTaskVoid AutoRefLoop()
        {
            while (true)
            {
                await UniTask.WaitForSeconds(5f);
                if (_isInUse)
                    continue;
                _currentSlideIndex++;
                SetNewReference(_currentSlideIndex % SlideCount);
            }
        }

        private int GetNewReferenceNumber()
        {
            var width = _scrollTransform.rect.width;
            var posX = _contentTransform.anchoredPosition.x;

            int baseReference = Mathf.RoundToInt(-posX / width);
            return baseReference;
        }

        private void SetNewReference(int number, float duration = 0.3f)
        {
            var width = _scrollTransform.rect.width;
            _contentTransform.DOAnchorPosX(-width * number, duration);

            _currentSlideIndex = number;
            _tabsView.CurrentButton = _currentSlideIndex;
        }

        private void OnValueChanged(Vector2 value)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
#elif UNITY_ANDROID
            if (Input.touchCount > 0)
#endif
            {
                _isInUse = true;
            }
            _contentPosition = value;
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonUp(0))
#elif UNITY_ANDROID
            if (Input.touchCount == 0)
#endif
            {
                if (_isInUse)
                {
                    _contentPosition = null;
                    _isInUse = false;
                    SetNewReference(GetNewReferenceNumber());
                }
            }
        }

        private void SetNewSlides()
        {
            _currentSlideIndex = 0;

            foreach (var slide in _slides)
            {
                Destroy(slide);
            }
            _slides = new List<GameObject>();

            foreach (var slidePrefab in _slidesPrefabs)
            {
                var slide = Instantiate(slidePrefab, _contentTransform);
                _slides.Add(slide);
            }
            _contentFitter.aspectRatio = _viewAspectRatio.aspectRatio * SlideCount;

            _tabsView.ButtonsCount = SlideCount;
            _tabsView.CurrentButton = _currentSlideIndex;
        }
    }
}