using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public GameObject Personagem;
   void Update(){
       float x = Personagem.transform.position.x;
       float y = Personagem.transform.position.y;
       float z = Personagem.transform.position.z - 10.0f;
       transform.position = new Vector3(x, y, z);
   }
}
