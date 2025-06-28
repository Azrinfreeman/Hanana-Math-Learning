using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    void Awake() { }

    public TextMeshProUGUI questionNumberTopLabel;
    public TextMeshProUGUI questionLabel;

    public TextMeshProUGUI langkahLabel;
    public List<Transform> answerBtn;
    public Transform avatarState;
    public int countQuestion;
    public int countStep;

    void defaultAvatarFace()
    {
        avatarState.GetChild(0).gameObject.SetActive(true);
        avatarState.GetChild(1).gameObject.SetActive(false);
        avatarState.GetChild(2).gameObject.SetActive(false);
    }

    void AvatarSmile()
    {
        avatarState.GetChild(0).gameObject.SetActive(false);
        avatarState.GetChild(1).gameObject.SetActive(true);
        avatarState.GetChild(2).gameObject.SetActive(false);
    }

    void AvatarSad()
    {
        avatarState.GetChild(0).gameObject.SetActive(false);
        avatarState.GetChild(1).gameObject.SetActive(false);
        avatarState.GetChild(2).gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        countQuestion = 0;
        countStep = 0;

        Debug.Log(QuestionList.instance.questionlist[countQuestion].question[countStep]);
        applyQuestion();
        applyAnswerOnButton();
    }

    private void applyQuestion()
    {
        questionNumberTopLabel.text = "Soalan " + (countQuestion + 1);
        questionLabel.text = QuestionList.instance.questionlist[countQuestion].question[0];
    }

    private void applyAnswerOnButton()
    { //disable all buttons first
        switch (countStep)
        {
            case 0:
                langkahLabel.text = "Langkah 1 : Maklumat diberi";
                break;
            case 1:
                langkahLabel.text = "Langkah 2 : Operasi";
                break;
            case 2:
                langkahLabel.text = "Langkah 3 : Selesaikan ";
                break;
            case 3:
                langkahLabel.text = "Langkah 4 : Semak";
                break;
            case 4:
                langkahLabel.text = "Jawapan : ";
                break;
        }
        for (int i = 0; i < answerBtn.Count; i++)
        {
            answerBtn[i].gameObject.SetActive(false);
        }
        //check for answes count
        for (
            int i = 0;
            i
                < QuestionList
                    .instance
                    .questionlist[countQuestion]
                    .QuestionOnAnswersBtn[countStep]
                    .answer
                    .Count;
            i++
        )
        {
            answerBtn[i].gameObject.SetActive(true);
        }
        //assign text answer on all buttons
        for (
            int i = 0;
            i
                < QuestionList
                    .instance
                    .questionlist[countQuestion]
                    .QuestionOnAnswersBtn[countStep]
                    .answer
                    .Count;
            i++
        )
        {
            answerBtn[i].GetComponent<Button>().onClick.RemoveAllListeners();

            answerBtn[i].GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestionList
                .instance
                .questionlist[countQuestion]
                .QuestionOnAnswersBtn[countStep]
                .answer[i];

            if (
                QuestionList
                    .instance
                    .questionlist[countQuestion]
                    .QuestionOnAnswersBtn[countStep]
                    .answeOnBtn == i
            )
            {
                Debug.Log(
                    QuestionList
                        .instance
                        .questionlist[countQuestion]
                        .QuestionOnAnswersBtn[countStep]
                        .answeOnBtn
                );
                answerBtn[i].GetComponent<Button>().onClick.AddListener(() => AddMark());
                answerBtn[i].GetComponent<Button>().onClick.AddListener(() => NextStepping());
            }
            else
            {
                answerBtn[i].GetComponent<Button>().onClick.AddListener(() => IncorrectButton());
                answerBtn[i].GetComponent<Button>().onClick.AddListener(() => NextStepping());
            }
        }
    }

    void disableAllButtons(bool boolean)
    {
        //turn everybutton to disable
        for (int i = 0; i < answerBtn.Count; i++)
        {
            answerBtn[i].GetComponent<Button>().enabled = boolean;
        }
    }

    void showRealAnswer()
    {
        for (int i = 0; i < answerBtn.Count; i++)
        {
            if (
                QuestionList
                    .instance
                    .questionlist[countQuestion]
                    .QuestionOnAnswersBtn[countStep]
                    .answeOnBtn == i
            )
            {
                answerBtn[i].GetComponent<Image>().color = new Color32(145, 187, 21, 255);
            }
            else
            {
                answerBtn[i].GetComponent<Image>().color = Color.red;
            }
        }
    }

    void resetButton()
    {
        for (int i = 0; i < answerBtn.Count; i++)
        {
            answerBtn[i].GetComponent<Image>().color = new Color32(145, 187, 21, 255);
        }
    }

    public void AddMark()
    {
        //turn everybutton to disable
        disableAllButtons(false);

        StartCoroutine(addingmark());
    }

    public void IncorrectButton()
    { //turn everybutton to disable
        disableAllButtons(false);

        StartCoroutine(incorrect());
    }

    IEnumerator incorrect()
    {
        yield return new WaitForSeconds(1);
        if (!GameObject.Find("salah").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("salah").GetComponent<AudioSource>().Play();
        }
        //sad
        AvatarSad();
    }

    IEnumerator addingmark()
    {
        yield return new WaitForSeconds(1);
        if (!GameObject.Find("yay").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("yay").GetComponent<AudioSource>().Play();
        }
        if (!GameObject.Find("claps").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("claps").GetComponent<AudioSource>().Play();
        }

        //smile
        AvatarSmile();

        //play animation add coin and change text
        GameObject.Find("Coin").GetComponent<Animator>().Play("addCoin");
        yield return new WaitForSeconds(1.3f);
        //play animation default idle
        GameObject.Find("Coin").GetComponent<Animator>().Play("idleCoin");
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.05f);
            ScoreController.instance.score += 1;
            ScoreController.instance.SetScore();
        }
    }

    IEnumerator nextStep()
    {
        //turn everybutton to red
        for (int i = 0; i < answerBtn.Count; i++)
        {
            answerBtn[i].GetComponent<Button>().enabled = false;
        }
        yield return new WaitForSeconds(1.2f);
        showRealAnswer();
        countStep++;
        yield return new WaitForSeconds(3);

        if (
            countStep < QuestionList.instance.questionlist[countQuestion].QuestionOnAnswersBtn.Count
        )
        {
            //countStep++;
            // applyQuestion();
            applyAnswerOnButton();
        }
        else
        {
            countQuestion++;
            countStep = 0;
            applyQuestion();
            applyAnswerOnButton();
        }

        disableAllButtons(true);
        resetButton();
        defaultAvatarFace();
    }

    public void NextStepping()
    {
        StartCoroutine(nextStep());
    }

    // Update is called once per frame
    void Update() { }

    public void startQuestion()
    {
        //questionLabel.text = QuestionList.instance.question[countQuestion];
    }
}
