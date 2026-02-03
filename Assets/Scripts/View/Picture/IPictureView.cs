using UnityEngine;
using UnityEngine.Events;

namespace AboveGallery.View.Picture
{
    public interface IPictureView
    {
        Sprite Sprite { set; }
        bool IsPremium { set; }
        UnityEvent OnClick { get; }
    }
}
