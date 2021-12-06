using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PinkEnd pinkTrigger;
    public BlueEnd blueTrigger;
    public AudioSource gameMusic;

    public string SceneToLoad;
    public string SceneToRestart;
    public float timeToLoad = 3f;

    private AudioSource soundClone;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pinkTrigger.pinkInPlace && blueTrigger.blueInPlace)
        {
            Invoke("NextLevel", timeToLoad);
            gameMusic.Pause();

        }
        else
        {

            CancelInvoke("NextLevel");
            gameMusic.UnPause();
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            Restart();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneToRestart);
    }
}
