using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CompanyScreenManager : MonoBehaviour
{
    public static CompanyScreenManager Instance;

#pragma warning disable 0649
    [SerializeField] private CompanyElement[] _element;
    [SerializeField] private CompanyElement[] _specialElements;
    [SerializeField] private float _scaleTime;
    [SerializeField] private float _delayTime;
    [SerializeField] private UnityEvent _onSpecialElementsAction;
#pragma warning restore 0649

    public float DelayTime => _delayTime;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _element.Length; i++)
        {
            _element[i].ScaleZero();
        }
        for (int i = 0; i < _specialElements.Length; i++)
        {
            _specialElements[i].ScaleZero();
        }
        StartCoroutine(nameof(CompanyStuffAnim));
    }

    public void GoToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private IEnumerator CompanyStuffAnim()
    {
        for (int i = 0; i < _element.Length; i++)
        {
            _element[i].ScaleUp(_scaleTime);
            yield return new WaitForSeconds(_delayTime);
        }

        for (int i = 0; i < _specialElements.Length; i++)
        {
            _specialElements[i].ScaleUp(_scaleTime);
        }

        _onSpecialElementsAction?.Invoke();

        yield return new WaitForSeconds(2f);
        GoToNextScene();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
