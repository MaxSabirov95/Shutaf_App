using UnityEngine;

public class PositionPerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private Vector3 _longScreen;
    [SerializeField] private Vector3 _normalScreen;
    [SerializeField] private Vector3 _tablet;
#pragma warning restore 0649

    private void Start()
    {
        Position();
    }

    public void Position()
    {
        if (Utils.IsLongScreen())
            SetToPosition(_longScreen);
        else if (Utils.IsNormalScreen())
            SetToPosition(_normalScreen);
        else
            SetToPosition(_tablet);

        void SetToPosition(Vector3 pos)
        {
            if (pos == Vector3.zero) return;

            if (transform is RectTransform)
                (transform as RectTransform).anchoredPosition = pos;
            else
                transform.localPosition = pos;
        }
    }
}