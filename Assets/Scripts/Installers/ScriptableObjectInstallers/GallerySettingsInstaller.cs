using AboveGallery.Model.Settings;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GallerySettingsInstaller", menuName = "Installers/GallerySettingsInstaller")]
public class GallerySettingsInstaller : ScriptableObjectInstaller<GallerySettingsInstaller>
{
    [SerializeField] private EnumerableGallerySettings _enumerableGallerySettings;
    [SerializeField] private PictureSourceSettings _pictureSourceSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(_enumerableGallerySettings);
        Container.BindInstance(_pictureSourceSettings);
    }
}