using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    [SerializeField] private int _missileSpeed;
    [SerializeField] ParticleSystem asteroidExplosion;
    void Update()
    {
        transform.Translate(Vector3.up * _missileSpeed * Time.deltaTime);

        if (transform.position.y > 8f)
        {
            if (transform.parent = null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            ScoreScript.scoreValue += 1;
            GameObject missile = this.gameObject;
            GameObject asteroid = collision.gameObject;
            DestroyAsteroid(missile, asteroid);
        }
    }

    

    void DestroyAsteroid(GameObject missile, GameObject asteroid)
    {
        ParticleSystem destroyAsteroidEffect = Instantiate(asteroidExplosion) as ParticleSystem;
        destroyAsteroidEffect.transform.position = this.transform.position;
        destroyAsteroidEffect.Play();
        Destroy(missile);
        Destroy(asteroid);
        Destroy(destroyAsteroidEffect);
    }  


}

