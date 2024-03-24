using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utils
{
    public static void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}