using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    private AudioSource explosion;
    void Start()
    {
        explosion = GetComponent<AudioSource>();
        explosion.Play();
    }
}
