using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bullet;
    public float bulletSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        // Gun Rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float clampedAngle = Mathf.Clamp(angle, -60f, 60f);

        transform.rotation = Quaternion.Euler(0f, 0f, clampedAngle);
        var finalAngle = transform.rotation;

        // Firing the gun
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, finalAngle);
            // Calculate the velocity based on the rotation angle
            // Cos converts x angle into vector and Sin converts y angle into vector
            Vector2 bulletVelocity = new Vector2(Mathf.Cos(clampedAngle * Mathf.Deg2Rad), Mathf.Sin(clampedAngle * Mathf.Deg2Rad));
            // Set the velocity of the bullet
            newBullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity * bulletSpeed;
            // Despawn Bullet
            Destroy(newBullet, 4f);
        }
    }
}
