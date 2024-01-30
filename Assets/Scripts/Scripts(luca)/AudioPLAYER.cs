using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Declara una variable estática llamada "instance" que hará referencia a la única instancia de la clase AudioManager (patrón singleton).
    public static AudioManager instance;

    // Declara variables públicas para el componente AudioSource y un arreglo de AudioClip para almacenar las pistas de música.
    public AudioSource musicSource;
    public AudioClip[] musicClips;

    // Declara una variable privada para realizar un seguimiento del índice de la pista de música actual en el arreglo.
    private int currentClipIndex = 0;

    // Define el método Awake, que se ejecuta cuando el objeto se instancia. Implementa el patrón singleton.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Define el método Start, que se ejecuta al inicio. Verifica y configura el AudioSource y reproduce la primera pista de música.
    private void Start()
    {
        if (musicSource == null)
        {
            musicSource = FindObjectOfType<AudioSource>();
            if (musicSource == null)
            {
                musicSource = gameObject.AddComponent<AudioSource>();
            }
        }

        PlayMusic();
    }

    // Define el método Update, que se ejecuta en cada frame. Verifica si la pista de música actual ha terminado de reproducirse.
    private void Update()
    {
        if (!musicSource.isPlaying)
        {
            OnMusicFinished();
            PlayNextMusic();
        }
    }

    // Define el método PlayMusic, que reproduce la pista de música actual. Muestra una advertencia si no se han asignado clips de música.
    public void PlayMusic()
    {
        if (musicClips.Length > 0)
        {
            musicSource.clip = musicClips[currentClipIndex];
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("No music clips assigned.");
        }
    }

    // Define métodos para pausar y reanudar la reproducción de la música.
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    // Define un método para detener la reproducción de la música.
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Define un método para reproducir la siguiente pista de música en el arreglo.
    public void PlayNextMusic()
    {
        currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
        PlayMusic();
    }

    // Define un método para ajustar el volumen del AudioSource.
    public void SetVolume(float volume)
    {
        musicSource.volume = Mathf.Clamp01(volume);
    }

    // Define un método llamado OnMusicFinished que se llama cuando la música ha terminado de reproducirse.
    private void OnMusicFinished()
    {
        // Puedes implementar lógica adicional o activar eventos cuando la música termina.
        Debug.Log("Music finished playing.");
    }
}
