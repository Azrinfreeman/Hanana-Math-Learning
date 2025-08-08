using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionList : MonoBehaviour
{
    public static QuestionList instance;

    [SerializeField]
    public List<QuestionAndAnswer> questionlist = new List<QuestionAndAnswer>();

    void Awake()
    {
        instance = this;
    }

  
    [System.Serializable]
    public class QuestionAndAnswer
    {
        public List<String> question;
        public List<AnswerOnButton> QuestionOnAnswersBtn = new List<AnswerOnButton>();
    }

    [System.Serializable]
    public class AnswerOnButton
    {
        public List<string> answer;
        public int answeOnBtn;
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
