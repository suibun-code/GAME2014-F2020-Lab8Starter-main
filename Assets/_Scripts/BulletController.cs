using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    public float verticalSpeed;
    public float verticalBoundary;
    public int damage;
    public ContactFilter2D contactFilter;
    public List<Collider2D> colliders;
    public Vector3 direction;

    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
            direction = Vector3.up;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _CheckCollision();
    }

    private void _CheckCollision()
    {
        Physics2D.GetContacts(boxCollider2D, contactFilter, colliders);

        if (colliders.Count > 0)
        {
            if (colliders[0] != null)
            {
                BulletManager.Instance().ReturnBullet(gameObject);
            }
        }
    }

    private void _Move()
    {
        transform.position += direction * verticalSpeed * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.y > verticalBoundary)
        {
            BulletManager.Instance().ReturnBullet(gameObject);
        }
    }

    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     //Debug.Log(other.gameObject.name);
    //     switch (other.gameObject.tag)
    //     {
    //         case "Enemy":
    //             BulletManager.Instance().ReturnBullet(gameObject);
    //             break;
    //         case "Player":
    //             BulletManager.Instance().ReturnBullet(gameObject);
    //             break;
    //     }
    // }

    public int ApplyDamage()
    {
        return damage;
    }
}
