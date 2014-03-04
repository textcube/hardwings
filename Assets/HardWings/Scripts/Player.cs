using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameManager gameManager;
    public float pos = 0f;
    float speed = 0f;
    int direction = 0;

    public AudioClip hitClip, jumpClip, deathClip, goodClip;
    AudioSource hitSound, jumpSound, deathSound, goodSound;

	void Start () {
        hitSound = gameObject.AddComponent<AudioSource>();
        jumpSound = gameObject.AddComponent<AudioSource>();
        deathSound = gameObject.AddComponent<AudioSource>();
        goodSound = gameObject.AddComponent<AudioSource>();
        hitSound.clip = hitClip;
        jumpSound.clip = jumpClip;
        deathSound.clip = deathClip;
        goodSound.clip = goodClip;

        pos = 0f;
        speed = 0f;
        rigidbody2D.isKinematic = true;
	}

    public void StartPlayer()
    {
        rigidbody2D.isKinematic = false;
        OnJump();
    }
 
    void AddSpeed(float delta)
    {
        speed = Mathf.Clamp( speed + delta, -1f, 1f);
    }

    void SetSpeed(float spd)
    {
        speed = spd;
    }
    public void OnAttack()
    {
    }
    public void OnJump()
    {
        //if (!gameManager.isGameStart && !gameManager.isGameOver) gameManager.StartGame();
        jumpSound.Play();
        rigidbody2D.velocity = Vector2.zero;
        if (transform.position.y > 8f) return;
        rigidbody2D.AddForce(Vector2.up * 500);
    }
    public void OnRight()
    {
        direction = 1;
    }
    public void OnLeft()
    {
        direction = -1;
    }
    public void OnStop()
    {
        direction = 0;
        SetSpeed(0f);
    }

    void UpdateMovement()
    {
        if (direction != 0) AddSpeed(direction * 0.01f);
        pos += speed * Time.deltaTime;
    }

    public void PlayGoodSound()
    {
        goodSound.Play();
    }

    void DamageEffect()
    {
        hitSound.Play();
        deathSound.Play();
        gameManager.ShakeCam();
        gameManager.DamageEffect();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "pillar")
        {
            if (!gameManager.isGameOver) DamageEffect();
            //other.collider2D.enabled = false;
            gameManager.StopGame();
        }
        else
        {
            OnStop();
			if (!gameManager.isGameOver) DamageEffect();
			gameManager.StopGame();
            rigidbody2D.isKinematic = true;
            //hitSound.Play();
        }
    }

	void Update () {
        UpdateMovement();
        if (transform.position.y < -2f) transform.eulerAngles = new Vector3(0f, 0f, -60f);
        else transform.eulerAngles = new Vector3(0f, 0f, rigidbody2D.velocity.y * 2f);
	}
}
