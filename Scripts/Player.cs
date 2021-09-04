using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	// Other
	private Rigidbody2D rb;
	public Animator screenShake;

	// Main
	public float jumpForce;
	public float movementSpeed;

	// Game Objects
	public GameObject lava;
	public GameObject gameOverPanel;
	public GameObject levelCompletePanel;
	public GameObject jumpParticle;
	public GameObject deathParticle;
	public GameObject jumpSound;

	// Methods
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		// A and D keys
		var movement = Input.GetAxis("Horizontal");
		transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

		// Jumping
		if (Input.GetKey(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
		{
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			Instantiate(jumpParticle, transform.position, Quaternion.identity);
			Instantiate(jumpSound, transform.position, Quaternion.identity);
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		// All of this is executed when our player touches anything that has the tag "Lava"
		if (other.CompareTag("Lava"))
		{
			gameOverPanel.SetActive(true);
			Destroy(gameObject);
			Instantiate(deathParticle, transform.position, Quaternion.identity);
			screenShake.SetTrigger("CamShake");
		}


		// Enables the level complete panel when our player touches anything that has the tag "EndingWall"
		if (other.CompareTag("EndingWall"))
		{
			levelCompletePanel.SetActive(true);
		}
	}
}