using UnityEngine;
using UnityEngine.SceneManagement;

public static class ProjectManager
{

    public static void EnterSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void EnterSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void TimeScale(float index)
    {
        Time.timeScale = index;
    }

    public static void ExitApplication()
    {
        ExitApplication();
    }
}