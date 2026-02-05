using AboveGallery.Model.Picture;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace AboveGallery.Presenters.Picture.Providers
{
    public interface IPictureProvider
    {
        UniTask<Texture2D> GetPicture(IPictureModel model);
    }
}