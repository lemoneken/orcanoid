using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = .1f;
    public float projectileSpeed = .1f;

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject projectile;

    private float forceMultiplier = 20;
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
            //if (!launched) 
            //{
            //    ChangeProjectilePosition(newPosition.x);
            //}            
        }

        if (!launched && Input.GetButtonDown("Jump"))
        {
            LaunchProjectile();
        }
    }

    //private void ChangeProjectilePosition(float newPositionX)
    //{
    //    var oldPosition = projectile.transform.position;
    //    projectile.transform.position = new Vector3(newPositionX, oldPosition.y, oldPosition.z);
    //}

    private bool InsideLevel(Vector3 newPosition)
    {
        var leftCollider = leftWall.GetComponent<BoxCollider2D>();
        var rightCollider = rightWall.GetComponent<BoxCollider2D>();

        var thisCollider = GetComponent<BoxCollider2D>();
        var extents = thisCollider.bounds.extents;

        return !leftCollider.bounds.Contains(newPosition - extents)
            && !rightCollider.bounds.Contains(newPosition + extents);
    }

    private void LaunchProjectile()
    {
        var axisVal = Input.GetAxis("Horizontal");

        projectile.transform.parent = this.transform.parent;
        var rigidBody = projectile.GetComponent<Rigidbody2D>();
        var force = new Vector2(axisVal * projectileSpeed * forceMultiplier, projectileSpeed * forceMultiplier);

        rigidBody.constraints = RigidbodyConstraints2D.None;
        rigidBody.AddRelativeForce(force);

        launched = true;
    }
}
