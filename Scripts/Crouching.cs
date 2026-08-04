using UnityEngine;

public class Crouching : MonoBehaviour
{

    PlayerMovement movementscript;

    void Start()
    {
        movementscript = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        movementscript.crouching = Input.GetKey(KeyCode.C);
        movementscript.sliding = movementscript.sprinting && Input.GetKey(KeyCode.C);
    }
}
