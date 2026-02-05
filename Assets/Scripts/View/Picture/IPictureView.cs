using UnityEngine;
using UnityEngine.Events;

namespace AboveGallery.View.Picture
{
    public interface IPictureView
    {
        Sprite Sprite { set; }
        bool IsPremium { set; }
        bool IsVisible { set; }
        Transform Parent { set; }
        UnityEvent OnClick { get; }
    }
}
