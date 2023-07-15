using System.Collections;
using System.Collections.Generic;
using Wave.Essence;
using UnityEngine;
using Mirror;
using Wave.Essence.Interaction.Mode;
using Wave.Essence.ScenePerception.Sample;
using Wave.Native;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private GameObject _cam;
    [SerializeField]
    private GameObject _leftController;
    [SerializeField]
    private GameObject _rightController;
    [SerializeField]
    private WaveRig _waveRig;
    //[SerializeField]
    //private RaycastHit _leftControllerRaycastHitInfo = new RaycastHit(), _rightControllerRaycastHitInfo = new RaycastHit();
    //[SerializeField]
    //private GameObject _track = null;
    //[SerializeField] private GameObject _trackPrefab, _trackDisplayPrrefab;
    [SerializeField]
    private GameObject _anchorDisplayRight = null;
    //[SerializeField] private ScenePerceptionHelper _scenePerceptionHelper;
    //[SerializeField]
    //private SpatialAnchorHelper _spacialAnchorHelper;
    //[SerializeField]
    //private ScenePerceptionMeshFacade _scenePerceptionMeshFacade;
    //[SerializeField] private Material _generatedMeshMaterialTranslucent, _generatedMeshMaterialWireframe;
    //[SerializeField]
    //private bool _hideMeshAndAnchors = false;
    [SerializeField]
    private InteractionModeManager _interactionModeManager;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            _interactionModeManager.enabled = true;
            _cam.SetActive(true);
            _leftController.SetActive(true);
            _rightController.SetActive(true);

            //if (_scenePerceptionHelper == null)
            //{
            //    _scenePerceptionHelper = new ScenePerceptionHelper();
            //}

            //if (_scenePerceptionHelper != null)
            //{
            //    _scenePerceptionHelper.scenePerceptionManager.gameObject.SetActive(true);
            //    _scenePerceptionHelper.OnEnable();
            //}

            //_spacialAnchorHelper = new SpatialAnchorHelper(_scenePerceptionHelper.scenePerceptionManager, _trackPrefab);
            //if (_scenePerceptionHelper.isSceneComponentRunning)
            //{
            //    _spacialAnchorHelper.SetAnchorsShouldBeUpdated();
            //}
            //_scenePerceptionMeshFacade = new ScenePerceptionMeshFacade(_scenePerceptionHelper, _trackDisplayPrrefab, _generatedMeshMaterialTranslucent, _generatedMeshMaterialWireframe);
        }
        else
        {
            _waveRig.enabled = false;
        }
    }

    public GameObject GetLeftController() { return _leftController; }
    public GameObject GetRightController() { return _rightController; }
    public GameObject GetAnchorDisplayRight() { return _anchorDisplayRight; }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {

            //if (_scenePerceptionHelper.isSceneComponentRunning && !_hideMeshAndAnchors)
            //{
            //    //Handle Scene Perception
            //    if (!_scenePerceptionHelper.isScenePerceptionStarted)
            //    {
            //        _scenePerceptionHelper.StartScenePerception();
            //    }
            //    else
            //    {
            //        _scenePerceptionHelper.ScenePerceptionGetState(); //Update state of scene perception every frame
            //        _scenePerceptionMeshFacade.UpdateScenePerceptionMesh();
            //    }

            //    //Handle Spatial Anchor
            //    _spacialAnchorHelper.UpdateAnchorDictionary();
            //}

            //if (_scenePerceptionHelper.isSceneComponentRunning)
            //{
            //    if (ButtonFacade.XButtonPressed)
            //    {
            //        _spacialAnchorHelper.HandleAnchorUpdateDestroy(_leftControllerRaycastHitInfo);
            //    }
            //    if (ButtonFacade.AButtonPressed)
            //    {
            //        _spacialAnchorHelper.HandleAnchorUpdateCreate(_rightControllerRaycastHitInfo, _rightController.transform.rotation);
            //    }
            //}

        }


    }
    private void OnDestroy()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //if (_scenePerceptionHelper != null)
        //{
        //    _scenePerceptionHelper.OnDisable();
        //}
    }
    private void FixedUpdate()
    {
        //if (isLocalPlayer)
        //{

        //    Physics.Raycast(_leftController.transform.position, _leftController.transform.forward, out _leftControllerRaycastHitInfo);

        //    Physics.Raycast(_rightController.transform.position, _rightController.transform.forward, out _rightControllerRaycastHitInfo);

        //    if (_rightControllerRaycastHitInfo.collider != null && _rightControllerRaycastHitInfo.collider.transform.GetComponent<AnchorPrefab>() == null) //Not hitting an anchor
        //    {
        //        _anchorDisplayRight.gameObject.SetActive(true);
        //        _anchorDisplayRight.transform.SetPositionAndRotation(_rightControllerRaycastHitInfo.point, _rightController.transform.rotation);
        //    }
        //    else
        //    {
        //        _anchorDisplayRight.gameObject.SetActive(false);
        //    }
        //}
    }

}
