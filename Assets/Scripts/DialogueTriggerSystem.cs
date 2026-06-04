using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using System.Collections;

public class DialogueTriggerSystem : MonoBehaviour
{
    [SerializeField] private bool destroyAfterTriggering = true;

    [Header("Dialogue UI References")]
    //Dialogue UI variables
    [SerializeField] private GameObject dialogueUICanvas;
    [SerializeField] private TMP_Text speakerTextObject;
    [SerializeField] private TMP_Text dialogueTextObject;
    [SerializeField] private Image portraitImageObject;

    [Header("Typewriter effect speed")]
    //Typewriter effect variable (how fast the text appears)
    [SerializeField] private float typingEffectSpeed = 0.02f;

    [Header("Player Reference")]
    //Freeze player movement variables
    [SerializeField] private MovementPlayer playerMovementScript;

    [Header("Dialogue speaker names, lines and portaits")]
    //The dialogue text, type in inspector
    [SerializeField] private string[] speakerName;
    [SerializeField][TextArea] private string[] dialogueLines;
    [SerializeField] private Sprite[] portraitImages;

    private Coroutine typeWriterSequence;

    public System.Action OnDialogueFinished;

    //Internal variables
    private bool dialogueActive = false;

    private bool isTyping = false;

    private bool canContinueDialogue = true;

    private int line = 0;


    // When you press the interact button (V), either activate the dialogue, or go to next line
    void Update()
    {
        if (!dialogueActive)
        {
            return;
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (isTyping)
            {
                StopCoroutine(typeWriterSequence);

                dialogueTextObject.text = dialogueLines[line - 1];

                isTyping = false;

                canContinueDialogue = true;

                return;

            }

            if (canContinueDialogue)
            {
                if (line >= dialogueLines.Length)
                {
                    EndDialogue();
                }
                else
                {
                    ShowLine();
                }
            }
        }
    }

    //When you go into the trigger where you can interact, you can talk to the NPCs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
      
        dialogueActive = true;

        playerMovementScript.enabled = false;

        dialogueUICanvas.SetActive(true);

        line = 0;

        ShowLine();
    }

    //When you exit the dialogue trigger, you can no longer interact with the NPC
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        EndDialogue();
    }

    public void TriggerDialogue()
    {
        dialogueActive = true;

        playerMovementScript.enabled = false;

        dialogueUICanvas.SetActive(true);

        line = 0;

        ShowLine();
    }

    private void ShowLine()
    {
        speakerTextObject.text = speakerName[line];

        portraitImageObject.sprite = portraitImages[line];

        if (typeWriterSequence != null)
        {
            StopCoroutine(typeWriterSequence);
        }

        typeWriterSequence = StartCoroutine(TypeWriterTyping(dialogueLines[line]));

        line++;
    }


    //Typewriter effect, where letter appear one at a time
    private IEnumerator TypeWriterTyping(string line)
    {
        dialogueTextObject.text = "";

        isTyping = true;
        canContinueDialogue = false;

        yield return new WaitForSeconds(0.5f);

        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetButtonDown("Interact"))
            {
                dialogueTextObject.text = line;
                break;
            }

            dialogueTextObject.text += letter;

            yield return new WaitForSeconds(typingEffectSpeed);
        }

        isTyping = false;
        canContinueDialogue = true;

    }

    private void EndDialogue()
    {
        if (typeWriterSequence != null)
        {
            StopCoroutine (typeWriterSequence);
        }

        dialogueActive = false;

        isTyping = false;

        canContinueDialogue = false;

        if (dialogueUICanvas != null)
        {
            dialogueUICanvas.SetActive(false);
        }

        playerMovementScript.enabled = true;

        line = 0;

        if (destroyAfterTriggering == true)
        {
            gameObject.SetActive(false);
        }

        OnDialogueFinished?.Invoke();

    }


}