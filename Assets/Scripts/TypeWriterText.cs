using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterText : MonoBehaviour
{
    public TMP_Text textUI;
    public float speed = 0.03f;

    private string fullText;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    void Awake()
    {
        if (textUI == null)
            textUI = GetComponent<TMP_Text>();
    }

    public void ShowText(string text)
    {
        fullText = text;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        textUI.text = "";

        yield return null;

        foreach (char c in fullText)
        {
            textUI.text += c;
            yield return new WaitForSeconds(speed);
        }

        isTyping = false;
    }

    void Update()
    {
    

        // Klikk for å vise hele teksten med en gang
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                textUI.text = fullText;
                isTyping = false;
            }
            else
            {


            }
        }
    }
}
