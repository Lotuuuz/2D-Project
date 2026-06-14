using TMPro;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetObjective(ObjectiveManager.Objective obj)
    {
        string objective = obj.text;
        string processedText = objective;

        // --- 1. Farg familiemedlem + 's ---
        foreach (var pair in ObjectiveManager.Instance.familyColors)
        {
            if (!string.IsNullOrEmpty(pair.name) && objective.Contains(pair.name))
            {
                string hex = ColorUtility.ToHtmlStringRGB(pair.color);

                string fullNameWithS = pair.name + "'s";

                if (objective.Contains(fullNameWithS))
                {
                    processedText = processedText.Replace(
                        fullNameWithS,
                        $"<color=#{hex}>{fullNameWithS}</color>"
                    );
                }
                else
                {
                    processedText = processedText.Replace(
                        pair.name,
                        $"<color=#{hex}>{pair.name}</color>"
                    );
                }

                break;
            }
        }

        // --- 2. Farg key basert på sprite-farge ---
        foreach (var key in ObjectiveManager.Instance.allKeys)
        {
            if (!string.IsNullOrEmpty(key.keyName) && processedText.Contains(key.keyName))
            {
                // hent farge fra midten av sprite
                Texture2D tex = key.keySprite.texture;
                Color spriteColor = tex.GetPixel(tex.width / 2, tex.height / 2);

                string hex = ColorUtility.ToHtmlStringRGB(spriteColor);

                processedText = processedText.Replace(
                    key.keyName,
                    $"<color=#{hex}>{key.keyName}</color>"
                );

                break;
            }
        }

        // --- 3. Completed styling ---
        if (obj.completed)
        {
            text.text = $"<s>{processedText}</s>";
            text.color = Color.black;
        }
        else
        {
            text.text = processedText;
            text.color = Color.black; // resten av teksten skal være svart
        }
    }
}


