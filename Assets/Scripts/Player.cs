using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 15f;
    [SerializeField] ParticleSystem playerExplosion;
    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private float _fireRate = 2f;

    [SerializeField] private Joystick _joystick;

    private float _canFire = -1f;
    public AudioSource sourceShoot;
    public AudioSource sourceDestroy;
    public GameObject gameOverText, restartButton;
    
    void Start()
    {
        gameOverText.SetActive (false);
        restartButton.SetActive (false);
        transform.position = new Vector3(0, 0, 0);
        sourceShoot = GetComponent<AudioSource>();
        sourceDestroy = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireMissile();
        
            // play the sound
            sourceShoot.Play();
        }

        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                FireMissile();

                sourceShoot.Play();

            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = Vector2.up * _joystick.Vertical + Vector2.right * _joystick.Horizontal;
        gameObject.transform.Translate(direction * _speed * Time.deltaTime);
    }
    
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f, 8.5f), Mathf.Clamp(transform.position.y, -4f, 0), 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            
            GameObject player = this.gameObject;
            GameObject asteroid = collision.gameObject;
            sourceDestroy.Play();
            DestroyPlayer(player, asteroid);
            
        }

        if(collision.tag == "Buff")
        {
            //Destroy(collision.gameObject);
            GameObject player = this.gameObject;
            GameObject buff = collision.gameObject;
            changePlayerSize(player, buff);
        }
    }

    void DestroyPlayer(GameObject player, GameObject asteroid)
    {
        ParticleSystem destroyPlayerEffect = Instantiate(playerExplosion) as ParticleSystem;
        destroyPlayerEffect.transform.position = this.transform.position;
        destroyPlayerEffect.Play();
        Destroy(player);
        Destroy(asteroid);
        Destroy(destroyPlayerEffect);
        gameOverText.SetActive (true);
        restartButton.SetActive (true);
    }  

    void changePlayerSize(GameObject player, GameObject buff)
    {
        Vector3 newScale = transform.localScale;
        newScale *= 0.2f;
        transform.localScale = newScale;
        Destroy(buff);
    }

    void FireMissile()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_missilePrefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
    }


}
