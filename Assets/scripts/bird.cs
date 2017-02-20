using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour  {

    // Upwards force of flap.
    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (isDead == false)
        {
            if (Input.GetMouseButtonDown (0))
            {
                // Reset velocisty to 0.
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce*10));
                anim.SetTrigger("flap");
            }
        }
	}

    // Check collision and activate death.
    void OnCollisionEnter2D( )
    {
        // Zero out velocities of bird on impact. 
        rb2d.velocity = Vector2.zero;
        // When we hit something, bird is dead. 
        isDead = true;
        anim.SetTrigger("die");
        // Acces singleton GameControl class and trigger birdDied.
        GameControl.instance.birdDied();
    }
}
