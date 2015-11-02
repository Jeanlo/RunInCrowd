using UnityEngine;
using System.Collections;

public class MoverCamara : MonoBehaviour {

    public float Velocidad { get; set; }
    // Use this for initialization
    void Start () {
        Velocidad = 4.5f;
    }
	
	// Update is called once per frame
	void Update () {
        Desplazarse();
    }
    public void Desplazarse()
    {
        float tiempo = Time.deltaTime;
        transform.Translate(Velocidad * tiempo, 0, 0);
    }
}
