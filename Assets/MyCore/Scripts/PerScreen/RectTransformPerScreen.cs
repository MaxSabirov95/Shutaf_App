using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransformPerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private Vector2 _longScreen;
    [SerializeField] private Vector2 _normalScreen;
    [SerializeField] private Vector2 _tablet;
#pragma warning restore 0649

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        WidthHeight();
    }

    public void WidthHeight()
    {
        if (Utils.IsLongScreen())
            SetWidthHeight(_longScreen);
        else if (Utils.IsNormalScreen())
            SetWidthHeight(_normalScreen);
        else
            SetWidthHeight(_tablet);

        void SetWidthHeight(Vector2 pos)
        {
            if (pos == Vector2.zero) return;

            _rectTransform.sizeDelta = pos;
        }
    }
}
