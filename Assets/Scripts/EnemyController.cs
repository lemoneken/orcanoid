using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int points;
    private PowerupsManager powerupsManager;

    // Start is called before the first frame update
    void Start()
    {
        powerupsManager = GameObject.FindGameObjectWithTag("Infrastructure")
            .GetComponent<PowerupsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherObject = collision.gameObject;
        if (otherObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            SpawnPowerup();
            UpdateHiScore();
        }
    }

    private void SpawnPowerup()
    {
        var powerup = powerupsManager.GetPowerup();
        if (powerup != null)
        {
            Instantiate(powerup, transform.position, transform.rotation);
        }
    }

    private void UpdateHiScore()
    {
        var hiScoreController = GameObject.FindGameObjectWithTag("HiScore")
            .GetComponent<HiScoreController>();

        hiScoreController.UpdateHiScore(points);
    }
}
