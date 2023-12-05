using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderEnd : MonoBehaviour
{
    public string sceneToLoad;
    public Text textToScale;

    void Start()
    {
        
        textToScale.transform.localScale = Vector3.one;

        
        Invoke("ScaleTextAndLoadScene", 3f);
    }

    void ScaleTextAndLoadScene()
    {
        
        Vector3 targetScale = Vector3.one * 1.5f;

        
        StartCoroutine(ScaleOverTime(textToScale.transform, targetScale, 3f));

        
        Invoke("LoadScene", 3f);
    }

    void LoadScene()
    {
        
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator ScaleOverTime(Transform transformToScale, Vector3 targetScale, float duration)
    {
        float startTime = Time.time;
        Vector3 initialScale = transformToScale.localScale;

        while (Time.time - startTime < duration)
        {
            float progress = (Time.time - startTime) / duration;
            transformToScale.localScale = Vector3.Lerp(initialScale, targetScale, progress);
            yield return null;
        }

        
        transformToScale.localScale = targetScale;
    }
}