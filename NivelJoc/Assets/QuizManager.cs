using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;

    public GameObject Quizpanel;
    public GameObject GoPanel;
    public GameObject Canvas;
    public GameObject CanvasIncheiereJocPozitiv;
    public GameObject CanvasIncheiereJocNegativ;

    public Text ScoreTxt;
    public Text RestantaTxt;
    public Text ScorTotalTxt;
    public Text IncercariScor;

    int totalQuestion = 0;
    public int score;

    private void Start()
    {
        totalQuestion = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
        score = 0;
    }
    public void retry()
    {
        Canvas.SetActive(false);
        int Incercari = System.Convert.ToInt32(IncercariScor.text);
        Incercari += 1;
        IncercariScor.text = System.Convert.ToString(Incercari);
        string[] scortxt = (ScorTotalTxt.text).Split('/');
        int scor = System.Convert.ToInt32(scortxt[0]);
        if (Incercari == 8)
        {
            ScorTotalTxt.text = " ";
            if (scor > 4)
            {
                CanvasIncheiereJocPozitiv.SetActive(true);
            }
            else
            {
                CanvasIncheiereJocNegativ.SetActive(true);
            }
        }
    }
    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        setRestanta();
        ScoreTxt.text = score + "/" + totalQuestion;
    }
    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);  
        generateQuestion();
    }
    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    void SetAnswer()
    {
        for(int i=0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
            Quizpanel.SetActive(true);
            GoPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Out of question");
            GameOver();
        }
    }

    void setRestanta()
    {
        float reusit = (float) totalQuestion / 2;
        if(score>= reusit)
        {
            string[] scortxt = (ScorTotalTxt.text).Split('/');
            int scor = System.Convert.ToInt32(scortxt[0]);
            ScorTotalTxt.text = (scor + 1) + "/8";
            RestantaTxt.text = "Ai trecut !";
        }
        else
        {
            RestantaTxt.text = "Mai incearca... RESTANTA :)";
        }
        Debug.Log(reusit);
    }
}
