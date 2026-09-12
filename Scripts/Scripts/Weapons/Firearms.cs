using UnityEngine;

public class Firearms : MonoBehaviour
{

    public enum FirearmType;
    {
        Pistol,
        SMG,
        Shotgun,
        Sniper,

    }

    public float cooldown;
    public int maxAmmo;
    public int ammo;
    public float damage;
    public float reloadTime;
    public float recoil;

    public FirearmType firearmType;

    void Start()
    {}

    void Activate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Debug.Log(hit.collider.name);
        }
    }

    void Update()
    {
        switch (firearmType)
        case firearmType.Pistol:
        {
            if (GetMouseButtonDown(0) && ammo > 0)
            {
                Activate();
                ammo -= 1;
            }

        }
    }
}
