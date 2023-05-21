using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class QRCodeTracker : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField]
    private ARTrackedImageManager _imageManager;
    [SerializeField]
    private GroundController _groundController;

    void Start()
    {
        _imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        _imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            Debug.Log(trackedImage.referenceImage.name);
            if (trackedImage.referenceImage.name == "DeskRacer") // QR-Code-Name überprüfen
            {
                // Spawnen des GameObjects an der Position des erkannten QR-Codes
                GameObject spawnedObject = Instantiate(_prefab, trackedImage.transform.position, _prefab.transform.rotation, _groundController.transform);
                Debug.Log(spawnedObject.name);



                // Optional: Füge weitere Logik oder Komponenten zum gespawnten GameObject hinzu
            }
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            Debug.Log("updated");
            Debug.Log(trackedImage.referenceImage.name);
            //_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
            //SetRoot(trackedImage.transform);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            Debug.Log("removed");
            Debug.Log(trackedImage.referenceImage.name);
            //Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            //_instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
        }
    }
    //private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    //{
    //    if (!isLocalPlayer) return;

    //    foreach (var trackedImage in eventArgs.added)
    //    {
    //        var imageName = trackedImage.referenceImage.name;

    //        foreach (var curPrefab in Prefabs)
    //        {
    //            if (string.Compare(curPrefab.name, imageName, StringComparison.Ordinal) == 0
    //                && !_instantiatedPrefabs.ContainsKey(imageName))
    //            {
    //                var newPrefab = Instantiate(curPrefab, trackedImage.transform);
    //                _instantiatedPrefabs[imageName] = newPrefab;
    //            }
    //        }
    //        SetRoot(trackedImage.transform);
    //    }

    //    foreach (var trackedImage in eventArgs.updated)
    //    {
    //        _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
    //        SetRoot(trackedImage.transform);
    //    }
    //    foreach (var trackedImage in eventArgs.removed)
    //    {
    //        Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
    //        _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
    //    }
    //}

}
