using AboveGallery.View.Gallery.Tabs;
using UnityEngine;
using UnityEngine.Events;

namespace AboveGallery.View.Gallery.Tabs
{
    public class TabsPanelView : MonoBehaviour, ITabsPanelView
    {
        [SerializeField] private GameObject _tabPrefab;
        [SerializeField] private Transform _tabsParent;

        void Start()
        {
            _tabPrefab.SetActive(false);
        }

        public void AddTab(string tabTitle, UnityAction<TabView> onClick)
        {
            var tab = Instantiate(_tabPrefab, _tabsParent);
            tab.SetActive(true);
            var tabView = tab.GetComponent<TabView>();
            tabView.Text = tabTitle;
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
    }
}
