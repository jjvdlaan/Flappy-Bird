using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        // Get reference to the rigibody object for this item.
        rb2d = GetComponent<Rigidbody2D>();
        // Take speed from the singleton gamecontroller. 
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (GameControl.instance.gameOver == true)
        {
            // Game over, stop moving the background.
            rb2d.velocity = Vector2.zero;
        }
	}
}
