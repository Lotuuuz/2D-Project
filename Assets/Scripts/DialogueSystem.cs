using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;

public class DialogueSystem : MonoBehaviour
{

    //Dialogue UI variables
    [SerializeField] private GameObject dialogueCanvas;

    [SerializeField] private TMP_Text speakerText;

    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private Image portraitImage;
    

    //Indicator variable
    [SerializeField] private SpriteRenderer keyIndicator;
    

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
        if (Input.GetButtonDown("Interact") && dialogueActiviated == true)
        {
            if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);
            }
            else
            {
                dialogueCanvas.SetActive(true);

                speakerText.text = speaker[step];
                dialogueText.text = dialogue[step];
                portraitImage.sprite = portrait[step];

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
    }

}
