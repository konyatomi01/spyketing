using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameOnPlayerDestroy : MonoBehaviour
{
    public string endSceneName = "End"; 

    void Start()
    {
        
        
    }

    void OnDestroy()
    {
        
        if (gameObject.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(endSceneName);
        }
    }
}
