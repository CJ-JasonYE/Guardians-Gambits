using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteInEditMode] 
public class ObjectGenerator : MonoBehaviour
{
    // �� Unity �༭����ָ����Ҫ���ɵ�����
    public GameObject objectPrefab;
    // ���ɵķ�������
    public int numberOfObjectsPerRow = 15;
    // ���ɵ�����
    public int numberOfRows = 15;
    // ����֮��ļ��
    public float spacing = 5f;

    private Vector3[] vector3s = new Vector3[4] {new Vector3(0,0,0),
    new Vector3(0,90,0),new Vector3(0,180,0),new Vector3(0,270,0)};

    void Start()
    {
        //objectPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //objectPrefab.transform.localScale = new Vector3(4, 1, 4);
        // ���ɷ���
        GenerateObjects();
    }

    void GenerateObjects()
    {
        //// ȷ��ָ����Ҫ���ɵ�����
        //if (objectPrefab != null)
        //{
        //    // ����ָ�������ķ���
        //    for (int row = 0; row < numberOfRows; row++)
        //    {
        //        for (int col = 0; col < numberOfObjectsPerRow; col++)
        //        {
        //            // ���㷽���λ��
        //            Vector3 position = new Vector3(col * spacing, 0f, row * spacing);
        //            // ���ɷ���
        //            Instantiate(objectPrefab, position, Quaternion.identity);
        //        }
        //    }
        //}
        //else
        //{
        //    Debug.LogError("��ָ��Ҫ���ɵ�����Prefab��");
        //}
        if (objectPrefab != null)
        {
            int num = this.transform.childCount;
            // ����ָ�������ķ���
            for (int i = 0; i < num; i++)
            {
                DestroyImmediate(transform.GetChild(i).GetChild(0).gameObject);
                int ran = Random.Range(0, 4);
                GameObject t = Instantiate(objectPrefab, transform.GetChild(i), false);
                t.transform.transform.localPosition = new Vector3(0, 0.5f, 0);
                t.transform.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                t.transform.localRotation = Quaternion.Euler(vector3s[ran]);
                //t.transform.GetChild(0).GetChild(0).AddComponent<MeshCollider>();
            }
        }
        else
        {
            Debug.LogError("��ָ��Ҫ���ɵ�����Prefab��");
        }

    }
}