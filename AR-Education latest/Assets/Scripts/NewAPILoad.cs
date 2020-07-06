using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NewAPILoad : MonoBehaviour
{

    public string BundleURL;
    public string AssetName = "Sphere";
    GameObject[] targetTemp;
    GameObject[] targets;
    void Start()
    {
        Debug.Log("Name is " + Status.BundleName);
        BundleURL = Status.BundleName;
        targetTemp = GameObject.FindGameObjectsWithTag("Target");
        targets = new GameObject[targetTemp.Length];
        for(int i=0; i< targetTemp.Length;i++){
            var tt = targetTemp[i].name;
            int g = Int16.Parse(tt);
            targets[g-1] = targetTemp[i]; 
        }
        foreach (var tar in targets)
        {
            Debug.Log(tar.name);
        }
        StartCoroutine(DownloadAndCache());
    }
    IEnumerator DownloadAndCache()
    {
        UnityWebRequest www = UnityWebRequest.GetAssetBundle(BundleURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            if (AssetName == "")
                Instantiate(bundle.mainAsset);
            else
            {

                string[] name = bundle.GetAllAssetNames();
                int count = 0;
                foreach (var i in name)
                {
                    // Debug.Log(i);
                    GameObject gameObject = bundle.LoadAsset(name[count]) as GameObject;
                    GameObject clone = Instantiate(bundle.LoadAsset(name[count])) as GameObject;
                    clone.transform.position = new Vector3(0, .2f, 0);
                    clone.transform.parent = targets[count].transform;
                    // clone.
                    count++;
                }
            }

        }
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
