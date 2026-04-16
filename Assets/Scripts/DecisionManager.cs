using UnityEngine;
using TMPro;

public class DecisionManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    public void ChooseOption(string choice)
    {
        if (choice == "Oil")
        {
            resultText.text = "Correct!\n\n“ Oil spill caused a slip hazard leading to the accident “";
        }
        else
        {
            resultText.text = "“ This hazard exists, but it was not the direct cause, Try again “";
        }
    }
}