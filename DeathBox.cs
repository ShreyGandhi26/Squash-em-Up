using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
    public string sceneToReload;
    public AudioSource deathSound;
    public float deathTimer = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {       
        deathSound.Play();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneToReload);
    }

}
