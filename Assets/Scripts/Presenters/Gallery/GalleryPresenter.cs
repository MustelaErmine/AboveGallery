using AboveGallery.Model.Gallery;
using AboveGallery.Model.Gallery.TabFilter;
using AboveGallery.Model.Picture;
using AboveGallery.Presenters.Picture;
using AboveGallery.View.Gallery;
using AboveGallery.View.Gallery.Tabs;
using AboveGallery.View.Picture;
using Codice.CM.Common;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace AboveGallery.Presenters.Gallery
{
    public class GalleryPresenter : IGalleryPresenter, IInitializable
    {
        public IGalleryModel Model { get; private set; }
        private IGalleryView View { get; set; }
        public GalleryPresenter(IGalleryModel model, IGalleryView view, ITabsPanelView tabsPanel, List<ITabFilter> filters, IPicturePresenter.Factory factory) 
        {
            Model = model;
            View = view;

            _tabsPanel = tabsPanel;
            _filters = filters;
            _picturePresenterFactory = factory;

            _picturePresenters = new List<IPicturePresenter>();
            _isEnumeratorEnd = false;
        }

        private List<IPicturePresenter> _picturePresenters;
        private ITabsPanelView _tabsPanel;
        private List<ITabFilter> _filters;
        private IPicturePresenter.Factory _picturePresenterFactory;

        private ITabFilter _currentFilter;
        private IEnumerator<IPictureModel> _pictureEnumerator;
        private bool _isEnumeratorEnd;

        public void Initialize()
        {
            ContructTabs();
            RefilterImages();

            _pictureEnumerator = Model.Pictures.GetEnumerator();
            RenderNewLoop().Forget();
        }

        private async UniTaskVoid RenderNewLoop()
        {
            while (!_isEnumeratorEnd)
            {
                while(View.IsNearEnd)
                {
                    AddNewPicture();
                    await UniTask.Yield();
                }

                await UniTask.WaitForSeconds(0.05f);
            }
        }

        private void AddNewPicture()
        {
            if (!_pictureEnumerator.MoveNext())
            {
                _isEnumeratorEnd = true;
                return;
            }
            var newModel = _pictureEnumerator.Current;

            var newView = View.AddNewPicture();

            var presenter = _picturePresenterFactory.Create(newModel, newView);
            presenter.IsVisible = true;
            _picturePresenters.Add(presenter);
        }

        private void ContructTabs()
        {
            _currentFilter = _filters.First();

            _tabsPanel.ClearTabs();
            for (int i = 0; i < _filters.Count; i++)
            {
                var filter = _filters[i];
                _tabsPanel.AddTab(filter.Title, 
                    (_) => { _tabsPanel.CurrentTab = i; ApplyFilter(filter); });
            }

            _tabsPanel.CurrentTab = 0;
        }
        private void ApplyFilter(ITabFilter filter)
        {
            _currentFilter = filter;
            RefilterImages();
        }

        private void RefilterImages()
        {
            foreach(var picture in _picturePresenters)
            {
                var model = picture.Model;
                picture.IsVisible = _currentFilter.Filter(model);
            }
        }
    }
}