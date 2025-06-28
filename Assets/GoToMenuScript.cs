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

    IEnumerator loadMenu()
    {
        topTitle.text = "PERGI KE " + transform.gameObject.name.ToUpper();

        yield return new WaitForSeconds(1f);
        goToMenuTransform.gameObject.SetActive(true);
        goToSceneButton.onClick.AddListener(() => SceneManager.LoadScene(sceneName));
    }

    // Update is called once per frame
    void Update() { }
}
