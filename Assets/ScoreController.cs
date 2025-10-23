using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    public int score;

    public TextMeshProUGUI textScore;
    public int scores;

    void Awake()
    {
        instance = this;
    }

    public void SetScore()
    {
        textScore.text = score.ToString();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

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
}
