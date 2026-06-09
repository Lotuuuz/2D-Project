using UnityEngine;

public class JournalManager : MonoBehaviour
{
   
    
    public CharacterPageManager CharacterPageManager;
    public MovementPlayer movementplayer;
    
    [Header("Main Panel")]
    public GameObject journalPanel;

    [Header("Backgrounds")]
    public GameObject backgroundMenu;
    public GameObject backgroundObjective;
    public GameObject backgroundCharacter;

    [Header("Pages")]
    public GameObject menuPage;
    public GameObject objectivePage;
    public GameObject characterPage;

    private bool isOpen = false;
    public KeyListUI keyListUI;

    void Start()
    {
    
        {
            // Finn Player automatisk hvis den ikke er satt i Inspector
            if (movementplayer == null)
                movementplayer = FindAnyObjectByType<MovementPlayer>();


            journalPanel.SetActive(false);
            ShowMenuPage(); // Starter på meny-siden
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleJournal();
        }
    }

    public void ToggleJournal()
    {
        isOpen = !isOpen;
        journalPanel.SetActive(isOpen);

        if (isOpen)
        {
            keyListUI.Refresh();   // ← FLYTTET HIT
        }
    }


    public void ShowMenuPage()
    {
        // Backgrounds
        backgroundMenu.SetActive(true);
        backgroundObjective.SetActive(false);
        backgroundCharacter.SetActive(false);

        keyListUI.Refresh();
        // Pages
        menuPage.SetActive(true);
        objectivePage.SetActive(false);
        characterPage.SetActive(false);
    }

    public void ShowObjectivePage()
    {
        backgroundMenu.SetActive(false);
        backgroundObjective.SetActive(true);
        backgroundCharacter.SetActive(false);

        menuPage.SetActive(false);
        objectivePage.SetActive(true);
        characterPage.SetActive(false);
    }

    public void ShowCharacterPage()
    {
        backgroundMenu.SetActive(false);
        backgroundObjective.SetActive(false);
        backgroundCharacter.SetActive(true);

        menuPage.SetActive(false);
        objectivePage.SetActive(false);
        characterPage.SetActive(true);

        CharacterPageManager.ShowCharacter(0);

  
    }
}

