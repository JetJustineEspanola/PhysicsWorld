using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text Questiontxt;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    private void SetAnswers()
    {
        // Check if the current question index is valid
        if (currentQuestion >= 0 && currentQuestion < QnA.Count)
        {
            // Iterate through options
            for (int i = 0; i < options.Length; i++)
            {
                // Check if the current option index is valid
                if (i < QnA[currentQuestion].Answers.Length)
                {
                    // Set option text to the corresponding answer
                    options[i].GetComponentInChildren<TMP_Text>().text = QnA[currentQuestion].Answers[i];

                    // Check if the current option is the correct answer
                    bool isCorrect = QnA[currentQuestion].CorrectAnswer == i;
                    options[i].GetComponent<AnswerScript>().isCorrect = isCorrect;

                    // Optionally, you can change the button color here if needed
                    if (isCorrect)
                    {
                        // Change the color of the button to indicate it's the correct answer
                        options[i].GetComponent<Image>().color = Color.green;
                    }
                }
                else
                {
                    // If there are fewer answers than options, clear the option text
                    options[i].GetComponentInChildren<TMP_Text>().text = "";

                    // Reset isCorrect flag
                    options[i].GetComponent<AnswerScript>().isCorrect = false;
                }
            }
        }
    }


    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        Questiontxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }
}
