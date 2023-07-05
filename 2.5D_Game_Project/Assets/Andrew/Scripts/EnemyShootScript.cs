using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    public Transform player;

    public GameObject bullet;

    public Transform enemyBulletSpawner;

    public LayerMask whatIsPlayer;

    public int shootRange;
    public bool playerInShootRange;

    // Shooting
    public float timeBetweenShots;
    bool alreadyAttacked;

    void Start()
    {
        player = GameObject.Find("PlayerVisual").transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerInShootRange = Physics.CheckSphere(transform.position, shootRange, whatIsPlayer);

        if (playerInShootRange) ShootPlayer();
    }

    void ShootPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(bullet, enemyBulletSpawner.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 50f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(AttackReset), timeBetweenShots);
        }
    }

    void AttackReset()
    {
        alreadyAttacked = false;
    }
}
