using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour

{
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0F;

    private float startTime;

    private float journeyLength;

    //private Animator animator;

    void Start()
     {
          startTime = Time.time;

          journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

          //animator = GetComponent<Animator>();
     }

    void Update()
     {
          float distCovered = (Time.time - startTime) * speed;

          float fracJourney = distCovered / journeyLength;

          transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong (fracJourney, 1));
     }
}