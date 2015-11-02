using UnityEngine;
using System.Collections;
using System;

public class Desplazamiento : MonoBehaviour {
    public enum Direcciones
    {
        Arriba,
        Reposo
    }

    public Direcciones DireccionActual { get; set; }

    public DateTime TiempoUltimaActualizacion { get; set; }

    public Vector3 Velocidad { get; set; }
                                       // Use this for initialization
    void Start ()
    {
        Velocidad = new Vector3(4.5f, 1f, 0);
        TiempoUltimaActualizacion = DateTime.Now;
        DireccionActual = Direcciones.Reposo;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Desplazarse();
        EmpezarSalto();
        Saltar();

        if (this.transform.localPosition.y < -3.84)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            DireccionActual = Direcciones.Reposo;
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, -3.84f, 0);
        }
    }

    public void Desplazarse()
    {
        float tiempo = Time.deltaTime;
        transform.Translate(Velocidad.x*tiempo, 0, 0);
    }

    public void EmpezarSalto()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Jump"))
            DireccionActual = Direcciones.Arriba;
    }

    public void Saltar()
    {
        if (DireccionActual == Direcciones.Arriba && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        {
            transform.Translate(0, Velocidad.y, 0);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 6f;
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }
}
