using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AboveGallery.View.UIModules
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(AspectRatioFitter))]
    public class SlidesContentHandler : MonoBehaviour
    {
        public RectTransform ContentTransform { get => GetComponent<RectTransform>(); }
        public AspectRatioFitter ContentFitter { get => GetComponent<AspectRatioFitter>(); }
    }
}