using System;
using UnityEngine;
using System.Collections;

namespace JogoBrocolis.FTec {
  public class PlatformerCharacter2D : MonoBehaviour {
    [SerializeField] private float m_MaxSpeed = 16f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    public LayerMask groundLayer;

    private bool m_Grounded;            // Whether or not the player is grounded.
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    private bool Chomping = false;
    private bool ChompingOnCooldown = false;

    private bool Britadeirando = false;

    public GameObject toxicExplosion;

    bool doubleJump = false;

    public bool getChomping() {
      return Chomping;
    }

    public bool getBritadeirando() {
      return Britadeirando;
    }

    public void setBritadeirando() {
      var renderer = GameObject.Find("BrocolisPlayer").GetComponentInChildren<SkinnedMeshRenderer>();
      renderer.material = GameObject.Find("MaterialPowerUpRenderer").GetComponent<SkinnedMeshRenderer>().material;
      Britadeirando =  true;
      StartCoroutine("waitTimeBritadeirando");
      StartCoroutine("powerActive");
    }

    private void Awake() {
      // Setting up references.
      m_Anim = GetComponent<Animator>();
      m_Rigidbody2D = GetComponent<Rigidbody2D>();
      StartCoroutine("increaseSpeed");
    }

    private void FixedUpdate() {
      m_Grounded = false;

      RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayer);

      // If it hits something...
      if(hit.collider != null) {
        m_Grounded = true;
      }

      m_Anim.SetBool("Ground", m_Grounded);

      // Set the vertical animation
      m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

      if(m_Grounded) {
        doubleJump = false;
      }
    }


    public void Move(float move, bool jump, bool chomp) {

      //only control the player if grounded or airControl is turned on
      if(m_Grounded || m_AirControl) {

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        m_Anim.SetFloat("Speed", Mathf.Abs(move));

        // Move the character
        m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

        // If the input is moving the player right and the player is facing left...
        if(move > 0 && !m_FacingRight) {
          // ... flip the player.
          Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if(move < 0 && m_FacingRight) {
          // ... flip the player.
          Flip();
        }
      }
      // If the player should jump...
      //original was if ((m_Grounded || !doubleJump) && jump && m_Anim.GetBool("Ground"))
      //&& m_Anim.getBool("Ground") seems to block double jump
      if((m_Grounded || !doubleJump) && jump) {
        // Add a vertical force to the player.
        //m_Grounded = false;
        m_Anim.SetBool("Ground", false);

        m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);

        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

        if(!m_Grounded) {
          doubleJump = true;
        }
      }

      if(chomp) {
        if(!ChompingOnCooldown) {
          Chomping = true;
          ChompingOnCooldown = true;
          StartCoroutine("waitTimeChomp");
          StartCoroutine("waitTimeChompCooldown");
          m_Anim.SetBool("Chomping", chomp);
          GameObject.Find("Chomping").GetComponent<AudioSource>().Play();

        }
      }
    }

    private IEnumerator increaseSpeed() {
      yield return new WaitForSeconds(10);
      m_MaxSpeed = m_MaxSpeed + 1;
      if (m_MaxSpeed < 30) {
        StartCoroutine("increaseSpeed");
      }
    }

    private IEnumerator waitTimeChomp() {
      yield return new WaitForSeconds(3);
      Chomping = false;
      m_Anim.SetBool("Chomping", false);
    }

    private IEnumerator waitTimeChompCooldown() {
      yield return new WaitForSeconds(5);
      ChompingOnCooldown = false;
    }

    private IEnumerator powerActive() {
      yield return new WaitForSeconds(1);
      Instantiate(toxicExplosion, transform.position, Quaternion.identity);
      if (Britadeirando == true) {
        StartCoroutine("powerActive");
      }
    }

    private IEnumerator waitTimeBritadeirando() {
      yield return new WaitForSeconds(5);
      var renderer = GameObject.Find("BrocolisPlayer").GetComponentInChildren<SkinnedMeshRenderer>();
      renderer.material = GameObject.Find("MaterialBrocolisRenderer").GetComponent<SkinnedMeshRenderer>().material;
      Britadeirando = false;
    }

    private void Flip() {
      // Switch the way the player is labelled as facing.
      m_FacingRight = !m_FacingRight;

      // Multiply the player's x local scale by -1.
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
    }
  }
}
