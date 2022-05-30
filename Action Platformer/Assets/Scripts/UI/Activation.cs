using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Activation : MonoBehaviour
{
    [SerializeField] GameObject shop;
    [SerializeField] GameObject quitMenu;

    bool isShopActive;
    bool isQuitActive;
    bool isOnMainMenu;
    QuitMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        isShopActive = false;
        isQuitActive = false;

        menu = quitMenu.gameObject.GetComponent<QuitMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateShop();
        ActivateQuitMenu();
        CheckIfMainMenu();
    }

    void ActivateShop()
    {
        if (Input.GetKeyDown(KeyCode.M) && isShopActive == true && !isOnMainMenu)
        {
            shop.SetActive(false);
            isShopActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.M) && isShopActive == false && !isOnMainMenu)
        {
            shop.SetActive(true);
            isShopActive = true;
        }
    }

    void ActivateQuitMenu()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) && isQuitActive == true && !isOnMainMenu) || menu.isResumed)
        {
            quitMenu.SetActive(false);
            isQuitActive = false;
            menu.isResumed = false;           
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isQuitActive == false && !isOnMainMenu)
        {
            quitMenu.SetActive(true);
            isQuitActive = true;
        }
    }

    void CheckIfMainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            isOnMainMenu = true;
        }
        else
        {
            isOnMainMenu = false;
        }
    }
}
