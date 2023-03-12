using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsMenu;

    private bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            ToggleVisibility();
        }
    }
    
    public void ToggleVisibility()
    {
        
            if (isPaused)
            {
                CloseSettingsMenu();
                isPaused = false;
            }
            else
            {
                OpenSettingsMenu();
                isPaused = true;
            }
    }
    
    public void OpenSettingsMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
    }
}
