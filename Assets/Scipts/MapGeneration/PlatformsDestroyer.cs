using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatformsDestroyer : MonoBehaviour
{
    public float lifeTime = 10f;
    [SerializeField]
    GameObject Platrform;
    // Start is called before the first frame update
    void Start()
    {

        Platrform = GetComponent<GameObject>();
        //var prefabGameObject = PrefabUtility.ApplyRemovedComponent(0, Platrform,);
        //Debug.Log(prefabGameObject.name);
    }


    private void Update()
    {
        if (lifeTime >= 0) 
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0) 
            {
                Destruction();
            }
        }
    }

    private void Destruction()
    {
        //Platrform.GetComponentInChildren();
        //Debug.Log( Platrform.GetInstanceID());
        //Destroy(this.gameObject);
    }


    // Update is called once per frame

}
