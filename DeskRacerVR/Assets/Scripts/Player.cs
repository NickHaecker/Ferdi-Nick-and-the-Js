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
    private RaycastHit _leftControllerRaycastHitInfo = new RaycastHit(), _rightControllerRaycastHitInfo = new RaycastHit();
    [SerializeField]
    private GameObject _track = null;
    [SerializeField] private GameObject _trackPrefab, _trackDisplayPrrefab;
    [SerializeField]
    private GameObject _anchorDisplayRight = null;
    [SerializeField] private ScenePerceptionHelper _scenePerceptionHelper;
    [SerializeField]
    private SpatialAnchorHelper _spacialAnchorHelper;
    [SerializeField]
    private ScenePerceptionMeshFacade _scenePerceptionMeshFacade;
    [SerializeField] private Material _generatedMeshMaterialTranslucent, _generatedMeshMaterialWireframe;
    [SerializeField]
    private bool _hideMeshAndAnchors = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            _cam.SetActive(true);
            _leftController.SetActive(true);
            _rightController.SetActive(true);
            GetComponent<InteractionModeManager>().enabled = true;

            if (_scenePerceptionHelper == null)
            {
                _scenePerceptionHelper = new ScenePerceptionHelper();
            }

            if (_scenePerceptionHelper != null)
            {
                _scenePerceptionHelper.OnEnable();
            }

            _spacialAnchorHelper = new SpatialAnchorHelper(_scenePerceptionHelper.scenePerceptionManager, _trackPrefab);
            if (_scenePerceptionHelper.isSceneComponentRunning)
            {
                _spacialAnchorHelper.SetAnchorsShouldBeUpdated();
            }
            _scenePerceptionMeshFacade = new ScenePerceptionMeshFacade(_scenePerceptionHelper, _trackDisplayPrrefab, _generatedMeshMaterialTranslucent, _generatedMeshMaterialWireframe);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            //transform.position = _cam.transform.position;
            //transform.rotation = _cam.transform.rotation;

            if (_scenePerceptionHelper.isSceneComponentRunning && !_hideMeshAndAnchors)
            {
                //Handle Scene Perception
                if (!_scenePerceptionHelper.isScenePerceptionStarted)
                {
                    _scenePerceptionHelper.StartScenePerception();
                }
                else
                {
                    _scenePerceptionHelper.ScenePerceptionGetState(); //Update state of scene perception every frame
                    _scenePerceptionMeshFacade.UpdateScenePerceptionMesh();
                }

                //Handle Spatial Anchor
                _spacialAnchorHelper.UpdateAnchorDictionary();
            }

            if (_scenePerceptionHelper.isSceneComponentRunning)
            {
                if (ButtonFacade.XButtonPressed)
                {
                    _spacialAnchorHelper.HandleAnchorUpdateDestroy(_leftControllerRaycastHitInfo);
                }
                if (ButtonFacade.AButtonPressed)
                {
                    _spacialAnchorHelper.HandleAnchorUpdateCreate(_rightControllerRaycastHitInfo, _rightController.transform.rotation);
                }
            }

        }


    }
    private void OnDestroy()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (_scenePerceptionHelper != null)
        {
            _scenePerceptionHelper.OnDisable();
        }
    }
    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            if (_track == null)
            {
                _track = UnityEngine.GameObject.Instantiate(_trackDisplayPrrefab);
            }

            Physics.Raycast(_leftController.transform.position, _leftController.transform.forward, out _leftControllerRaycastHitInfo);

            Physics.Raycast(_rightController.transform.position, _rightController.transform.forward, out _rightControllerRaycastHitInfo);

            if (_rightControllerRaycastHitInfo.collider != null && _rightControllerRaycastHitInfo.collider.transform.GetComponent<AnchorPrefab>() == null) //Not hitting an anchor
            {
                _anchorDisplayRight.gameObject.SetActive(true);
                _anchorDisplayRight.transform.SetPositionAndRotation(_rightControllerRaycastHitInfo.point, _rightController.transform.rotation);
            }
            else
            {
                _anchorDisplayRight.gameObject.SetActive(false);
            }
        }
    }
    private static class ButtonFacade
    {
        public static bool AButtonPressed =>
            WXRDevice.ButtonPress(WVR_DeviceType.WVR_DeviceType_Controller_Right, WVR_InputId.WVR_InputId_Alias1_A);
        public static bool BButtonPressed =>
            WXRDevice.ButtonPress(WVR_DeviceType.WVR_DeviceType_Controller_Right, WVR_InputId.WVR_InputId_Alias1_B);
        public static bool XButtonPressed =>
            WXRDevice.ButtonPress(WVR_DeviceType.WVR_DeviceType_Controller_Left, WVR_InputId.WVR_InputId_Alias1_X);
        public static bool YButtonPressed =>
            WXRDevice.ButtonPress(WVR_DeviceType.WVR_DeviceType_Controller_Left, WVR_InputId.WVR_InputId_Alias1_Y);
    }
}
