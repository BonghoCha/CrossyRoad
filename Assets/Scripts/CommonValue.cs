using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonValue : MonoBehaviour
{
    public static Vector3 PlayerPressedScale = new Vector3(1f, 0.8f, 1f);
    public static Vector3 PlayerOriginalScale = new Vector3(1f, 1f, 1f);
    
    public static Vector3 PlayerFrontBackVector = new Vector3(0, 0, 1);
    public static Vector3 PlayerLeftRightVector = new Vector3(1, 0, 0);

    public static Quaternion PlayerFrontRotation = Quaternion.Euler(Vector3.zero);
    public static Quaternion PlayerBackRotation = Quaternion.Euler(new Vector3(0, 180, 0));
    public static Quaternion PlayerLeftRotation = Quaternion.Euler(new Vector3(0, -90, 0));
    public static Quaternion PlayerRightRotation = Quaternion.Euler(new Vector3(0, 90, 0));
}
