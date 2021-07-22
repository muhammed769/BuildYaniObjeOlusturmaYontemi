using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnizlemeObjesi : MonoBehaviour
{
    public GameObject OlusacakObje;
    RaycastHit hit;

    public Material materyal;
    private bool olusturabilirmi; // olusturduðum objenin iç içe girmemesini saðlýcaz.

   
    // ---------------------------------------------------------------------------------------------------------------------------------------------
    private void Start()
    {
        olusturabilirmi = true;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Tam orta noktadan bir ýþýn gönderdik.Yani mausu nereye hareket ettirirsem ýþýný camerayý referans alarak
                                                                     // oraya göndericem.

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
            Debug.Log("Çarpma var.");

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

        // NOT : Unity tarafýnda Yeni bir Layer oluþtur adý plane olsun ve Plane objesinin Layer'ýný plane seç ! ! ! ! !

        if (Physics.Raycast(ray, out hit, 5000f,(1 << 6))) // 1<<6 6'ýncý katmana ýþýn gönder demektir.
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
