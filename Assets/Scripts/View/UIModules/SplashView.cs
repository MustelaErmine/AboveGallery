using DG.Tweening;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AboveGallery.View.UIModules
{
    public class SplashView : MonoBehaviour
    {
        [SerializeField] private GameObject _splashParent;
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private float delay = 2f, fadeTime = 1.2f;

        private void Awake()
        {
            DestroySplash().Forget();
        }

        private async UniTaskVoid DestroySplash()
        {
            await UniTask.WaitForSeconds(delay);
            await _canvasGroup.DOFade(0, fadeTime).SetEase(Ease.OutCirc).AsyncWaitForKill();
            Destroy(_splashParent);
        }
    }
}