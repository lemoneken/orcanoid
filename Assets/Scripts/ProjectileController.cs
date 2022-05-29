using System.Collections;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float projectileSpeed = .1f;
    public int speedIncreasePause = 2;
    public float speedIncreaseStep = .05f;
    public float speedIncreaseJump = 1;

    //Direction and speed
    private float currentSpeedVertical = 0;
    private float directionVertical = 1;
    private float currentSpeedHorizontal = 0;
    private float directionHorizontal = 1;

    private AudioSource bumpAudio;

    // Start is called before the first frame update
    void Start()
    {
        bumpAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var positionChange = new Vector3(currentSpeedHorizontal * directionHorizontal, currentSpeedVertical * directionVertical, 0);
        transform.position = transform.position + Time.deltaTime * positionChange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var otherObjTag = collision.gameObject.tag;
        var playMusic = true;

        switch (otherObjTag)
        {
            case "Enemy":
                ChangeDirectionHorizontal();
                ChangeDirectionVertical();
                IncreaseSpeed(speedIncreaseJump);
                break;
            case "Wall":
                ChangeDirectionHorizontal();
                IncreaseSpeed(speedIncreaseJump);
                break;
            case "Player":
            case "Ceiling":
                ChangeDirectionVertical();
                IncreaseSpeed(speedIncreaseJump);
                break;
            case "Floor":
                GameOver();
                playMusic = false;
                break;
        }

        if (playMusic)
        {
            bumpAudio.Play();
        }
    }

    public void Launch(GameObject parent)
    {
        Disattach(parent);
        var axisVal = Mathf.Sign(Input.GetAxis("Horizontal"));
        directionHorizontal = axisVal;

        IncreaseSpeed(projectileSpeed);
        StartCoroutine(nameof(ContinuousSpeedIncrease));
    }

    private void IncreaseSpeed(float speedIncrease)
    {
        currentSpeedVertical += speedIncrease;
        currentSpeedHorizontal += speedIncrease;
    }

    private void ChangeDirectionHorizontal()
    {
        directionHorizontal = -directionHorizontal;
    }

    private void ChangeDirectionVertical()
    {
        directionVertical = -directionVertical;
    }

    private IEnumerator ContinuousSpeedIncrease()
    {
        yield return new WaitForSeconds(speedIncreasePause);
        IncreaseSpeed(speedIncreaseStep);
    }

    private void Disattach(GameObject parent)
    {
        transform.parent = parent.transform.parent;
    }

    private void GameOver()
    {
        Destroy(gameObject);
        GameManager.GameOver();
    }
}
