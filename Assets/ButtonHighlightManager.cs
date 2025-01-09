using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlightManager : MonoBehaviour
{
    // Buttons for all moves
    public Button attackButton;
    public Button chargeButton;
    public Button defendButton;
    public Button skill1Button;
    public Button skill2Button;

    // Store the original color settings for each button
    private ColorBlock attackButtonColors;
    private ColorBlock chargeButtonColors;
    private ColorBlock defendButtonColors;
    private ColorBlock skill1ButtonColors;
    private ColorBlock skill2ButtonColors;

    void Start()
    {
        // Save the original color settings for each button
        attackButtonColors = attackButton.colors;
        chargeButtonColors = chargeButton.colors;
        defendButtonColors = defendButton.colors;
        skill1ButtonColors = skill1Button.colors;
        skill2ButtonColors = skill2Button.colors;
    }

    /// <summary>
    /// Highlights the given button by setting its normal color to the selected color.
    /// </summary>
    public void HighlightButton(Button button)
    {
        var colors = button.colors;
        colors.normalColor = colors.selectedColor; // Use selected color for highlight
        button.colors = colors;
    }

    /// <summary>
    /// Resets all buttons to their original color settings.
    /// </summary>
    public void ResetAllButtons()
    {
        attackButton.colors = attackButtonColors;
        chargeButton.colors = chargeButtonColors;
        defendButton.colors = defendButtonColors;
        skill1Button.colors = skill1ButtonColors;
        skill2Button.colors = skill2ButtonColors;
    }

    /// <summary>
    /// Call this method at the end of a round to reset all button highlights.
    /// </summary>
    public void End()
    {
        ResetAllButtons();
    }
}
