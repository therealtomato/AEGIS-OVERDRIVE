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
        if (Input.GetKey(KeyCode.C))
        {
            movementscript.crouching = true;
        }
        if (movementscript.sprinting && Input.GetKey(KeyCode.C))
        {
            movementscript.sliding = true;
        }
    }
}
