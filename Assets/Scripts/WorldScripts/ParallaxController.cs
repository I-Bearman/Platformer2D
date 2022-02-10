using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layerTrans;
    [SerializeField] private float[] coeff;

    private int layerCount;
    private Vector3 pos;

    void Start()
    {
        layerCount = layerTrans.Length;
    }

    void Update()
    {
        for(int i = 0; i < layerCount; i++)
        {
            pos = layerTrans[i].position;
            pos.x = transform.position.x * coeff[i];
            layerTrans[i].position = pos;
        }
    }
}
