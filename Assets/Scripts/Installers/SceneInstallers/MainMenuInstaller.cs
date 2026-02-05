using AboveGallery.Model.Gallery;
using AboveGallery.Model.Gallery.TabFilter;
using AboveGallery.Model.Picture;
using AboveGallery.Presenters.Gallery;
using AboveGallery.Presenters.Picture;
using AboveGallery.Presenters.Picture.Providers;
using AboveGallery.View.Gallery;
using AboveGallery.View.Gallery.Tabs;
using AboveGallery.View.Picture;
using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<ITabsPanelView>().To<TabsPanelView>()
        Container.Bind<ITabFilter>().To<TabFilterAll>().AsCached();
        Container.Bind<ITabFilter>().To<TabFilterEven>().AsCached();
        Container.Bind<ITabFilter>().To<TabFilterOdd>().AsCached();

        Container.Bind<IGalleryModel>().To<GalleryModel>().AsSingle();
        Container.BindFactory<int, PictureModel, PictureModel.Factory>();

        Container.Bind<IPictureProvider>().To<PictureProvider>().AsCached();

        Container.BindFactory<IPictureModel, IPictureView,
            IPicturePresenter, IPicturePresenter.Factory>()
            .To<PicturePresenter>();
        Container.BindInterfacesTo<GalleryPresenter>().AsSingle().NonLazy();

        Container.Bind<ITabsPanelView>().To<TabsPanelView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IGalleryView>().To<GalleryView>().FromComponentInHierarchy().AsSingle();
    }
}