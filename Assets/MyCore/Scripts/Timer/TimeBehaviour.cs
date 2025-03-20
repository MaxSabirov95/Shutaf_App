using UnityEngine;
using UnityEngine.Events;

public class TimeBehaviour : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float _duration = 5f;
    [SerializeField] private UnityEvent _onTimerEnd = null;
#pragma warning restore 0649

    private Timer _timer;

    private void Start()
    {
        _timer = new Timer(_duration);

        _timer.OnTimerEnd += HandleTimerEnd;
    }
    private void Update()
    {
        _timer.Tick(Time.deltaTime);
    }

    private void HandleTimerEnd()
    {
        _onTimerEnd.Invoke();

        Destroy(this);
    }
}