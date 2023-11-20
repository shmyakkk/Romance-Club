using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] private TMP_Text chapterNumberText;
    public Image loadingBar;
    public Text loadingText;

    private RectTransform rectTransform;

    private float imageWidth; //100%
    private float xPosition = 0; //0%

    private float delayTime = 2f;

    private void Start()
    {
        rectTransform = loadingBar.GetComponent<RectTransform>();
        imageWidth = rectTransform.rect.width;
    }

    public void LoadScene(string sceneName) 
    {
        chapterNumberText.text = "1 сезон/" + PlayerPrefs.GetInt("Chapter").ToString() + " серия";
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return new WaitForSeconds(delayTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);  // Прогресс загрузки в диапазоне от 0 до 1

            // Обновление индикатора загрузки
            if (loadingBar != null)
            {
                loadingText.text = (int)(progress * 100) + "%";
                xPosition = progress * imageWidth;
                rectTransform.anchoredPosition = new Vector2(xPosition, 0);
            }

            yield return null;
        }
    }
}
