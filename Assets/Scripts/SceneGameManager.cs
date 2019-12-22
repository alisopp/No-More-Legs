using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGameManager : MonoBehaviour
{
    public static SceneGameManager Instance;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
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
            Application.LoadLevel("SampleScene");
        }else if (levelnr == 3)
        {
            Application.LoadLevel("level2");
        }
    }
}