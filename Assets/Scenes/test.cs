using UnityEngine;

public class ConeRaysVisualizer : MonoBehaviour
{
    public int raysCount = 100; // 圆锥底面上射线的数量
    public float coneHeight = 5.0f; // 圆锥的高度，也就是射线的长度
    public float coneAngle = 45.0f; // 圆锥的开口角度
    public float rotationSpeed = 30.0f; // 绕 X 轴旋转的速度
    private void Start()
    {
        
    }
    private void Update()
    {
        float radius = coneHeight * Mathf.Tan(coneAngle * Mathf.Deg2Rad / 2); // 计算圆锥底面的半径
        float rotationAngle = Time.time * rotationSpeed; // 计算旋转角度，这里使用时间乘以旋转速度
        print(rotationAngle);
        for (int i = 0; i < raysCount; i++)
        {
            float angle = i * 2 * Mathf.PI / raysCount + rotationAngle; // 计算当前射线与 X 轴的夹角，并加上旋转角度
            Vector3 direction = transform.TransformDirection(new Vector3(coneHeight, Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius));
            Debug.DrawRay(gameObject.transform.position, direction, Color.red); // 从原点发射射线
        }
    }
}