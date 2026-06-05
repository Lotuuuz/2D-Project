using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPageManager : MonoBehaviour
{
    public List<CharacterData> familyMembers = new List<CharacterData>();

    public Image portraitUI;
    public TMP_Text nameUI;

    public TypewriterText typewriter;   // ← bruker denne i stedet for descriptionUI

    private int currentIndex = 0;

    public void ShowCharacter(int index)
    {
        currentIndex = index;

        var c = familyMembers[index];

        bool isNight = GameProgressManager.Instance.isNight;
        int dayIndex = GameProgressManager.Instance.currentDay - 1;

        nameUI.text = c.name;

        if (isNight)
        {
            portraitUI.sprite = c.nightPortrait;

            int safeNightIndex = Mathf.Clamp(dayIndex, 0, c.nightDescriptions.Length - 1);
            typewriter.ShowText(c.nightDescriptions[safeNightIndex]);   // ← typewriter
        }
        else
        {
            portraitUI.sprite = c.dayPortrait;

            int safeDayIndex = Mathf.Clamp(dayIndex, 0, c.dayDescriptions.Length - 1);
            typewriter.ShowText(c.dayDescriptions[safeDayIndex]);       // ← typewriter
        }
    }
}

