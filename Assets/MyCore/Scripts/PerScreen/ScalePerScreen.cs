using UnityEngine;

public class ScalePerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float _longScreen;
    [SerializeField] private float _normalScreen;
    [SerializeField] private float _tablet;
#pragma warning restore 0649

    private void Start()
    {
        Scale();
    }

    public void Scale()
    {
        if (Utils.IsLongScreen())
            SetScale(_longScreen);
        else if (Utils.IsNormalScreen())
            SetScale(_normalScreen);
        else
            SetScale(_tablet);

        void SetScale(float num)
        {
            if (num == 0) return;

            transform.localScale = Vector3.one * num;
        }
    }
}