using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    PlayerMovement movementscript;

    public AudioSource audiosource;
    public AudioClip idle;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip slide;
    public AudioClip dash;

    void Start()
    {
        movementscript = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        
    }
}
