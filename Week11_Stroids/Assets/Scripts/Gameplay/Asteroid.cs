using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{



    public enum State
    {
        Normal,
        Exploding,
        Exploded
    }

    public float minSpeed = 0.3f;
    public float maxSpeed = 1;
    public float maxRotation = 60;
    public float minRotation = 20;
    public float speedMultiplier = 1;
    public int size = 0;
    public int value = 20;
    public StroidsGame game;


    // the velocity of the asteroid
    Vector3 m_velocity;

    // the rotation speed of the asteroid
    float m_angularVelocity;

    State m_state = State.Normal;


    // Use this for initialization
    void Start()
    {
        // direction as an angle
        float heading = Random.Range(0, Mathf.PI * 2);

        // speed of asteroid
        float speed = Random.Range(minSpeed, maxSpeed) * speedMultiplier;

        // rotation 
        m_angularVelocity = Random.Range(minRotation, maxRotation);

        // can rotate either clockwise or anticlockwise
        if (Random.value > 0.5f)
        {
            m_angularVelocity = -m_angularVelocity;
        }

        // turn the speed and heading into a velocity vector
        m_velocity = new Vector3(speed * Mathf.Cos(heading), speed * Mathf.Sin(heading));

    }


    public void Explode()
    {
        m_state = State.Exploding;
    }

    // Update is called once per frame
    void Update()
    {
        // euler integration of velocity -> position
        switch (m_state)
        {
            case State.Normal:
                transform.position += (m_velocity * Time.deltaTime);
                transform.Rotate(0, 0, m_angularVelocity * Time.deltaTime);
                break;

            case State.Exploding:
                // animation would go here
                m_state = State.Exploded;
                break;

            case State.Exploded:
                game.AddScore(value);
                game.RemoveAsteroid(this);

                break;
        }

    }
}
