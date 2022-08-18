using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAmin;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool onDoubleJump = false;
    public bool isOnDash = false;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAmin = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // handle jump trigger
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || (!isOnGround && !onDoubleJump)) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onDoubleJump = isOnGround ? false : true;
            isOnGround = false;
            playerAmin.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        // handle entering dash trigger
        if (Input.GetKeyDown(KeyCode.LeftShift) && isOnGround && !gameOver)
        {
            isOnDash = true;
            playerAmin.SetFloat("Speed_Multiplier", 2.0f);
        }
        // handle exiting dash trigger
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isOnGround && !gameOver)
        {
            isOnDash = false;
            playerAmin.SetFloat("Speed_Multiplier", 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            onDoubleJump = false;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("<color=red>Game Over!</color>");
            gameOver = true;
            playerAmin.SetBool("Death_b", true);
            playerAmin.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
