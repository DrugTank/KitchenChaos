using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Player player;
    
    private Animator animator;

    private int IsWalking = Animator.StringToHash("IsWalking");

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        animator.SetBool(IsWalking, player.IsWalking);
    }
}
