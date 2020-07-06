using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Status : MonoBehaviour
{

    public string url;
    string basePath;
    public static string baseUrl;
    public static string BundleName;
    private void Start()
    {
        baseUrl = url;
        GameObject[] status = GameObject.FindGameObjectsWithTag("Status");
        basePath = Application.persistentDataPath;
        Debug.Log(basePath);
        for (int i = 0; i < status.Length; i++)
        {
            string name = status[i].name;
            string savePath = basePath + "/" + name + ".unity3d";
            if (File.Exists(savePath))
            {
                status[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                status[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("PackageName");
        foreach (var button in buttons)
        {
            button.GetComponent<Button>().onClick.AddListener(delegate { PackageName(button.name); });
        }
    }

    void PackageName(string packageName)
    {
        // SceneManager.LoadScene(1);
        String path = this.basePath + "/" + packageName + ".unity3d";
        if (File.Exists(path))
        {
            Debug.Log("It exists");
            BundleName = path;
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.Log("It does not  exists");
        }
    }

    public void download(string name){
        StartCoroutine(DownloadAndCache(name));
        GameObject temp = GameObject.Find(name+"D");
        temp.transform.GetChild(0).gameObject.SetActive(false);
        temp.transform.GetChild(1).gameObject.SetActive(true);
    }
    public void class1()
    {
        download("1");
    }
    public void class2()
    {
        download("2");
    }
    public void class3()
    {
        download("3");
    }
    public void class4()
    {
        download("4");
    }
    public void class5()
    {
        download("5");
    }

public void English()
    {
        download("English");
    }
    public void Astronomy()
    {
        download("Astronomy");
    }
    public void History()
    {
        download("History");
    }
    public void Science()
    {
        download("Science");
    }
    public void Math()
    {
        download("Math");
    }
    private void TestDownload(string name)
    {
        url = "http://192.168.10.6/1.unity3d";
        Debug.Log(url);

        WWW www = new WWW(url);
        //yield return www;

        while (!www.isDone)
        {

            //Debug.Log(www.progress);
            //yield return null;
        }
        if (www.progress == 0)
        {
            string savePath = Application.persistentDataPath + "/" + name;
            Debug.Log("Path is " + savePath);
            byte[] bytes = www.bytes;

            File.WriteAllBytes(savePath, bytes);
        }
        else
        {
            Debug.Log("Not working");
        }
    }
    IEnumerator DownloadAndCache(string name)
    {
        string url = this.url +"/"+name+".unity3d";
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string savePath = Application.persistentDataPath + "/"+name+".unity3d";
                System.IO.File.WriteAllBytes(savePath, www.downloadHandler.data);
            }
        }
        
    }
}