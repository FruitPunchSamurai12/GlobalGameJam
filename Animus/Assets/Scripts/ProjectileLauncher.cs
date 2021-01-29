using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] float fireRate = 0.25f;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform spawnTransform;
    IMove mover;
    private float nextFireTime;
    float horizontal = -1f;
    public bool enlightened = false;
    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<IMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!enlightened)
        {
            return;
        }
        if (mover.Speed != 0)
        {
            horizontal = mover.Speed;
        }
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {

            Projectile projectile = Instantiate(projectilePrefab, spawnTransform.position, Quaternion.identity);
            projectile.Direction = horizontal > 0 ? 1 : -1;
            nextFireTime = Time.time + fireRate;
        }
    }
}
