using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ContadorRastro : MonoBehaviourPunCallbacks
{

    public int contadorRastroLuz;
    public bool interaccionAzul;
    public bool interaccionNaranja;

    public int zonaAzul;
    public int zonaNaranja;

    public bool MismazonaDiferentesMundos;
    // Start is called before the first frame update
    void Start()
    {
        interaccionAzul = false;
        interaccionNaranja = false;
        contadorRastroLuz = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(interaccionAzul && interaccionNaranja)
        {
            
                MismazonaDiferentesMundos = true;
            
        }
        else
        {
            MismazonaDiferentesMundos = false;

        }
        
    }
}
