using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AboveGallery.View.UIModules
{
    public class TabsView : MonoBehaviour
    {
        public int ButtonsCount 
        { 
            get => _buttonCount; 
            set 
            { 
                _buttonCount = value; 
                SetButtonCount(); 
            } 
        }
        public int CurrentButton 
        { 
            get => _currentButton; 
            set 
            { 
                _currentButton = value; 
                SetCurrentButton(); 
            } 
        }

        private List<Image> _images = new List<Image>();
        
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private Sprite _enableSprite, _disableSprite;

        private void Awake()
        {
            _buttonPrefab.SetActive(false);
        }

        private void SetCurrentButton()
        {
            for (int i = 0; i < _images.Count; i++)
            {
                if (i == _currentButton)
                {
                    _images[i].sprite = _enableSprite;
                }
                else
                {
                    _images[i].sprite = _disableSprite;
                }
            }
        }

        private void SetButtonCount()
        {
            var myTransform = transform;

            foreach (var image in _images)
            {
                Destroy(image.gameObject);
            }

            for (int i = 0; i < _buttonCount; i++)
            {
                var button = Instantiate(_buttonPrefab, myTransform);
                button.SetActive(true);
                _images.Add(button.GetComponent<Image>());
            }

            GetComponent<HorizontalLayoutGroup>().CalculateLayoutInputHorizontal();

            CurrentButton = 0;
        }

        private int _buttonCount, _currentButton;
    }
}