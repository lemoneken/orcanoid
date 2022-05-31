using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public float fallSpeed = .01f;
    public PowerupType powerupType;
    public float powerupValue = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var oldPosition = transform.position;
        transform.position = new Vector3(oldPosition.x, oldPosition.y - fallSpeed, oldPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherObject = collision.gameObject;
        if (otherObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        } 
        else if (otherObject.CompareTag("Player"))
        {
            var playerController = otherObject.GetComponent<PlayerController>();
            playerController.ApplyPowerup(this);
            Destroy(gameObject);
        }
    }
}
