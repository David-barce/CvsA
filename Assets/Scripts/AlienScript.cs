using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienScript : MonoBehaviour
{
    public Transform Mago;
    public GameObject BulletPrefab;

    
    private float LastShoot;
    private int Health = 3;
    public static int MatarY = 1;

    void Start()
    {
        MatarY = 1;
    }

    void Update()
    {
        
        if (MatarY == 0) SceneManager.LoadScene("GameOver");
        if (Mago == null) return;

        Vector3 direction = Mago.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Mago.transform.position.x - transform.position.x);
        //Debug.Log($"la distancia es: {distance}");

        if (distance < 50.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Debug.Log("shoot");
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        bullet.GetComponent<BulletScript>().alienO= this;

    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            MagoMovement.Matar = MagoMovement.Matar - 1;
            Destroy(gameObject);
        }

    }
    //public void Hit()
    //{
    //    Health -= 1;
    //    if (Health == 0) Destroy(gameObject);
    //}
}