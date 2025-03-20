using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizePerScreen : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float _longScreen;
    [SerializeField] private float _normalScreen;
    [SerializeField] private float _tablet;
#pragma warning restore 0649

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        CameraSize();
    }

    public void CameraSize()
    {
        if (Utils.IsLongScreen())
            SetSize(_longScreen);
        else if (Utils.IsNormalScreen())
            SetSize(_normalScreen);
        else
            SetSize(_tablet);

        void SetSize(float num)
        {
            if (num == 0) return;

            _camera.orthographicSize = num;
        }
    }
}
