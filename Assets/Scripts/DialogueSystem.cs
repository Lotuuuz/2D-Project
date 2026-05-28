using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    [Header(" Dialogue UI References")]
    //Dialogue UI variables
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image portraitImage;

    [Header("Key Indicator reference")]
    //Indicator variable
    [SerializeField] private SpriteRenderer keyIndicator;

    [Header("Typewriter effect speed")]
    //Typewriter effect variable (how fast the text appears)
    [SerializeField] private float typingSpeed = 0.02f;

    private Coroutine typeWriterRoutine;

    private bool canContinueText = true;

    [Header("Player Reference")]
    //Freeze player movement variables
    [SerializeField] private MovementPlayer movementPlayer;

    [Header("Dialogue speaker names, lines and portaits")]
    //The dialogue text, type in inspector
    [SerializeField] private string[] speaker;
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Sprite[] portrait;


    //Internal variables
    private bool dialogueActiviated;

    private int step;


    // When you press the interact button (V), either activate the dialogue, or go to next line
    void Update()
    {
        if (Input.GetButtonDown("Interact") && dialogueActiviated == true && canContinueText)
        {
            movementPlayer.enabled = false;
            
            if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);

                movementPlayer.enabled = true;

                step = 0;
            }
            else
            {
                dialogueCanvas.SetActive(true);

                speakerText.text = speaker[step];
                
                portraitImage.sprite = portrait[step];
                
                if (typeWriterRoutine  != null)
                {
                    StopCoroutine(typeWriterRoutine);
                }

                typeWriterRoutine = StartCoroutine(TypeWriterEffect(dialogue[step]));
                step += 1;
            }

                
        }
    }

    //When you go into the trigger where you can interact, you can talk to the NPCs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialogueActiviated = true;

            keyIndicator.enabled = true;
        }
    }

    //When you exit the dialogue trigger, you can no longer interact with the NPC
    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueActiviated = false;

        dialogueCanvas.SetActive(false);

        keyIndicator.enabled = false;

        movementPlayer.enabled = true;

        step = 0;
    }


    //Typewriter effect, where letter appear one at a time
    private IEnumerator TypeWriterEffect(string line)
    {
        dialogueText.text = "";

        canContinueText = false;

        yield return new WaitForSeconds(0.5f);

        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetButtonDown("Interact"))
            {
                dialogueText.text = line;
                break;
            }

            dialogueText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }

        canContinueText = true;

    }

}
