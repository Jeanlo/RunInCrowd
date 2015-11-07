using UnityEngine;
using System.Collections;
using System.IO;

public class CargarMapa : MonoBehaviour {
    string archivo = "archivo.txt";
    public Transform PF_Bloque;
    public Transform PF_Bloque2;
    public Transform PF_Personaje;
    public Transform PF_Enemigo;
    public Transform PF_Caja;
    public Transform PF_Final;

    public float Contador { get; set; }

    void Start() {
        var sr = new StreamReader(Application.dataPath + "/" + archivo);
        while (!sr.EndOfStream)
        {
            string contenido = sr.ReadLine();
            var contenido2 = contenido.Split(" "[0]);
            for (int i = 0; i < contenido2.Length; i++)
            {
                switch (contenido2[i])
                {
                    case "#":
                        Instanciador(i, PF_Bloque, contenido2.Length);
                        break;

                    case "$":
                        Instanciador(i, PF_Bloque2, contenido2.Length);
                        break;

                    case "@":
                        Instanciador(i, PF_Caja, contenido2.Length);
                        break;

                    case "E":
                        Instanciador(i, PF_Enemigo, contenido2.Length);
                        break;

                    case "P":
                        Instanciador(i, PF_Personaje, contenido2.Length);
                        break;

                    case "X":
                        Instanciador(i, PF_Final, contenido2.Length);
                        break;
                }
            }

            Contador += (float)PF_Bloque.transform.localScale.y * 1 / -4f;
        }

        sr.Close();


    }

    public void Instanciador(int i, Transform aInstanciar, int limite)
    {
        Instantiate(aInstanciar, new Vector3((float)((i / 3.6f) * aInstanciar.transform.localScale.x) - 6.8f, Contador, aInstanciar.localPosition.z), transform.rotation);
    }
}
