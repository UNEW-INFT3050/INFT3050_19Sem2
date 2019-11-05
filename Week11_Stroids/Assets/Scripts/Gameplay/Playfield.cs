using UnityEngine;
using System.Collections;

public class Playfield : MonoBehaviour {

	public float width = 5.0f;
	public float height = 4.0f;
	public float Left{get{ return transform.position.x - width / 2 ;}}
	public float Right{get{ return transform.position.x + width / 2;}}
	public float Top{get{ return transform.position.y + height/2;}}
	public float Bottom{get{ return transform.position.y - height / 2;}}

	public Vector2 GetRandomLocation()
	{
		return new Vector2(Random.Range(Left, Right), Random.Range(Top, Bottom));
	}


	void Start()
	{

	}

	// Update is called once per frame
	void Update () {

	}
}
