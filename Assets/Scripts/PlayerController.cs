using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = .1f;

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject projectile;

    private bool launched;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var axisVal = Input.GetAxis("Horizontal");
        var oldPosition = transform.position;

        var newPositionX = oldPosition.x + movementSpeed * Time.deltaTime * axisVal;
        var newPosition = new Vector3(newPositionX, oldPosition.y, oldPosition.z);

        if (newPosition != oldPosition && InsideLevel(newPosition))
        {
            transform.position = newPosition;
        }

        if (!launched && Input.GetButtonDown("Jump"))
        {
            var projController = projectile.GetComponent<ProjectileController>();
            projController.Launch(gameObject);
            launched = true;
        }
    }

    private bool InsideLevel(Vector3 newPosition)
    {
        var leftCollider = leftWall.GetComponent<BoxCollider2D>();
        var rightCollider = rightWall.GetComponent<BoxCollider2D>();

        var thisCollider = GetComponent<BoxCollider2D>();
        var extents = thisCollider.bounds.extents;

        return !leftCollider.bounds.Contains(newPosition - extents)
            && !rightCollider.bounds.Contains(newPosition + extents);
    }
}
