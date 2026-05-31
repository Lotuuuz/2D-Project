using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxMover : MonoBehaviour
{
    public Transform destination;
    public Image fadeScreen;

    private bool playerInRange;
    private bool moved;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !moved)
        {
            moved = true;
            StartCoroutine(MoveBoxSequence());
        }
    }

    IEnumerator MoveBoxSequence()
    {
        //Fade to black
        yield return StartCoroutine(Fade(0, 1));

        //Stays for a bit
        yield return new WaitForSeconds(2f);

        //Move the box
        transform.position = destination.position;

        //Disable collider
        GetComponent<Collider2D>().enabled = false;

        //Fade back in
        yield return StartCoroutine(Fade(1, 0));
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
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}