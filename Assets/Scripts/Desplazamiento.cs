using UnityEngine;
using System.Collections;
using System;

public class Desplazamiento : MonoBehaviour
{

    public enum Direcciones
    {
        Arriba,
        Reposo
    }

    public Direcciones DireccionActual { get; set; }

    public DateTime TiempoUltimaActualizacion { get; set; }

    public Vector3 Velocidad { get; set; }

    public bool Saltando { get; set; }

    public float PosicionInicialY { get; set; }
	public int Puntuacion;

    void Awake ()
    {
        Velocidad = new Vector3(4.5f, 3.4f, 0);
        TiempoUltimaActualizacion = DateTime.Now;
        DireccionActual = Direcciones.Reposo;
        PosicionInicialY = transform.localPosition.y;
    }

	void Update ()
    {
        Desplazarse();
        EmpezarSalto();
        Saltar();

		Puntaje.PuntajeActual = (int)transform.position.x / 10;
		if (transform.localPosition.y < PosicionInicialY) {
			Destroy(this.gameObject);
			Application.Quit();
		
		}
    }

    public void Desplazarse()
    {
        float tiempo = Time.deltaTime;
        transform.Translate(Velocidad.x*tiempo, 0, 0);
    }

    public void EmpezarSalto()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && !Saltando)
            DireccionActual = Direcciones.Arriba;
    }

    public void Saltar()
    {
        if (DireccionActual == Direcciones.Arriba && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.04))
        {
            transform.Translate(0, Velocidad.y, 0);
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.9f;
            Saltando = true;
            DireccionActual = Direcciones.Reposo;
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }



    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Bloque") || colisionado.name.Contains("Caja"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            TiempoUltimaActualizacion = DateTime.Now;
            Saltando = false;
        }

		if (colisionado.name == "PF_Enemigo(Clone)")
		{
			Destroy(this.gameObject);
			Application.Quit();
		}

        if(colisionado.name == "PF_Final(Clone)")
        {
            Mensaje.ElMensaje = "GANASTE!";
			Destroy(this.gameObject);
			Application.Quit();
        }
    }

    public void OnTriggerExit2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("Bloque") || colisionado.name.Contains("Caja"))
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
