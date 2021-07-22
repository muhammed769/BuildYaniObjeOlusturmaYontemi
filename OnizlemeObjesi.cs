using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnizlemeObjesi : MonoBehaviour
{
    public GameObject OlusacakObje;
    RaycastHit hit;

    public Material materyal;
    private bool olusturabilirmi; // olusturdu�um objenin i� i�e girmemesini sa�l�caz.

   
    // ---------------------------------------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        olusturabilirmi = true;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Tam orta noktadan bir ���n g�nderdik.Yani mausu nereye hareket ettirirsem ���n� cameray� referans alarak
                                                                     // oraya g�ndericem.

        if(Physics.Raycast(ray,out hit, 5000f, (1 << 6)))
        {
            // transform.position = hit.point;

            transform.position = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("zemin"))
        {
            Debug.Log("�arpma var.");

            GetComponent<MeshRenderer>().material.color = Color.green;
            olusturabilirmi = false;
        }
    }
    // ---------------------------------------------------------------------------------------------------------------------------------------------
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != null && !other.gameObject.CompareTag("zemin"))
        {
            GetComponent<MeshRenderer>().material.color = materyal.color ;
            olusturabilirmi = true;
        }
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // NOT : Unity taraf�nda Yeni bir Layer olu�tur ad� plane olsun ve Plane objesinin Layer'�n� plane se� ! ! ! ! !

        if (Physics.Raycast(ray, out hit, 5000f,(1 << 6))) // 1<<6 6'�nc� katmana ���n g�nder demektir.
        {
          //  transform.position = hit.point;

            transform.position = new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z);

        }

        if (Input.GetMouseButton(0))
        {

            if (olusturabilirmi)
            {
                Instantiate(OlusacakObje, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }   
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------



}
