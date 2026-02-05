using AboveGallery.View.Gallery.Tabs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AboveGallery.View.Gallery.Tabs
{
    public class TabsPanelView : MonoBehaviour, ITabsPanelView
    {
        [SerializeField] private GameObject _tabPrefab;
        [SerializeField] private Transform _tabsParent;

        private int _currentTab;
        private List<TabView> _tabs;

        public int CurrentTab 
        { 
            get => _currentTab; 
            set {
                _currentTab = value;
                SetCurrentTab();
            }
        }

        void Awake()
        {
            _tabPrefab.SetActive(false);
            _tabs = new List<TabView>();
        }

        public void AddTab(string tabTitle, UnityAction<TabView> onClick)
        {
            var tab = Instantiate(_tabPrefab, _tabsParent);
            tab.SetActive(true);
            var tabView = tab.GetComponent<TabView>();
            _tabs.Add(tabView);
            tabView.Text = tabTitle;
            tabView.IsActive = false;
            tabView.OnClick.AddListener(onClick);
        }

        public void ClearTabs()
        {
            for (int i = 0; i < _tabsParent.childCount; i++)
            {
                if (_tabsParent.GetChild(i).gameObject.activeSelf)
                    Destroy(_tabsParent.GetChild(i).gameObject);
            }
        }

        private void SetCurrentTab()
        {
            for (int i = 0; i < _tabs.Count; i++)
            {
                _tabs[i].IsActive = CurrentTab == i;
            }
        }
    }
}
