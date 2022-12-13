using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using V_AnimationSystem;
using System.Reflection;

public class GameAssets : MonoBehaviour
{
    public Transform pfDamagePopup;

    private static GameAssets _i;

    public static GameAssets i {
        get {
            if(_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    void Start(){
        //pfDamagePopup = Resources.Load("pfDamagePopup") as Transform;
        //GameObject pfDamagePopup_ = Instantiate(Resources.Load("pfDamagePopup", typeof(Transform))) as GameObject;
    }

}
