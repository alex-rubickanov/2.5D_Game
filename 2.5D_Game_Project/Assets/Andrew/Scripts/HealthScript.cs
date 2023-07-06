using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public int health;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.CompareTag("Bullet"))
        {
            health -= 15;
            Debug.Log("Player was hit");
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
