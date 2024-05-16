using UnityEngine;

public class ConeRaysVisualizer : MonoBehaviour
{
    public int raysCount = 100; // Բ׶���������ߵ�����
    public float coneHeight = 5.0f; // Բ׶�ĸ߶ȣ�Ҳ�������ߵĳ���
    public float coneAngle = 45.0f; // Բ׶�Ŀ��ڽǶ�
    public float rotationSpeed = 30.0f; // �� X ����ת���ٶ�
    private void Start()
    {
        
    }
    private void Update()
    {
        float radius = coneHeight * Mathf.Tan(coneAngle * Mathf.Deg2Rad / 2); // ����Բ׶����İ뾶
        float rotationAngle = Time.time * rotationSpeed; // ������ת�Ƕȣ�����ʹ��ʱ�������ת�ٶ�
        print(rotationAngle);
        for (int i = 0; i < raysCount; i++)
        {
            float angle = i * 2 * Mathf.PI / raysCount + rotationAngle; // ���㵱ǰ������ X ��ļнǣ���������ת�Ƕ�
            Vector3 direction = transform.TransformDirection(new Vector3(coneHeight, Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius));
            Debug.DrawRay(gameObject.transform.position, direction, Color.red); // ��ԭ�㷢������
        }
    }
}