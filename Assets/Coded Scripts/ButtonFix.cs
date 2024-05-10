using UnityEngine;
using UnityEngine.UI;

public class ButtonFix : MonoBehaviour
{
    public Button closeButton; // Reference to the close button
    public Selectable nextButtonToHighlight; // Reference to the button you want to highlight next

    private void Start()
    {
        if (closeButton != null)
        {
            // Add listener to the close button
            closeButton.onClick.AddListener(CloseMenu);
        }
    }

    private void CloseMenu()
    {
        // Set the navigation to the next button to highlight
        if (nextButtonToHighlight != null)
        {
            Navigation nav = closeButton.navigation;
            nav.mode = Navigation.Mode.Explicit;
            nav.selectOnDown = nextButtonToHighlight;
            closeButton.navigation = nav;

            // Highlight the next button
            nextButtonToHighlight.Select();
        }

        // Optionally, you can perform any other actions related to closing the menu here
        // For example, hiding the menu panel or disabling its interactability
    }
}

