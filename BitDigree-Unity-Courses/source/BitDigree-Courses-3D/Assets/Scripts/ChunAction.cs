using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunAction : MonoBehaviour
{

  Animator anim;

  void Start()
  {
    anim = GetComponent<Animator>();
  }

  public void jump() {
    anim.SetTrigger("Hit");
  }
}
