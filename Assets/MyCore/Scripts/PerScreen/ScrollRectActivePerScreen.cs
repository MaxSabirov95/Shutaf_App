using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectActivePerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private bool _longScreen;
    [SerializeField] private bool _normalScreen;
    [SerializeField] private bool _tablet;
#pragma warning restore 0649

    private ScrollRect _scrollRect;

    private void Awake()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    private void Start()
    {
        ScrollRect();
    }

    public void ScrollRect()
    {
        if (Utils.IsLongScreen())
            IsScrollRectActive(_longScreen);
        else if (Utils.IsNormalScreen())
            IsScrollRectActive(_normalScreen);
        else
            IsScrollRectActive(_tablet);

        void IsScrollRectActive(bool isActive)
        {
            _scrollRect.enabled = isActive;
        }
    }
}
