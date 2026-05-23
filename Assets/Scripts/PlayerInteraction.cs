using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Animator animator;

    private Collider2D currentTrigger;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.E) && currentTrigger != null)
        {
            if (currentTrigger.CompareTag("Door"))
            {
                animator.SetBool("IsDoor", true);

                if (state.IsName("Interact_w_Door_Day_Animation") && state.normalizedTime >= 1f)
                {
                    animator.SetBool("IsDoor", false);
                }

                if (state.IsName("Int_w_Door_Night_Animation") && state.normalizedTime >= 1f)
                {
                    animator.SetBool("IsDoor", false);
                }


            }
            else if (currentTrigger.CompareTag("Interactable"))
            {
                animator.SetBool("IsInteracting", true);

                if (state.IsName("Interact_Door_Day") && state.normalizedTime >= 1f)
                {
                    animator.SetBool("IsInteracting", false);
                }

                if (state.IsName("Interact_Door_Night") && state.normalizedTime >= 1f)
                {
                    animator.SetBool("IsInteracting", false);
                }

            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Door") || other.CompareTag("Interactable"))
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
