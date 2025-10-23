using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenuScript : MonoBehaviour
{
    public TextMeshProUGUI topTitle;

    public Button goToSceneButton;

    public Transform goToMenuTransform;

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisplayMenu);
    }

    public void DisplayMenu()
    {
        StartCoroutine(loadMenu());
    }

    public void DisplayQuit()
    {
        StartCoroutine(loadQuitMenu());
    }

    IEnumerator loadQuitMenu()
    {
        topTitle.text = "KELUAR " + transform.gameObject.name.ToUpper();

        yield return new WaitForSeconds(1f);
        goToMenuTransform.gameObject.SetActive(true);
        goToSceneButton.onClick.RemoveAllListeners();
        goToSceneButton.onClick.AddListener(() => Application.Quit());
    }

    IEnumerator loadMenu()
    {
        topTitle.text = "PERGI KE " + transform.gameObject.name.ToUpper();

        yield return new WaitForSeconds(1f);
        goToMenuTransform.gameObject.SetActive(true);
        goToSceneButton.onClick.RemoveAllListeners();
        goToSceneButton.onClick.AddListener(() => LoadScenes(sceneName));
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

    // Update is called once per frame
    void Update() { }
}
