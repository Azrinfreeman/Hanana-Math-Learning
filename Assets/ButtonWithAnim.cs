using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonWithAnim : MonoBehaviour
{
    private Animator anim;

    public string animationName;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() { }

    public void PlayAnimAndLoadScene(string sceneName)
    {
        StartCoroutine(loadScene(sceneName));
    }

    IEnumerator loadScene(string sceneName)
    {
        anim.Play(animationName);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
