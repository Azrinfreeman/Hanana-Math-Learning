using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void startMusic()
    {
        GameObject.Find("music-bg").GetComponent<AudioSource>().Play();
    }

    public void LoadScenes(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                // Activate the scene
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
