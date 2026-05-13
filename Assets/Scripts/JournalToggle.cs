using UnityEngine;

public class JournalToggle : MonoBehaviour

{

    public GameObject journalUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            journalUI.SetActive(!journalUI.activeSelf);
        }
    }
}