﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObject {

    [Header("Settings")]
    public float bulletSpeed = 3f;
    public float rateBullet = 5f;
    public int damage = 1;

    private void Update() {
        transform.Translate(transform.right * bulletSpeed * Time.deltaTime * rateBullet);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other) {
            if (other.CompareTag("ShieldUnit"))
            {
                other.GetComponent<IAttackable>().TakeDamage(damage);
            }

            EnemyMove.pooling.Release(this);
            gameObject.SetActive(false);
        }
    }
}
