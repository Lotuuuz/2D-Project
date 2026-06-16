using System.Collections;
using UnityEngine;

public class CutsceneInitiator : MonoBehaviour
{
    private CutsceneHandler cutsceneHandler;

    [SerializeField] private MovementPlayer movementPlayer;

    [SerializeField] private BoxCollider2D boxCollider;

    public void Start()
    {
        cutsceneHandler = GetComponent<CutsceneHandler>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(StartCutsceneSequence());
        }
    }

    IEnumerator StartCutsceneSequence()
    {
        cutsceneHandler.PlayNextElement();

        movementPlayer.enabled = false;

        yield return new WaitForSeconds(8f);

        movementPlayer.enabled = true;

        boxCollider. enabled = false;
    }

}
