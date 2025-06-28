using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;

    public int score;

    public TextMeshProUGUI textScore;

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
}
