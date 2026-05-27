using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Animator animator;
    private Collider2D currentTrigger;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentTrigger != null)
        {
            if (currentTrigger.CompareTag("Interactable"))
            {
                animator.SetTrigger("DoorInteract");

                animator.SetBool("IsInteracting", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentTrigger = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == currentTrigger)
        {
            currentTrigger = null;
        }
    }

}
