using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
   
{
    [SerializeField] Text myText;
   
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Tiempo");
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    IEnumerator Tiempo()
    {
        int n;
        for(n=0; ; n++)
        {
            myText.text = "Tiempo transcurrido:" + n;

            yield return new WaitForSeconds(1f);
        }
    }
   
}
