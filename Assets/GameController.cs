using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int scores;

    public TextMeshProUGUI textScore;

    void Awake()
    {
        instance = this;
    }

    public void AddScores(int score)
    {
        scores = scores + score;
        textScore.text = scores.ToString();
        GameObject.Find("yay").GetComponent<AudioSource>().Play();
        GameObject.Find("claps").GetComponent<AudioSource>().Play();
    }

    public void MinusScore(int score)
    {
        scores = scores - score;
        if (scores <= 0)
        {
            scores = 0;
        }
        textScore.text = scores.ToString();

        GameObject.Find("salah").GetComponent<AudioSource>().Play();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
