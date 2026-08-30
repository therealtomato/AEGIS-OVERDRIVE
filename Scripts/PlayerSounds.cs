using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    public AudioClip idle;
    public AudioClip walk;
    public AudioClip sprint;
    public AudioClip crouch;
    public AudioClip slide;
    public AudioClip dash;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip fall;

    public AudioSource source;

    public movementScript movement;
    
    void Start()
    {
        movement = GetComponent<MovementScript>();
    }

    void Play(sound);
    {
        
    }

    void Update()
    {
        
    }
}
