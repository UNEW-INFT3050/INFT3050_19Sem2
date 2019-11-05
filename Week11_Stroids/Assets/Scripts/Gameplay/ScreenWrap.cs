using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {

	private Playfield m_playfield;

	// Use this for initialization
	void Start () 
	{
		m_playfield = GetComponentInParent<Playfield>();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_playfield != null)
		{
			Vector3 pos = transform.position;
			if (pos.x < m_playfield.Left)
			{
				pos.x = m_playfield.Right;
			}
			if (pos.x > m_playfield.Right)
			{
				pos.x = m_playfield.Left;
			}
			if (pos.y > m_playfield.Top)
			{
				pos.y = m_playfield.Bottom;
			}
			if (pos.y < m_playfield.Bottom)
			{
				pos.y = m_playfield.Top;
			}
			transform.position = pos;
		}
	}


}
