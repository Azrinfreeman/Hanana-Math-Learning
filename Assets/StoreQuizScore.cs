using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreQuizScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("QuizScore", ScoreController.instance.score);
    }

    // Update is called once per frame
    void Update() { }
}
