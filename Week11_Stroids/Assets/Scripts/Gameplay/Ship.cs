using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public float thrust = 10.0f;
	public float topSpeed = 10.0f;
	public float rotationSpeed = 180;
    public StroidsGame game;
	public int bulletCount = 5;

	


	private Vector3 m_velocity = Vector3.zero;
	// Use this for initialization
	void Start () 
	{
		
		
	}


	// Update is called once per frame
	void Update () 
	{

		// update thrust
		if (Input.GetKey("up"))
		{
			m_velocity += transform.up * thrust * Time.deltaTime;
		}

		// update rotate left
		if (Input.GetKey("left"))
		{
			transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
		}

		// update rotate left
		if (Input.GetKey("right"))
		{
			transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
		}

		// fire
		if (Input.GetKeyDown("space"))
		{
			Fire ();
		}

		// check velocity against top speed
		if (m_velocity.magnitude > topSpeed)
		{
			m_velocity.Normalize();
			m_velocity *= topSpeed;
		}

		// euler integration of velocity -> position
		transform.position += (m_velocity * Time.deltaTime);


	}


    public void Explode()
    {
        game.RemoveShip();
    }

	public void Fire()
	{
        game.Fire();
	}
}
