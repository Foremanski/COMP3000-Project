using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunc : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenu;
    public bool scenePaused;

    // Start is called before the first frame update
    void Start()
    {
        scenePaused = false;
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScene();
        }
    }

    public void PauseScene()
    {
        if(scenePaused == true)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
            scenePaused = false;
        }
        else
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            scenePaused = true;
        }
    }
}
