using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingGunScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    public float maxDistance = 30f;
    private SpringJoint joint;

    public LayerMask whatIsGrappleable;
    public Transform muzzle, camera, player;


    public bool isGrappling, isShooting;
    public ParticleSystem shootFX;
    public AudioSource shootAudio, grappleAudio, reelAudio;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void LateUpdate()
    {
        DrawRope();
    }

    public void OnLeftClick(InputValue value)
    {
        
        isGrappling = value.isPressed;
        if (isGrappling)
            StartGrapple();
        else if (!isGrappling)
            StopGrapple();
        print(isGrappling);
    }

    public void OnRightClick(InputValue value)
    {
        //if(!shootAudio.isPlaying)
            shootAudio.Play();
        isShooting = value.isPressed;
        shootFX.Play();
        print("bang");
    }

    void DrawRope()
    {
        if (!joint) return;
        lineRenderer.SetPosition(0, muzzle.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    void StartGrapple()
    {
        grappleAudio.Play();
        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lineRenderer.positionCount = 2;
            
        }
    }

    void StopGrapple()
    {
        reelAudio.Play();
        lineRenderer.positionCount = 0;
        Destroy(joint);
    }
}
