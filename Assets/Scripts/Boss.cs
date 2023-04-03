using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class Boss : Enemy
{
    private SpriteRenderer sprite;
    void Start()
    {
        health = 500;
        target = GameManager.Instance.playerTransform;
        sprite = GetComponent<SpriteRenderer>();
        aipath = GetComponent<AIPath>();
        aipath.maxSpeed = 3;
        aipath.canMove = true;
    }

    override public void KillEnemy() {
        Destroy(this.gameObject);
        GameManager.Instance.WinScene();
    }

    override public void DamageEnemy(int damage)
    {
        health -= damage;
        if (health <= 0) {
            KillEnemy();
        }
        else if (health < 150 && sprite.color.b != 0.6f) {
            StartCoroutine(AlternateSpeed());
            sprite.color = new Vector4(1f, 0.6f, 0.6f, 1);
        }
    }
    
    void Update() {
        FollowPlayer();
        if (aipath.desiredVelocity.x >= 0.01f) 
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aipath.desiredVelocity.x <= -0.01f) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } 
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.GetComponent(typeof(Player))) {
            Player player = other.GetComponent<Player>();
            player.DamagePlayer(10);
        }
    }

    IEnumerator AlternateSpeed() {
        while (this.gameObject) 
        {
            if (aipath.maxSpeed == 8) 
            {
                aipath.maxSpeed = 4;
            }
            else
            {
                aipath.maxSpeed = 8;
            }
            yield return new WaitForSeconds(2f);
        }

        yield break;
    }
}
