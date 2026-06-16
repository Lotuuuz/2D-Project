using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LadderMover : MonoBehaviour
{
    [Header("Ladder Setup")]
    public GameObject ladder;
    public Transform secondFloorSpawn;

    [Header("Required Item")]
    public KeyData atticRodKey;

    [Header("UI")]
    public Image fadeScreen;
    public GameObject interactIndicator;

    private bool playerInRange = false;
    private bool activated = false;

    private void Start()
    {
        if (ladder != null)
            ladder.SetActive(false);

        if (interactIndicator != null)
            interactIndicator.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange &&
            Input.GetKeyDown(KeyCode.E) &&
            !activated &&
            HasAtticRod())
        {
            activated = true;

            if (interactIndicator != null)
                interactIndicator.SetActive(false);

            StartCoroutine(ActivateLadder());
        }
    }

    private bool HasAtticRod()
    {
        return KeyInventory.Instance != null &&
               KeyInventory.Instance.collectedKeys.Contains(atticRodKey);
    }

    IEnumerator ActivateLadder()
    {
        // Fade to black
        yield return StartCoroutine(Fade(0f, 1f));

        // Stay black for a bit
        yield return new WaitForSeconds(2f);

        // Show ladder
        if (ladder != null)
            ladder.SetActive(true);

        // Move player upstairs
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            player.transform.position = secondFloorSpawn.position;

        // Fade back in
        yield return StartCoroutine(Fade(1f, 0f));
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float duration = 1.5f;
        float time = 0f;

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
        if (other.CompareTag("Player") &&
            !activated &&
            HasAtticRod())
        {
            playerInRange = true;

            if (interactIndicator != null)
                interactIndicator.SetActive(true);
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered trigger");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactIndicator != null)
                interactIndicator.SetActive(false);
        }
    }
}