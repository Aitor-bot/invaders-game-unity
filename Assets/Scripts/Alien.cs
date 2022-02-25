using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem _alienExplosion;
    [SerializeField] private GameObject _alienTorpedoPrefab;
    [SerializeField] private float _alienTorpedoFireRate = 0.7f;
    private bool _isAlive = true;
    private float _canFire = -1f;

    void Start()
    {
        StartCoroutine(FireAlienTorpedoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    
    IEnumerator FireAlienTorpedoRoutine()
    {
        while(_isAlive)
        {
            FireAlienTorpedo();
            yield return new WaitForSeconds(_alienTorpedoFireRate);
        }
    }

    void FireAlienTorpedo()
    {
        _canFire = Time.time + _alienTorpedoFireRate;
        Instantiate(_alienTorpedoPrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Missile")
        {
            GameObject alien = this.gameObject;
            GameObject missile = collision.gameObject;
            DestroyAlien(alien, missile);
        }
    }

    void DestroyAlien(GameObject alien, GameObject missile)
    {
        ParticleSystem destroyAlienEffect = Instantiate(_alienExplosion) as ParticleSystem;
        destroyAlienEffect.transform.position = this.transform.position;
        destroyAlienEffect.Play();
        Destroy(alien);
        Destroy(missile);
        Destroy(destroyAlienEffect.gameObject, 2000);
        _isAlive = false;
    }

}
