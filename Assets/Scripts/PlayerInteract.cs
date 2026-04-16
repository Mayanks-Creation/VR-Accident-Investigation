using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 5f;

    [Header("UI")]
    public GameObject inspectUI;

    private Interactable currentTarget;

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
            inspectUI.SetActive(false);
        }
    }

    void ClearTarget()
    {
        currentTarget = null;
        inspectUI.SetActive(false);
    }
}