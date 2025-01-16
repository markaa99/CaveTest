using System;
using Scrips.Interaction;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Htw.Cave.Kinect;
using UnityEngine;
//using UnityEngine.Windows.Speech;

public class Teleport : MonoBehaviour
{
    public GameObject Insel1;
    public GameObject Insel2;
    public GameObject Insel3;
    public GameObject Zentrale;
    
    public LayerMask teleportLayers;
    public Scrips.Interaction.KeyWordRecognition recognition;

    private KinectSkeleton kinectSkeleton;

    public KinectTracker kinectTracker;
    private KinectSkeletonJoint shoulderJointRight;
    private KinectSkeletonJoint elbowJointRight;
    private KinectSkeletonJoint wristJointRight;

    private KinectSkeletonJoint wristJointLeft;
    private KinectSkeletonJoint headJoint;

    private LineRenderer lineRenderer;

    private Collider armStraightCollider;
    private Collider leftHandCollider;

    private bool armStraight;

    private Ray ray;
    RaycastHit hit;

    private bool teleportCooldownActive = false;

    private void Start()
    {
        kinectTracker.onCreateActor += OnCreateActorHandler;
        kinectTracker.onDestroyActor += OnDestroyActorHandler;

        if (recognition != null)
        {
            recognition.OnKeywordRecognized += TeleportPlayer;
        }

        ReferenceColliderAndJoints();

        lineRenderer = GetComponent<LineRenderer>();
    }



    private void OnCreateActorHandler(KinectActor kinectActor)
    {
        kinectSkeleton = kinectActor.transform.gameObject.GetComponent<KinectSkeleton>();
        ReferenceColliderAndJoints();
        if (recognition != null)
        {
            recognition.OnKeywordRecognized += TeleportPlayer;
        }
        lineRenderer = GetComponent<LineRenderer>();
        Debug.Log("Actor created " + kinectActor.gameObject.name);

    }

    private void OnDestroyActorHandler(KinectActor kinectActor)
    {
        kinectSkeleton = null;
    }

    private void ReferenceColliderAndJoints()
    {
        if (kinectSkeleton != null)
        {
            shoulderJointRight = kinectSkeleton.GetJoint(Windows.Kinect.JointType.ShoulderRight);
            elbowJointRight = kinectSkeleton.GetJoint(Windows.Kinect.JointType.ElbowRight);
            wristJointRight = kinectSkeleton.GetJoint(Windows.Kinect.JointType.WristRight);
            armStraightCollider = elbowJointRight.GetComponentInChildren<CapsuleCollider>();
            wristJointLeft = kinectSkeleton.GetJoint(Windows.Kinect.JointType.WristLeft);
            leftHandCollider = wristJointLeft.GetComponent<Collider>();
            headJoint = kinectSkeleton.GetJoint(Windows.Kinect.JointType.Head);
        }
    }
        
    
    

    private void TeleportPlayer(UnityEngine.Windows.Speech.PhraseRecognizedEventArgs obj)
    {
        String keyword = obj.text;
        Debug.Log($"Keyword erkannt: {keyword}");

        switch (keyword)
        {
            case "eins":
                kinectTracker.transform.position = Insel1.transform.position;
                break;
            case "zwei":
                transform.position = Insel2.transform.position;
                break;
            case "drei":
                transform.position = Insel3.transform.position;
                break;
            case "exit":
                transform.position = Zentrale.transform.position;
                break;
        }
    }
}