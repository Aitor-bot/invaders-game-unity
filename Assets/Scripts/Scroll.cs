using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private RawImage _image;
    private float y = 0.2f;

    // Update is called once per frame
    void Update()
    {
        _image.uvRect = new Rect(_image.uvRect.position + new Vector2(0, y) * Time.deltaTime, _image.uvRect.size);

    }
}