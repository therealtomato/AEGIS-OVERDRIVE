using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    public PlayerMovement movement;

    public TMP_Text Stat;
    public TMP_Text Stam;
    public TMP_Text Vel;
    public TMP_Text Temp;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Stat.text = $"Status: Normal";
        Stam.text = $"Stamina: {movement.stam:F0}";
        Vel.text = $"Velocity: {movement.Velocity.magnitude:F2}";
        Temp.text = $"Temp: 32-C";
    }
}
