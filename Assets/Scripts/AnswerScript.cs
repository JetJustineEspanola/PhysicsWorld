using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            GetComponent<Button>().image.color = Color.green; // Change button color to green
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
        }
    }
}
