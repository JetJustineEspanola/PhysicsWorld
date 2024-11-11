using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField]
    public List<QuestionData> questions;
    private QuestionData currentQuestion;

    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private TextMeshProUGUI categoryText;
    [SerializeField]
    private AnswerButton[] answerButtons;

    [SerializeField]
    private int correctAnswerChoice;

    private int correctAnswersCount;
    private int wrongAnswersCount;

    private void Awake()
    {
        // Get all the questions ready
        GetQuestionAssets();
    }

    // Start is called before the first frame update
    public void Start()
    {
        // Get a new question and set its values
        SelectNewQuestion();

        // Reset counts
        correctAnswersCount = 0;
        wrongAnswersCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetQuestionAssets()
    {
        // Get all of the questions from the Questions folder
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Questions"));
    }

    public void SelectNewQuestion()
    {
        // Check if there are any questions left in the list
        if (questions.Count > 0)
        {
            // Get a random index for selecting a question
            int randomQuestionIndex = Random.Range(0, questions.Count);

            // Set the current question to the randomly selected question
            currentQuestion = questions[randomQuestionIndex];

            // Remove the selected question from the list
            questions.RemoveAt(randomQuestionIndex);

            // Set the question text and answer choices
            SetQuestionValues();
            SetAnswerValues();
        }
        else
        {
            Debug.LogWarning("No questions left.");
        }
    }

    private void SetQuestionValues()
    {
        // Set the question text
        questionText.text = currentQuestion.question;
        // Set the category text
        categoryText.text = currentQuestion.category;
    }

    private void SetAnswerValues()
    {
        // Randomize the answer button order
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));

        // Set up the answer buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Create a temporary boolean to pass to the buttons
            bool isCorrect = false;

            // If it is the correct answer, set the bool to true
            if (i == correctAnswerChoice)
            {
                isCorrect = true;
            }

            answerButtons[i].SetIsCorrect(isCorrect);
            answerButtons[i].SetAnswerText(answers[i]);
        }
    }

    private List<string> RandomizeAnswers(List<string> originalList)
    {
        // Create a new list to store the randomized answers
        List<string> newList = new List<string>();

        // Perform the randomization
        while (originalList.Count > 0)
        {
            // Get a random index from the original list
            int randomIndex = Random.Range(0, originalList.Count);

            // Add the element at the random index to the new list
            newList.Add(originalList[randomIndex]);

            // Remove the element at the random index from the original list
            originalList.RemoveAt(randomIndex);
        }

        // Return the randomized list
        return newList;

    }
    public void CorrectAnswerSelected()
    {
        // Increment the correct answers count
        correctAnswersCount++;
    }

    public void WrongAnswerSelected()
    {
        // Increment the wrong answers count
        wrongAnswersCount++;
    }

    public void NextQuestion()
    {
        // Select and display the next question
        SelectNewQuestion();
    }

}
