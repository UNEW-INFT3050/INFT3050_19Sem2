using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Main game behaviour for asteroids; acts as a bridge between disparate game parts
/// For simplicity we're rolling our own circular collision
/// </summary>
[RequireComponent(typeof(Playfield))]
public class StroidsGame : MonoBehaviour {


    
    // prefabs for spawning game entities
	public Asteroid[] asteroidPrefabs;
    public Bullet bulletPrefab;
    public Ship shipPrefab;

    // starting asteroid count
    public int asteroidBase = 4;

    // maximum asteroid spawn count
    public int asteroidSpqwnMax = 8;
    public float minDistance = 1.0f;
    public GameScore score;
    public IconSet icons;
    public float respawnTime = 5;
    public float levelSpeedMultiplier = 1.1f;

    public int bulletCount = 5;

    public int RemainingLives { get { return m_remainingLives; } }

    // all of our spawned asteroids
    private List<Asteroid> m_asteroids = new List<Asteroid>();
    private List<Bullet> m_bullets = new List<Bullet>();
    private Playfield m_playfield;
    private Ship m_ship;
    private float m_respawnTimer = 0;
    private int m_remainingLives = 2;
    private int m_level = 0;
    private float m_speedMultiplier = 1;


    // Use this for initialization
    void Start()
	{
        m_playfield = GetComponent<Playfield>();
        m_bullets = new List<Bullet>(bulletCount);

        for (int idx = 0; idx < bulletCount; idx++)
        {
            Bullet bullet = Instantiate(bulletPrefab) as Bullet;
            bullet.transform.parent = transform;
            bullet.gameObject.SetActive(false);
            m_bullets.Add(bullet);
        }
        SpawnShip();
        SpawnAsteroids(asteroidBase);
       
	}
	
	//
    // Update is called once per frame
	void Update () 
	{

        // process game flow logic - in normal gameplay we have a ship
        // and it's flying around, so check for collisions with asteroids
        if (m_ship != null)
        {
            // check for ship collisions
            var asteroid = checkPositionCollideWithAsteroid(m_ship.transform.position);

            // if we've hit an asteroid
            if (asteroid != null)
            {
                // asteroid explodes, and ship explodes
                m_respawnTimer = respawnTime;
                asteroid.Explode();
                m_ship.Explode();
            }
        }
        else
        {
            // if active ship doesn't exist we're waiting for respawn
            m_respawnTimer -= Time.deltaTime;
            if (m_respawnTimer < 0)
            {
                // once we've hit our time limit, respawn if we have enough lives
                // and we're not in an asteroid's path
                if (m_remainingLives > 0)
                {
                    if (checkPositionCollideWithAsteroid(Vector3.zero) == null)
                    {
                        m_remainingLives--;
                        
                        SpawnShip();
                    }

                }
                else
                {
                    EndGame();
                }
            }

        }


        // check for collisions between bullets and asteroids
        foreach (var bullet in m_bullets)
        {
            if (bullet.IsAlive())
            {
                foreach(var asteroid in m_asteroids)
                {
                    // simplest circular collision
                    var offset = bullet.transform.position - asteroid.transform.position;
                    if (offset.magnitude < minDistance * asteroid.transform.lossyScale.x)
                    {
                        int size = asteroid.size;
                        if (size > 0)
                        {
                            // next size down
                            int childSize = size - 1;
                            SpawnAsteroidAtPosition(asteroid.transform.position, childSize);
                            SpawnAsteroidAtPosition(asteroid.transform.position, childSize);
                        }
                        asteroid.Explode();
                        bullet.Explode();
                        break;
                    }
                    
                }
            }
        }


        if (m_asteroids.Count == 0)
        {
            m_level++;
            m_speedMultiplier *= levelSpeedMultiplier;
            int asteroidCount = System.Math.Min(asteroidBase + m_level, asteroidSpqwnMax);
            SpawnAsteroids(asteroidCount);
        }
	}


    //
    // check if a given position will collide with an asteroid
    Asteroid checkPositionCollideWithAsteroid(Vector3 position)
    {
       
        foreach (var asteroid in m_asteroids)
        {
            var offset = position - asteroid.transform.position;
            if (offset.magnitude < minDistance)
                return asteroid;
        }
        
        return null;
    }


    // complete the game
    public void EndGame()
    {
        SceneManager.LoadScene("Title");
    }


    // spawn a ship
    public void SpawnShip()
    {
        icons.SetCount(m_remainingLives);
        m_ship = Instantiate(shipPrefab) as Ship;
        m_ship.game = this;
        m_ship.transform.parent = transform;
    }


    // remove the ship from the game
    public void RemoveShip()
    {
        GameObject.Destroy(m_ship.gameObject);
        m_ship = null;
        
    }


    //
    // spawn a set of asteroids so they're not right on top of the ship
    public void SpawnAsteroids(int asteroidCount)
    {   
        // create an array of asteroids
        for (int asteroidIdx = 0; asteroidIdx < asteroidCount; asteroidIdx++)
        {
            SpawnAsteroidAwayFromShip(asteroidPrefabs.Length - 1);
        }
    }

    //
    // spawn an asteroid so it isn't on top of a ship
    public void SpawnAsteroidAwayFromShip(int size)
    {
        if (m_playfield == null)
        {
            Debug.LogError("game should have a playfield");
            return;
        }

       
        // create a new asteroid from prefab
        Asteroid asteroid = Instantiate(asteroidPrefabs[size]) as Asteroid;

        // find a random position away from the ship
        Vector3 shipPosition = new Vector3();

        if (m_ship != null)
        {
            shipPosition = m_ship.transform.position;
        }
        Vector3 position;
        do
        {
            position = m_playfield.GetRandomLocation();
        } while ((position - shipPosition).magnitude < minDistance);

        // set the asteroid's position in the play field
        asteroid.transform.position = position;
        asteroid.transform.parent = transform;
        asteroid.game = this;
        asteroid.speedMultiplier = m_speedMultiplier;
        asteroid.size = size;
        // add to the list
        m_asteroids.Add(asteroid);
        
    }


    // 
    // spawn a single asteroid at the given position
    public void SpawnAsteroidAtPosition(Vector3 position, int size)
    {
        if (m_playfield == null)
        {
            Debug.LogError("game should have a playfield");
            return;
        }


        // create a new asteroid from prefab
        Asteroid asteroid = Instantiate(asteroidPrefabs[size]) as Asteroid;

        // set the asteroid's position in the play field
        asteroid.transform.position = position;
        asteroid.transform.parent = transform;
        asteroid.game = this;
        asteroid.size = size;
        asteroid.speedMultiplier = m_speedMultiplier;
        // add to the list
        m_asteroids.Add(asteroid);
    }


    //
    // remove an asteroid from the play field
    public void RemoveAsteroid(Asteroid asteroid)
    {
        m_asteroids.Remove(asteroid);
        GameObject.Destroy(asteroid.gameObject);
    }


    //
    // add to the score
    public void AddScore(int value)
    {
        score.AddScore(value);
    }


    //
    // Fire gun
    public void Fire()
    {
        for (int bulletIdx = 0; bulletIdx < bulletCount; bulletIdx++)
        {
            // get next bullet
            Bullet bullet = m_bullets[bulletIdx];

            // if the bullet is not active (! means 'not')
            if (!bullet.IsAlive())
            {
                // fire the bullet
                bullet.Fire(m_ship.transform.position, m_ship.transform.rotation);
                break;
            }
        }
    }
}
