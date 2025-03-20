using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RectTransformTBLRPerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Long Screen")]
    [SerializeField] private int _longTop;
    [SerializeField] private int _longBottom;
    [SerializeField] private int _longRight;
    [SerializeField] private int _longLeft;

    [Header("Normal Screen")]
    [SerializeField] private int _normalTop;
    [SerializeField] private int _normalBottom;
    [SerializeField] private int _normalRight;
    [SerializeField] private int _normalLeft;

    [Header("Ipad Screen")]
    [SerializeField] private int _tabletTop;
    [SerializeField] private int _tabletBottom;
    [SerializeField] private int _tabletRight;
    [SerializeField] private int _tabletLeft;
#pragma warning restore 0649

    private void Start()
    {
        Padding();
    }

    public void Padding()
    {
        if (Utils.IsLongScreen())
            SetPadding(_longTop, _longBottom, _longRight, _longLeft);
        else if (Utils.IsNormalScreen())
            SetPadding(_normalTop, _normalBottom, _normalRight, _normalLeft);
        else
            SetPadding(_tabletTop, _tabletBottom, _tabletRight, _tabletLeft);

        void SetPadding(int top, int bottom, int right, int left)
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, left);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, right * -1);
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.y, bottom);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.y, top * -1);
        }
    }
}