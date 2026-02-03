using AboveGallery.Model;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace AboveGallery.Presenters.Providers
{
    public class PictureProvider : IPictureProvider
    {
        public async UniTask<Texture2D> GetPicture(IPictureModel model)
        {
            string path = model.WWWPicturePath;
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path is empty", nameof(model));
            }

            Texture2D texture;

            using (var request = UnityWebRequest.Get(path))
            {
                await request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                    throw new Exception("Request result is not success for " + path);

                texture = DownloadHandlerTexture.GetContent(request);
            }
            return texture;
        }
    }
}