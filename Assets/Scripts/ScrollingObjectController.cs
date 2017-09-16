using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjectController : MonoBehaviour
{

    private Rigidbody2D Rb2d;
	// Use this for initialization
	void Start () {
        Rb2d = GetComponent<Rigidbody2D>();
        Rb2d.velocity = new Vector2(GameController.Instance.FlightSpeed, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameController.Instance.GameOver)
        {
            Rb2d.velocity = Vector2.zero;
        }
	}
}
