using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGameManager : MonoBehaviour
{

    private static SceneGameManager instance;
    
    private void Awake()
    {
        /*if (instance =! this && instance != null)
        {
            Destroy(instance);
        }*/

        DontDestroyOnLoad(this);
        
        loadLevel(1);
        
    }
    
    public void loadLevel(int levelnr)
    {
        if (levelnr == 0)
        {
            Application.LoadLevel("00-start");
        }
        else if (levelnr == 1)
        {
            Application.LoadLevel("01-menu");
        }
        else if (levelnr == 2)
        {
            Application.LoadLevel("02-level1");
        }
    }
}
