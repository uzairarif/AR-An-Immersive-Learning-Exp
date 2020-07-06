using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class download : MonoBehaviour
{
    public string BundleURL = "http://192.168.10.3/cubebundle.cube"; // --> http://Myserver/public_http/Assets/AssetBundles/cube_prefab (path to the AssetBundle)
    public string AssetName = "Cube"; // --> Cube_pref (name of the Asset prefab)
    public int version;
    void Start()
    {
        StartCoroutine(DownloadAndCache());
    }
    IEnumerator DownloadAndCache()
    {
        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        using (WWW www = WWW.LoadFromCacheOrDownload("http://192.168.10.3/cubebundle.cube", 1))
        {
            yield return www;
            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            AssetBundle bundle = www.assetBundle;
            if (AssetName == "")
                Instantiate(bundle.mainAsset);
            else
            {
                GameObject gameObject = bundle.LoadAsset(AssetName) as GameObject;
                Instantiate(bundle.LoadAsset(AssetName));
            }
            // Unload the AssetBundles compressed contents to conserve memory
            bundle.Unload(false);
        } // memory is freed from the web stream (www.Dispose() gets called implicitly)
    }
}
