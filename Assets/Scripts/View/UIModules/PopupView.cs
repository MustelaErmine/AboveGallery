using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AboveGallery.View.UIModules
{
    public class PopupView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _popupParent;
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            DestroyPopUp().Forget();
        }
        private async UniTaskVoid DestroyPopUp()
        {
            await _canvasGroup.DOFade(0, .9f).SetEase(Ease.OutQuint).AsyncWaitForKill();
            Destroy(_popupParent);
        }
    }
}