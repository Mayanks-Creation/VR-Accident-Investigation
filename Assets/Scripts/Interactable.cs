using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Evidence Info")]
    public string evidenceName;

    [TextArea]
    public string description;

    public bool isCollected = false;

    public void Interact()
    {
        if (isCollected) return;

        isCollected = true;

        Debug.Log("Collected: " + evidenceName);

        GameManager.instance.RegisterEvidence(this);
    }
}