using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalLayoutGroupPaddingPerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Long Screen")]
    [SerializeField] private int _leftLongScreen;
    [SerializeField] private int _rightLongScreen;
    [SerializeField] private int _topLongScreen;
    [SerializeField] private int _bottomLongScreen;

    [Header("Normal Screen")]
    [SerializeField] private int _leftNormalScreen;
    [SerializeField] private int _rightNormalScreen;
    [SerializeField] private int _topNormalScreen;
    [SerializeField] private int _bottomNormalScreen;

    [Header("Ipad Screen")]
    [SerializeField] private int _leftTablet;
    [SerializeField] private int _rightTablet;
    [SerializeField] private int _topTablet;
    [SerializeField] private int _bottomTablet;
#pragma warning restore 0649

    private VerticalLayoutGroup _verticalLayoutGroup;

    private void Awake()
    {
        _verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
    }

    private void Start()
    {
        Padding();
    }

    public void Padding()
    {
        if (Utils.IsLongScreen())
            SetPadding(_leftLongScreen, _rightLongScreen, _topLongScreen, _bottomLongScreen);
        else if (Utils.IsNormalScreen())
            SetPadding(_leftNormalScreen, _rightNormalScreen, _topNormalScreen, _bottomNormalScreen);
        else
            SetPadding(_leftTablet, _rightTablet, _topTablet, _bottomTablet);

        void SetPadding(int left, int right, int up, int bottom)
        {
            _verticalLayoutGroup.padding.left = left;
            _verticalLayoutGroup.padding.right = right;
            _verticalLayoutGroup.padding.top = up;
            _verticalLayoutGroup.padding.bottom = bottom;
        }
    }
}
