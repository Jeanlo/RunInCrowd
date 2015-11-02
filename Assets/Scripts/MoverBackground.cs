using UnityEngine;
using System.Collections;

public class MoverBackground : MonoBehaviour {

    public float Speed { get; set; }

    void Start()
    {
        Speed = 0.2f;
    }

    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * Speed) % 1, 0f);
    }
}
