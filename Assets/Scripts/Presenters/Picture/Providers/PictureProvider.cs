using AboveGallery.Model.Picture;
using Cysharp.Threading.Tasks;
using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace AboveGallery.Presenters.Picture.Providers
{
    public class PictureProvider : IPictureProvider
    {
        public async UniTask<Texture2D> GetPicture(IPictureModel model)
        {
            if (model is not IPictureDownloadable)
            {
                throw new NotImplementedException();
            }

            string path = ((IPictureDownloadable)model).WWWPicturePath;
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path is empty", nameof(model));
            }
            Debug.Log("stage 1");
            Texture2D texture;
            using (var request = UnityWebRequest.Get(path))
            {
                Debug.Log("stage 2");
                await request.SendWebRequest().ToUniTask();
                Debug.Log("stage 3");

                if (request.result != UnityWebRequest.Result.Success)
                {
                    throw new Exception("Request result is not success for " + path);
                }
                Debug.Log(BitConverter.ToString(request.downloadHandler.data));
                texture2D = DownloadHandlerTexture.GetContent(request);
                Debug.Log("stage 4");
            }
            return texture;
        }
    }
}