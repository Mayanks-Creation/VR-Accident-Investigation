using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public FPSController playerController;

    [Header("Evidence Tracking")]
    public List<Interactable> allEvidence = new List<Interactable>();
    public int collectedCount = 0;

    [Header("UI")]
    public TextMeshProUGUI progressText;
    public GameObject decisionPanel;

    [Header("Evidence Popup")]
    public GameObject evidencePopup;
    public TextMeshProUGUI evidenceText;

    [Header("Settings")]
    public int minimumEvidenceRequired = 3;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateProgressUI();

        if (decisionPanel != null)
            decisionPanel.SetActive(false);

        if (evidencePopup != null)
            evidencePopup.SetActive(false);
    }

    public void RegisterEvidence(Interactable evidence)
    {
        collectedCount++;

        ShowEvidencePopup(evidence);

        UpdateProgressUI();
    }

    void UpdateProgressUI()
    {
        if (progressText != null)
        {
            progressText.text = "Evidence Found: " + collectedCount + "/" + allEvidence.Count;
        }
    }

    void ShowEvidencePopup(Interactable evidence)
    {
        if (evidencePopup != null && evidenceText != null)
        {
            evidencePopup.SetActive(true);
            evidenceText.text = evidence.evidenceName + "\n\n" + evidence.description;

            playerController.DisableMovement();
        }
    }

    public void CloseEvidencePopup()
    {
        if (evidencePopup != null)
            evidencePopup.SetActive(false);

        playerController.EnableMovement();

        if (collectedCount >= minimumEvidenceRequired)
        {
            UnlockDecisionPanel();
        }
    }

    void UnlockDecisionPanel()
    {
        if (decisionPanel != null)
        {
            decisionPanel.SetActive(true);
            playerController.DisableMovement();
        }
    }
}