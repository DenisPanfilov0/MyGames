using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneQuit : MonoBehaviour
{
    

    public void QuitGame ()
    {
        
            Application.Quit();    // закрыть приложение
            Debug.Log("вышли");
         
    }
}
