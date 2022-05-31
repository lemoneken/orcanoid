using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerupsManager : MonoBehaviour
{
    public List<GameObject> powerupPrefabs;

    private int numberOfEnemies;

    //Determines probability of powerup being returned. The greater the number, the bigger rarity.
    public int randomizerQueueSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Get number of enemies on the level
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numberOfEnemies = enemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPowerup()
    {
        var powerupNumber = DeterminePowerup();
        return powerupNumber < powerupPrefabs.Count
            ? powerupPrefabs[powerupNumber]
            : null;
    }

    private int DeterminePowerup()
    {
        var randomNumber = Random.Range(0, randomizerQueueSize);
        return randomNumber;
    }
}
