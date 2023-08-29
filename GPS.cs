using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Gps : MonoBehaviour
{
    public TMP_Text Warn;
    public TMP_Text Lat;
    public TMP_Text Long;
    private void Awake() {
        StartCoroutine(ConnectToGps());
    }
    IEnumerator ConnectToGps()
    {
        //Waiting for Enable Gps.
        while (!Input.location.isEnabledByUser)
        {
            print("location disable");
            yield return new WaitForSeconds(1);
        }

        //Star location service by Slider value accuracy.
        Input.location.Start(0f, 0f);

        //Initializing part max 10 sec.
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        //if Initializing too long.
        if (maxWait < 1)
        {
            Warn.text = "Time out";
            yield break;
        }

        //If connection to gps service is failed.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Warn.text = "Unable to connect Gps";
            yield break;
        }
        else
        {
            //If Connection successfull.
           Warn.text = "Connect Sucessful";
           InvokeRepeating("UpdateGpsData", 0.5f, 1f);
          
           
        }
    }
   public void locations() {
     if(Input.location.status == LocationServiceStatus.Running){
            //Warn.text = "OK";
        Lat.text = Input.location.lastData.latitude.ToString();
        Long.text = Input.location.lastData.longitude.ToString();
             
    }else{
        Warn.text = "Gps Not Connect!";
    }
   }
