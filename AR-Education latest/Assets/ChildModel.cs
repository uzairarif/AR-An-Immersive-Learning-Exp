using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChildModel : MonoBehaviour
{
    string BundleURL;
    public string AssetName;
    public GameObject target;
    void Start()
    {
		AssetName = SelectModel.ModelName;
        // BundleURL = NewAPILoad.BundleURL;
        BundleURL = Status.baseUrl + "/list.unity3d";
        // target = GameObject.FindGameObjectsWithTag("Target");
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
                // foreach (var i in name)
                // {
                // Debug.Log(i);
                GameObject gameObject = bundle.LoadAsset(name[0]) as GameObject;
                GameObject clone = Instantiate(bundle.LoadAsset(name[0])) as GameObject;
                clone.transform.position = new Vector3(0, .2f, 0);
                clone.transform.parent = this.transform;
                // clone.
                // count++;
                // }
            }

        }
    }
}
