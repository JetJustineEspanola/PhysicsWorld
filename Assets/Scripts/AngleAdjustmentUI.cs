using UnityEngine;
using TMPro;

public class AngleAdjustmentUI : MonoBehaviour
{
    public TMP_InputField angleInputField;
    public TMP_Text xVelocityText;
    public TMP_Text yVelocityText;
    public Bow bow;

    public void AdjustAngle()
    {
        float angle;
        if (float.TryParse(angleInputField.text, out angle))
        {
            bow.AdjustBowAngle(angle);
        }
        else
        {
            Debug.LogWarning("Invalid angle input!");
        }
    }
}
