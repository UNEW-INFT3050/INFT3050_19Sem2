using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 15.0f;
	public float lifetime = 5.0f;

	private float m_timer;
	// Use this for initialization
	void Start () {

	}

	// fire this bullet
	public void Fire(Vector3 position, Quaternion rotation)
	{
		m_timer = lifetime;
		transform.rotation = rotation;
		transform.position = position;
		gameObject.SetActive(true);
		
	}

	


	// this runs every frame
	void Update () {
		// euler integration to move forward
		transform.position += transform.up * speed * Time.deltaTime;

		// count down timer
		m_timer -= Time.deltaTime;

		// if timer has finished
		if (m_timer < 0)
		{
			// turn bullet off
			gameObject.SetActive(false);
		}
	}

    // check if this bullet is alive
    public bool IsAlive()
    {
        return gameObject.activeInHierarchy;
    }

    public void Explode()
    {
        gameObject.SetActive(false);
        m_timer = 0;
    }
}
