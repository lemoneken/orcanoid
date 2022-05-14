using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            UpdateHiScore();
        }
    }

    private void UpdateHiScore()
    {
        var hiScoreController = GameObject.FindGameObjectWithTag("HiScore")
            .GetComponent<HiScoreController>();

        hiScoreController.UpdateHiScore(points);
    }
}
