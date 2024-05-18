using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    [Tooltip("Name of the scene where the music should stop playing.")]
    public string sceneToStopMusic;

    [Tooltip("Name of the scene where the music should start playing again.")]
    public string startingSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!string.IsNullOrEmpty(sceneToStopMusic) && scene.name == sceneToStopMusic)
        {
            StopMusic();
        }
        else if (!string.IsNullOrEmpty(startingSceneName) && scene.name == startingSceneName)
        {
            PlayMusic();
        }
    }

    public void PlayMusic()
    {
        if (GetComponent<AudioSource>().isPlaying) return;
        GetComponent<AudioSource>().Play();
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }
}
