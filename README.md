# AR-An-Immersive-Learning-Exp
FYP 2020

## Projects 

This project consists of 2 major projects:

1) MakeBundle -> To make AssetBundles of Models
2) AR-Education latest -> Unity Mobile App

## Project Flow

1) The user must first make AssetBundles for each model that the user wishes to augment on an image Target.
2) The making of AssetBundles can be accomplished using MakeBundle project.
3) After making of AssetBundles, the Assetbundles are to be uploaded to an FTP Server
4) The Unity Mobile App will then download the Assets in the application by sending REST requests to FTP Server.
5) After downloading the assetbundles in local storage they are then utlized by the Unity Mobile App to augment the models on an Image Target

## ToRun

To run both projects download and install Unity 2018.x.xxx and then open the projects using open feature of the Unity.

For the Unity Mobile App,
1) You have to build by going to build settings and select android and click build
2) If a phone is connected via USB Cable, it will appear on the list so the apk wil be build directly on the phone
3) In case the phone isn't connected via USB the apk will be stored on a local storage, the location prompt will ask the user for saving location. Then the user has to transfer the apk to mobile app and manually install the apk.