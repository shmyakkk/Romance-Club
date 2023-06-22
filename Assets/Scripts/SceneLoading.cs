using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public Image loadingBar;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);  // Прогресс загрузки в диапазоне от 0 до 1

            // Обновление индикатора загрузки
            if (loadingBar != null)
            {
                loadingBar.fillAmount = progress;
            }

            yield return null;
        }
    }
}
