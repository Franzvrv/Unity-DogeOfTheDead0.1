using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

        if (collision.transform.GetComponent(typeof(Enemy)))
        {
            Enemy enemy = collision.transform.GetComponent<Enemy>();
            enemy.DamageEnemy(3);
        }
    }
}
