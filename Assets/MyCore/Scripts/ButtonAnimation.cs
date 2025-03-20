using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
#pragma warning disable 0649
    [SerializeField] private float _animSpeed;
    [SerializeField] private float _scaleDown;
    [SerializeField] private bool _pointerUpDownAnim;

    [SerializeField] private float _blobScaleDown;
    [SerializeField] private float _blobAnimSpeed;
    [SerializeField] private bool _blobAnim;
#pragma warning restore 0649
    private float _currentScale = 0f;

    private Button _button;

    private void OnDisable()
    {
        GetCurrentScale();
        transform.localScale = Vector3.one * _currentScale;
    }

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetCurrentScale();

        if (_pointerUpDownAnim)
            ScaleDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetCurrentScale();
        if (_pointerUpDownAnim)
            ScaleUp();
    }

    //via link inspector
    public void BlobAnim()
    {
        GetCurrentScale();
        if (_blobAnim)
            BlobDown();
    }

    void BlobDown()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale",
                    Vector3.one * _currentScale / _blobScaleDown,
                    "speed", _blobAnimSpeed,
                    "easeType", iTween.EaseType.linear,
                    "oncomplete", "BlobUp"));
    }

    void BlobUp()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale",
                    Vector3.one * _currentScale,
                    "speed", _blobAnimSpeed,
                    "easeType", iTween.EaseType.linear));
    }

    public void ScaleUp()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale",
                Vector3.one * _currentScale,
                "speed", _animSpeed,
                "easeType", iTween.EaseType.linear));
    }


    private void ScaleDown()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale",
            Vector3.one * _currentScale / _scaleDown,
            "speed", _animSpeed,
            "easeType", iTween.EaseType.linear));
    }

    private void GetCurrentScale()
    {
        if (_currentScale == 0)
            _currentScale = transform.localScale.x;
    }
}
