using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogecoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent(typeof(Player))) {
            GameManager.Instance.AddCoin();
            Destroy(this.gameObject);
        }
    }
}
