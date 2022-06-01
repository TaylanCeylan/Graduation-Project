using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject controls;

    private void Update()
    {
        ActivateControls();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void ActivateControls()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controls.SetActive(false);
        }
    }

    public void OpenControls()
    {
        controls.SetActive(true);
    }

}
