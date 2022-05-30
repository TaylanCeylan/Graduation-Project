using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : MonoBehaviour
{
    public bool isResumed;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        isResumed = true;
    }
}
