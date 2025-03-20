using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupConstraintCountPerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private int _longScreen;
    [SerializeField] private int _normalScreen;
    [SerializeField] private int _tablet;
#pragma warning restore 0649

    private GridLayoutGroup _gridLayoutGroup;

    private void Awake()
    {
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
    }

    private void Start()
    {
        ConstraintCount();
    }

    public void ConstraintCount()
    {
        if (Utils.IsLongScreen())
            SetConstraintCount(_longScreen);
        else if (Utils.IsNormalScreen())
            SetConstraintCount(_normalScreen);
        else
            SetConstraintCount(_tablet);

        void SetConstraintCount(int num)
        {
            if (num == 0) return;

            _gridLayoutGroup.constraintCount = num;
        }
    }
}
