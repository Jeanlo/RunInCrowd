using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mensaje : MonoBehaviour {

    public Text TextoMensaje { get; set; }
    public static string ElMensaje { get; set; }

    void Start()
    {
        TextoMensaje = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if (TextoMensaje.text != ElMensaje)
            TextoMensaje.text = ElMensaje;
    }
}
