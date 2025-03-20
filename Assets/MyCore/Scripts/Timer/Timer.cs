using System;

public class Timer
{
    public float remainindSeconds { get; private set; }
    public Timer(float duration)
    {
        remainindSeconds = duration;
    }

    public event Action OnTimerEnd;

    public void Tick(float deltaTime)
    {
        if (remainindSeconds <= 0f) return;

        remainindSeconds -= deltaTime;

        CheckForTimerEnd();
    }

    private void CheckForTimerEnd()
    {
        if (remainindSeconds > 0f) return;

        remainindSeconds = 0f;

        OnTimerEnd?.Invoke();
    }
}