using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{


    public GameObject controlsPanel;
    public GameObject MainMenuUI;

    public string playSceneName = "LaneTest";

    public void PlayGame()
    {
        SceneManager.LoadScene(playSceneName);

    }

    public void OpenControls()
    {
       MainMenuUI.SetActive(false);
        controlsPanel.SetActive(true);

    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void QuitGame()

    {
        Application.Quit();
        Debug.Log("Quit game");

    }
}