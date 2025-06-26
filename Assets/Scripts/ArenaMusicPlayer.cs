using UnityEngine;

public class ArenaMusicPlayer : MonoBehaviour
{
    public AudioSource arenaMusicSource;

    void Start()
    {
        if (arenaMusicSource != null && !arenaMusicSource.isPlaying)
        {
            arenaMusicSource.Play();
        }
    }
}