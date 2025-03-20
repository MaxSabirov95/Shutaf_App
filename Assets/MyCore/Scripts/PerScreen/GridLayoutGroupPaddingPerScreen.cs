using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupPaddingPerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Long Screen")]
    [SerializeField] private int _leftLongScreen;
    [SerializeField] private int _rightLongScreen;
    [SerializeField] private int _topLongScreen;
    [SerializeField] private int _bottomLongScreen;

    [SerializeField] private int _xSpaceLongScreen;
    [SerializeField] private int _ySpaceLongScreen;

    [Header("Normal Screen")]
    [SerializeField] private int _leftNormalScreen;
    [SerializeField] private int _rightNormalScreen;
    [SerializeField] private int _topNormalScreen;
    [SerializeField] private int _bottomNormalScreen;

    [SerializeField] private int _xSpaceNormalScreen;
    [SerializeField] private int _ySpaceNormalScreen;

    [Header("Ipad Screen")]
    [SerializeField] private int _leftTablet;
    [SerializeField] private int _rightTablet;
    [SerializeField] private int _topTablet;
    [SerializeField] private int _bottomTablet;

    [SerializeField] private int _xSpaceTablet;
    [SerializeField] private int _ySpaceTablet;
#pragma warning restore 0649

    private GridLayoutGroup _gridLayoutGroup;

    private void Awake()
    {
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    private void Start()
    {
        Padding();
    }

    public void Padding()
    {
        if (Utils.IsLongScreen())
            SetPadding(_leftLongScreen, _rightLongScreen, _topLongScreen, _bottomLongScreen, _xSpaceLongScreen, _ySpaceLongScreen);
        else if (Utils.IsNormalScreen())
            SetPadding(_leftNormalScreen, _rightNormalScreen, _topNormalScreen, _bottomNormalScreen, _xSpaceTablet, _ySpaceTablet);
        else
            SetPadding(_leftTablet, _rightTablet, _topTablet, _bottomTablet, _xSpaceTablet, _ySpaceTablet);

        void SetPadding(int left, int right, int up, int bottom, int xSpace, int ySpace)
        {
            _gridLayoutGroup.padding.left = left;
            _gridLayoutGroup.padding.right = right;
            _gridLayoutGroup.padding.top = up;
            _gridLayoutGroup.padding.bottom = bottom;

            _gridLayoutGroup.spacing = new Vector2(xSpace, ySpace);
        }
    }
}
