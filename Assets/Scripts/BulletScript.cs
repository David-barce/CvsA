using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;

    public AlienScript alienO { get; set; }
    public MagoMovement magoO { get; set; }
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AlienScript alien = collision.GetComponent<AlienScript>();
        MagoMovement mago = collision.GetComponent<MagoMovement>();

        if (alien != null)
        {

            if (magoO != null)
            {
                alien.Hit();
                DestroyBullet();
            }

        }
        if (mago != null)
        {

            if (alienO != null)
            {
                mago.Hit();
                DestroyBullet();
            }
        }

    }
}
