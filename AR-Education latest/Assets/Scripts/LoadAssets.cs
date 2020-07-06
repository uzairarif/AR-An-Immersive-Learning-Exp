using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LoadAssets : MonoBehaviour
{

    public string BundleURL = "http://192.168.10.4/win.unity3d"; // --> http://Myserver/public_http/Assets/AssetBundles/cube_prefab (path to the AssetBundle)
    public string AssetName = "Sphere"; // --> Cube_pref (name of the Asset prefab)
    public int version;
    public GameObject[] targets;
    GameObject x;
    void Start()
    {
        x = GameObject.Find("Cube");
     targets = GameObject.FindGameObjectsWithTag("Target");    
        Debug.Log("hello");
        StartCoroutine(DownloadAndCache());
    }
    IEnumerator DownloadAndCache()
    {
        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        using (WWW www = WWW.LoadFromCacheOrDownload("http://192.168.10.4/win.unity3d", 1))
        {
            Debug.Log("hell");
            yield return www;

            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            AssetBundle bundle = www.assetBundle;
            if (AssetName == "")
                Instantiate(bundle.mainAsset);
            else
            {

                string[] name = bundle.GetAllAssetNames();
                int count =0;
                foreach (var i in name)
                {
                    Debug.Log(i);
                    GameObject gameObject = bundle.LoadAsset(i) as GameObject;
                    GameObject clone =  Instantiate(bundle.LoadAsset(i)) as GameObject;
                    clone.transform.parent = targets[count].transform;
                    count++;
                }


            }
            // Unload the AssetBundles compressed contents to conserve memory
            bundle.Unload(false);
        } // memory is freed from the web stream (www.Dispose() gets called implicitly)
    }
}
