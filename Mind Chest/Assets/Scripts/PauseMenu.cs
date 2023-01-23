using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool inventoryIsOpen = false;
    public Text wheat;
    public GameObject pauseMenuUI;
    public GameObject inventoryMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            wheat.text = Player.instance.totalWheat.ToString();
            if (inventoryIsOpen)
            {
                closeInventory();
            }
            else
            {
                openInventory();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    void closeInventory()
    {
        inventoryMenuUI.SetActive(false);
        inventoryIsOpen = false;
    }

    void openInventory()
    {
        inventoryMenuUI.SetActive(true);
        inventoryIsOpen = true;
    }
    
}
