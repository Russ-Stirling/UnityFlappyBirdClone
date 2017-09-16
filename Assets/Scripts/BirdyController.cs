using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdyController : MonoBehaviour
{

    public float FlapForce = 200f;
    private bool IsDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private int Score = 0;
	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //one hit of physics, so one acceleration happeneing with a click is ok to do in one frame so ok in update
        //but constanat application (like holding down a key for constant application) should use FixedUpdate()
		if(!IsDead)
        {
            //if left click
            if(Input.GetMouseButtonDown(0))
            {
                //zero velocity start good for cartoony physics where exact same jump each time is required, not simulation physics
                rb2d.velocity = Vector2.zero;

                rb2d.AddForce(new Vector2(0, FlapForce));

                anim.SetTrigger("Flap");
            }
        }
	}

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        IsDead = true;
        anim.SetTrigger("Smack");
        GameController.Instance.BirdDied();
    }
}
