using UnityEngine;
using UnityEngine.SceneManagement;

public class JournalManager : MonoBehaviour
{

    
    public CharacterPageManager CharacterPageManager;
    public MovementPlayer movementPlayer;
    [SerializeField] private AudioClip[] pageTurn;

    
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

    [HideInInspector] public bool isOpen = false;
    public KeyListUI keyListUI;

    void Start()
    {
    
        {
            // Finn Player automatisk hvis den ikke er satt i Inspector
            if (movementPlayer == null)
                movementPlayer = FindAnyObjectByType<MovementPlayer>();


            journalPanel.SetActive(false);
           // ShowMenuPage(); // Starter på meny-siden
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
            movementPlayer.enabled = false;
            Time.timeScale = 0f;

            ShowMenuPage();

            keyListUI.Refresh();   // ← FLYTTET HIT
        }
        else
        {

            Time.timeScale = 1f;
            movementPlayer.enabled = true;
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

        Debug.Log("Show Menu page er runna!");

        SoundFXManager.Instance.PlayRandomSoundFXClip(pageTurn, transform, 1f);
    }

    public void ShowObjectivePage()
    {
        backgroundMenu.SetActive(false);
        backgroundObjective.SetActive(true);
        backgroundCharacter.SetActive(false);

        menuPage.SetActive(false);
        objectivePage.SetActive(true);
        characterPage.SetActive(false);

        Debug.Log("Show bjective page er runna!");

        SoundFXManager.Instance.PlayRandomSoundFXClip(pageTurn, transform, 1f);

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

        Debug.Log("Show Character page er runna!");
        SoundFXManager.Instance.PlayRandomSoundFXClip(pageTurn, transform, 1f);
    }

       

public void QuitToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Main Menu");
    }


}


