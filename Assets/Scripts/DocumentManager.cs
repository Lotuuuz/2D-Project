using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer keyIndicator;

    [SerializeField] private GameObject documentCanvas;

    [SerializeField] private List<TMP_Text> diaryEntries;

    private int currentPage = 0;

    private void OnTriggerStay2D(Collider2D other)
    {
        keyIndicator.enabled = true;

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            OpenDocumentScreen();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        keyIndicator.enabled = false;
    }

    public void OpenDocumentScreen()
    {
        documentCanvas.SetActive(true);

        currentPage = 0;
        ShowPage(currentPage);
    }

    public void GoToNextPage()
    {
        if (currentPage < diaryEntries.Count - 1)
        {
            currentPage++;
            ShowPage(currentPage);

            Debug.Log("Going to next page");
        }
    }

    public void GoPreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowPage(currentPage);
        }
    }

    private void ShowPage(int pageIndex)
    {
        // Hide all pages
        foreach (TMP_Text entry in diaryEntries)
        {
            entry.enabled = false;
        }

        // Show the selected page
        diaryEntries[pageIndex].enabled = true;
    }

    public void ExitDocumentScreen()
    {
        documentCanvas.SetActive(false);

        Debug.Log("Exiting Document screen");
    }
}

