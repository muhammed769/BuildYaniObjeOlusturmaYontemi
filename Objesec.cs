using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objesec : MonoBehaviour
{
    // public GameObject onIzlemeObjesi;

       public GameObject[] OnIzlemeObjeleri;
    
    public void olustur(int deger)
    {
        Instantiate(OnIzlemeObjeleri[deger]);

    }

}
