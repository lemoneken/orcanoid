using UnityEngine;
using Random = UnityEngine.Random;

public class PowerupsManager : MonoBehaviour
{
    public GameObject powerupPrefab;

    private int numberOfEnemies;

    //Determines probability of powerup being returned. The greater the number, the bigger rarity.
    private int randomizerQueueSize = 3;

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
        var isPowerupReturned = DeterminePowerup();
        if (isPowerupReturned)
        {
            powerupPrefab.GetComponent<PowerupController>()
                .powerupType = PowerupType.Speed;

            return powerupPrefab;
        }
        else return null;
    }

    private bool DeterminePowerup()
    {
        var randomNumber = Random.Range(1, randomizerQueueSize);
        return randomNumber == 1;
    }
}
