using AboveGallery.View.Gallery.Tabs;
using UnityEngine;
using UnityEngine.Events;

namespace AboveGallery.View.Gallery.Tabs
{
    public interface ITabsPanelView
    {
        void AddTab(string tabTitle, UnityAction<TabView> onClick);

        void ClearTabs();
    }
}
