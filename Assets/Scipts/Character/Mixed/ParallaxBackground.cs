using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMulptiplayer;
    [SerializeField]  private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltamovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltamovement.x * parallaxEffectMulptiplayer.x, deltamovement.y * parallaxEffectMulptiplayer.y);
        lastCameraPosition = cameraTransform.position;

        if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) 
        {
            float offSetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offSetPositionX, transform.position.y);
        }

        //////if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
        //////{
        //////    float offSetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
        //////    transform.position = new Vector3(cameraTransform.position.y + offSetPositionY, transform.position.y);
        //////}
    }
}
