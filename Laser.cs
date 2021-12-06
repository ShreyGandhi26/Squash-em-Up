using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public string sceneToReload;

    public ParticleSystem blueDeath;
    public ParticleSystem pinkDeath;
    public IgnoreCollision ignore;
    public AudioSource deathSound;
    public AudioSource GameMusic;

    public float deathTimer = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Blue"))
        {
            Instantiate(blueDeath, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            GameMusic.Pause();
            deathSound.Play();
            Destroy(ignore);
            Invoke("Restart", deathTimer);
        }

        if (other.gameObject.CompareTag("Player_Pink"))
        {
            Instantiate(pinkDeath, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            GameMusic.Pause();
            deathSound.Play();
            Destroy(ignore);
            Invoke("Restart", deathTimer);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(sceneToReload);
    }
}
