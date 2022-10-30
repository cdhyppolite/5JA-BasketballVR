using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectALancer : MonoBehaviour
{
    public int valeur = 1;
    bool aMarquer;

    void OnTriggerEnter(Collider infoCol)
    {
        if ((infoCol.name == "zonePanier") && (!aMarquer))
        {
            aMarquer = true;
            gestionPerso.score += valeur;
            gestionPerso.jouerSonBut();
            
            StartCoroutine(OuvrirLumiere(infoCol.transform.GetChild(0).gameObject));

            Destroy(gameObject,10f);
        }
    }

    IEnumerator OuvrirLumiere(GameObject lumiere)
    {
        //Ouvrir
        lumiere.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

        yield return new WaitForSeconds(9);

        //Éteindre
        lumiere.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
}