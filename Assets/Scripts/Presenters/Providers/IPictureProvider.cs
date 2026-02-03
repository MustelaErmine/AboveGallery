using AboveGallery.Model;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace AboveGallery.Presenters.Providers
{
    public interface IPictureProvider
    {
        UniTask<Texture2D> GetPicture(IPictureModel model);
    }
}