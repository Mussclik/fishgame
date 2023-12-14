using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button[] buttons;
    private int currentButtonIndex = 0;

    void Start()
    {
        // Set the first button as selected
        SelectButton(currentButtonIndex);
    }

    void Update()
    {
        // Navigate up
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeSelectedButton(-1);
        }

        // Navigate down
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeSelectedButton(1);
        }

        // Select the current button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttons[currentButtonIndex].onClick.Invoke();
        }
    }

    void ChangeSelectedButton(int direction)
    {
        // Deselect the current button
        buttons[currentButtonIndex].image.color = Color.white;

        // Change the current button index
        currentButtonIndex += direction;

        // Wrap around if reaching the end of the button list
        if (currentButtonIndex < 0)
        {
            currentButtonIndex = buttons.Length - 1;
        }
        else if (currentButtonIndex >= buttons.Length)
        {
            currentButtonIndex = 0;
        }

        // Select the new current button
        SelectButton(currentButtonIndex);
    }

    void SelectButton(int index)
    {
        buttons[index].Select();
        buttons[index].image.color = Color.cyan; // Highlight the selected button
    }
}
