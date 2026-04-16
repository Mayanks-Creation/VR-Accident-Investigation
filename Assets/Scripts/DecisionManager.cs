using UnityEngine;
using TMPro;

public class DecisionManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    public void ChooseOption(string choice)
    {
        if (choice == "Oil")
        {
            resultText.text = "Correct! Oil spill caused the accident.";
        }
        else
        {
            resultText.text = "Incorrect. Try again.";
        }
    }
}