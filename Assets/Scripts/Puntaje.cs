using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
	public Text TextoPuntajeActual { get; set; }
	public static int PuntajeActual { get; set; }
	
	void Start ()
	{
		PuntajeActual = 0;
		TextoPuntajeActual = this.gameObject.GetComponent<Text>();
		TextoPuntajeActual.text = "Puntaje: " + PuntajeActual;
	}
	
	void Update ()
	{
		if("Puntaje: " + PuntajeActual != TextoPuntajeActual.text)
			TextoPuntajeActual.text = "Puntaje: " + PuntajeActual;
	}
}
