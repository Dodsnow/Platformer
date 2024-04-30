using System;
using System.Collections.Generic;
using Enum;
using UnityEngine;


public class SceneObjects : MonoBehaviour
{
 public List<SceneObjects> sceneObjects;

 private void Awake()
 {
  sceneObjects = new List<SceneObjects>();
 }
}
