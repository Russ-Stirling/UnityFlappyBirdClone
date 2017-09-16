using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackgroundController : MonoBehaviour
{
    private BoxCollider2D GroundCollider;
    private float GroundHorizontalLength;

	// Use this for initialization
	void Start ()
    {
        GroundCollider = GetComponent<BoxCollider2D>();
        GroundHorizontalLength = GroundCollider.size.x * transform.lossyScale.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //is it time to reppsition
        if(transform.position.x < (-1f * GroundHorizontalLength))
        {
            RepeatBackground();
        }
		
	}

    private void RepeatBackground()
    {
        Vector2 groundOffset = new Vector2(GroundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
