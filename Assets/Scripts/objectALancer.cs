using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectALancer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider infoCol)
    {
        if (infoCol.name == "zonePanier")
        {
            Destroy(gameObject);
        }
    }
}
