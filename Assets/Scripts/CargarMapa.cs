using UnityEngine;
using System.Collections;
using System.IO;

public class CargarMapa : MonoBehaviour {
    string archivo = "archivo.txt";
    public Transform PF_Block01;

    void Start() {
        float contador = 0;
        var sr = new StreamReader(Application.dataPath + "/" + archivo);
        while (!sr.EndOfStream)
        {
            string contenido = sr.ReadLine();
            var contenido2 = contenido.Split(" "[0]);
            for (int i = 0; i < contenido2.Length; i++)
            {
                switch (contenido2[i])
                {
                    case "@":
                        Instantiate(PF_Block01, new Vector3((float)(i / 4f) * PF_Block01.transform.localScale.x, contador), transform.rotation);
                        if(i+1 == contenido2.Length)
                            contador += (float)PF_Block01.transform.localScale.y * 1 / -2.9f;
                        break;
                }

                if (i + 1 == contenido2.Length)
                    contador += (float)PF_Block01.transform.localScale.y * 1 / -2.9f;
            }
        }

        sr.Close();


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
