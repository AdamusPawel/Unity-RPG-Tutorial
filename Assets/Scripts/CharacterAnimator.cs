﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    private const float locomotionAnimationSmoothTime = .1f;
    private Animator animator;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start ()
	{
	    agent = GetComponent<NavMeshAgent>();
	    animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float speedPercent = agent.velocity.magnitude / agent.speed;
	    animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
	}
}
