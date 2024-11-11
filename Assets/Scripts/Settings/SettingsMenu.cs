using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Space between menu items")]
    [SerializeField] Vector2 spacing;

    Button mainButton;
    SettingsMenuItem[] menuItems;
    bool isExpanded = false;

    Vector3 mainButtonPosition;
    int itemsCount;

    private void Start()
    {
        itemsCount = transform.childCount - 1;
        menuItems = new SettingsMenuItem[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItem>();
        }
        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButtonPosition = mainButton.transform.position;

        ResetPositions();
    }

    private void ResetPositions()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].transform.position = mainButtonPosition;
        }
    }

    private void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            float yPos = mainButtonPosition.y - spacing.y * (itemsCount - 1);
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].transform.position = new Vector2(mainButtonPosition.x, yPos + (spacing.y * i));
            }
        }
        else
        {
            ResetPositions();
        }
    }

    private void OnDestroy()
    {
        if (mainButton != null)
            mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
