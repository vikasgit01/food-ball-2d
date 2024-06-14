using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform[] buttons;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject helpMenu;
    private void Start()
    {
        ButtonSizeReset();
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }

    public void Play()
    {
        ButtonSizeReset();
        FindObjectOfType<Audio_Manager>().Play("Button");
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Help()
    {
        ButtonSizeReset();
        FindObjectOfType<Audio_Manager>().Play("Button");
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void Back()
    {
        ButtonSizeReset();
        FindObjectOfType<Audio_Manager>().Play("Button");
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }

    public void Quit()
    {
        ButtonSizeReset();
        FindObjectOfType<Audio_Manager>().Play("Button");
        Debug.Log("Quit");
        Application.Quit();
    }

    void ButtonSizeReset()
    {
        foreach (var button in buttons)
        {
            button.localScale = Vector3.one;
        }
    }
}
