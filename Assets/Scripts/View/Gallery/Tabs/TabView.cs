using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AboveGallery.View.Gallery.Tabs
{
    public class TabView : MonoBehaviour
    {
        [SerializeField] private GameObject _activeView;
        [SerializeField] private TMPro.TextMeshProUGUI _textMesh;
        [SerializeField] private Button _button;

        public bool IsActive { set => _activeView.SetActive(value); }
        public string Text { set => _textMesh.text = value; get => _textMesh.text; }
        public UnityEvent<TabView> OnClick { get; private set; }

        private void Awake()
        {
            OnClick = new UnityEvent<TabView>();
            _button.onClick.AddListener(() => OnClick.Invoke(this));
        }
    }
}