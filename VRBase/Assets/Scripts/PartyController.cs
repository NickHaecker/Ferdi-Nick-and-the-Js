using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PartyController : MiniGameController
{
    [SerializeField]
    private List<DanceHitBox> _hits = new List<DanceHitBox>();
    [SerializeField]
    private List<GameObject> _positions = new List<GameObject>();
    [SerializeField]
    private Queue<GameObject> _movementPositions = new Queue<GameObject>();
    [SerializeField]
    private Queue<DanceHitBox> _hitboxes = new Queue<DanceHitBox>();
    [SerializeField]
    private ObjectMover _objectMover;
    [SerializeField]
    private float _offset = 2f;
    [SerializeField]
    private GameObject _trophy;

    protected override void OnSceneCloser()
    {
        Player.Instance.DeactivateHands();
    }
    protected override void OnSceneStarter()
    {

        Player.Instance.ActivateHands();

        StartCoroutine(HitBoxLoop());
    }

    IEnumerator HitBoxLoop()
    {
        if (_hitboxes.Count == 0)
        {
            StopAllCoroutines();

            FinishMinigame();

            yield break;
        }

        yield return new WaitForSeconds(_offset);

        DanceHitBox danceHitBoxdanceHitBox = _hitboxes.Dequeue();

        danceHitBoxdanceHitBox.Activate();
        if (_offset > 0.7) _offset -= 0.1f;
        StartCoroutine(HitBoxLoop());
    }

    protected override void OnStart()
    {
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Party/Intro");
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().Play();
        XRGrabInteractable xRGrabInteractable = _trophy.GetComponent<XRGrabInteractable>();

        xRGrabInteractable.interactionManager = Player.Instance.GetInteractionManager();

        Player.Instance.AddListener(OnHandHitListener);

        foreach (DanceHitBox obj in _hits)
        {
            _hitboxes.Enqueue(obj);
        }

        foreach (GameObject obj in _positions)
        {
            _movementPositions.Enqueue(obj);
        }
    }

    protected override void OnStop()
    {
        Player.Instance.RemoveListener(OnHandHitListener);
    }

    protected override void OnUpdate()
    {

    }

    private void FinishMinigame()
    {
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Audio/Party/ThanksForPlaying");
        GameObject.Find("ElevatorControllerGameJam").GetComponent<AudioSource>().Play();
        StartCoroutine(EndOffset());
    }

    IEnumerator EndOffset()
    {
        yield return new WaitForSeconds(60f);

        EndScene();
    }

    private void OnHandHitListener(Hitable hitable)
    {
        _objectMover.TakeTarget(_movementPositions.Dequeue());

        hitable.Remove();
    }
}
