using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompteurFPS : MonoBehaviour
{

    public TextMeshProUGUI zoneText;
    [SerializeField] private float pollingTime = 1f;
    [SerializeField] private float time;
    [SerializeField] private int frameCount;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            zoneText.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
