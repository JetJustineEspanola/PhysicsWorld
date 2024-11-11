using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    private TextMeshProUGUI answerTextMeshPro;
    private Button button; // Reference to the button component
    [SerializeField] private TextMeshProUGUI answerText; // Remove this line

    // To make it ask a new question after the first question
    [SerializeField] private QuestionSetup questionSetup;

    void Start()
    {
        answerTextMeshPro = GetComponentInChildren<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to a child GameObject
        button = GetComponent<Button>(); // Get the Button component attached to this GameObject
    }

    public void SetAnswerText(string newText)
    {
        answerTextMeshPro.text = newText; // Change answerText to answerTextMeshPro
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        if (isCorrect)
        {
            Debug.Log("CORRECT ANSWER");
            button.image.color = Color.green; // Change the button color to green
            questionSetup.CorrectAnswerSelected();
        }
        else
        {
            Debug.Log("WRONG ANSWER");
            button.image.color = Color.red; // Change the button color to red
            questionSetup.WrongAnswerSelected();
        }

        // Get the next question
        questionSetup.NextQuestion();
    }

}
