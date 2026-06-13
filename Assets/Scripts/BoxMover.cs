using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxMover : MonoBehaviour
{
    public Transform destination;
    public Image fadeScreen;
    public GameObject interactIndicator;

    private bool playerInRange = false;
    private bool moved = false;

    private void Start()
    {
        interactIndicator.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !moved)
        {
            interactIndicator.SetActive(false);

            moved = true;
            StartCoroutine(MoveBoxSequence());
        }
    }

    IEnumerator MoveBoxSequence()
    {
        //Fade to black
        yield return StartCoroutine(Fade(0, 1f));

        //Stays for a bit
        yield return new WaitForSeconds(2f);

        //Move the box
        transform.position = destination.position;

        //Disable collider
        GetComponent<Collider2D>().enabled = false;

        //Fade back in
        yield return StartCoroutine(Fade(1f, 0));
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;
        float duration = 0.5f;

        Color color = fadeScreen.color;

        while (time < duration)
        {
            time += Time.deltaTime;

            color.a = Mathf.Lerp(
                startAlpha,
                endAlpha,
                time / duration
            );

            fadeScreen.color = color;

            yield return null;
        }

        color.a = endAlpha;
        fadeScreen.color = color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !moved)
            playerInRange = true;
            interactIndicator.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
            interactIndicator.SetActive(false);
    }
}