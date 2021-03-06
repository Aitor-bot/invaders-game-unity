using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTorpedo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _alienTorpedoSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _alienTorpedoSpeed * Time.deltaTime);
        if (transform.position.y < -5f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

}
