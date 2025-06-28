using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController1 : MonoBehaviour
{
    public static QuestionController1 instance;

    void Awake()
    {
        instance = this;
    }

    [System.Serializable]
    public class QuestionBubbles
    {
        public List<Transform> bubbles;
        public List<Transform> Questions;
    }

    public QuestionBubbles questions;
    public Transform CongratsPanel;

    // Start is called before the first frame update
    void Start()
    {
        int bubblesCount = GameObject.Find("Bubbles").transform.childCount;
        int questionsCount = GameObject.Find("Questions").transform.childCount;
        Transform bubble = GameObject.Find("Bubbles").transform;
        Transform question = GameObject.Find("Questions").transform;

        for (int i = 0; i < bubblesCount; i++)
        {
            questions.bubbles.Add(bubble.GetChild(i).transform);
        }

        for (int i = 0; i < questionsCount; i++)
        {
            questions.Questions.Add(question.GetChild(i).transform);
        }
    }

    public void startGame()
    {
        GameObject.Find("bgController").GetComponent<Animator>().SetBool("isStart", true);
    }

    public void nextQuestions()
    {
        GameObject.Find("PlayerParent").GetComponent<BoxCollider2D>().enabled = true;

        questions.Questions[0].gameObject.SetActive(false);
        questions.bubbles[0].gameObject.SetActive(false);
        questions.Questions.RemoveAt(0);
        questions.bubbles.RemoveAt(0);

        if (questions.bubbles.Count > 0)
        {
            questions.bubbles[0].gameObject.SetActive(true);
            ///
            questions.Questions[0].gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("bgController").GetComponent<Animator>().SetBool("isStart", false);
            CongratsPanel.transform.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() { }
}
