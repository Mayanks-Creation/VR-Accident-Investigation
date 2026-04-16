using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Evidence Info")]
    public string evidenceName;

    [TextArea]
    public string description;

    public bool isCollected = false;

    [Header("Highlight Settings")]
    public Color emissionColor = new Color(0.8f, 0.8f, 0.8f, 1f);
    public float emissionIntensity = 0.3f;

    private Renderer[] renderers;
    private Material[][] materials;

    private Color[][] originalEmissionColors;

    void Start()
    {
        // Get ALL renderers in children
        renderers = GetComponentsInChildren<Renderer>();

        materials = new Material[renderers.Length][];
        originalEmissionColors = new Color[renderers.Length][];

        for (int i = 0; i < renderers.Length; i++)
        {
            materials[i] = renderers[i].materials;
            originalEmissionColors[i] = new Color[materials[i].Length];

            for (int j = 0; j < materials[i].Length; j++)
            {
                if (materials[i][j].HasProperty("_EmissionColor"))
                {
                    originalEmissionColors[i][j] = materials[i][j].GetColor("_EmissionColor");
                }
            }
        }
    }

    public void Interact()
    {
        if (isCollected) return;

        isCollected = true;

        RemoveHighlight();

        Debug.Log("Collected: " + evidenceName);

        GameManager.instance.RegisterEvidence(this);
    }

    public void Highlight()
    {
        if (isCollected) return;

        for (int i = 0; i < materials.Length; i++)
        {
            for (int j = 0; j < materials[i].Length; j++)
            {
                if (materials[i][j].HasProperty("_EmissionColor"))
                {
                    materials[i][j].EnableKeyword("_EMISSION");

                    Color finalColor = emissionColor * emissionIntensity;
                    materials[i][j].SetColor("_EmissionColor", finalColor);
                }
            }
        }
    }

    public void RemoveHighlight()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            for (int j = 0; j < materials[i].Length; j++)
            {
                if (materials[i][j].HasProperty("_EmissionColor"))
                {
                    materials[i][j].SetColor("_EmissionColor", originalEmissionColors[i][j]);
                }
            }
        }
    }
}