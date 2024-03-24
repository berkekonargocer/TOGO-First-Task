using UnityEngine.SceneManagement;

public static class Utils
{
    public static void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}