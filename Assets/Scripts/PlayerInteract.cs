using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 5f;

    [Header("UI")]
    public GameObject inspectUI;

    private Interactable currentTarget;
    private Interactable lastTarget;

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null && !interactable.isCollected)
            {
                currentTarget = interactable;

                //Highlight logic
                if (lastTarget != currentTarget)
                {
                    ClearLastHighlight();

                    currentTarget.Highlight();
                    lastTarget = currentTarget;
                }

                inspectUI.SetActive(true);
                return;
            }
        }

        ClearTarget();
    }

    void TryInteract()
    {
        if (currentTarget != null)
        {
            currentTarget.Interact();
            ClearTarget();
        }
    }

    void ClearTarget()
    {
        currentTarget = null;
        inspectUI.SetActive(false);

        ClearLastHighlight();
    }

    void ClearLastHighlight()
    {
        if (lastTarget != null)
        {
            lastTarget.RemoveHighlight();
            lastTarget = null;
        }
    }
}