using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteInEditMode] 
public class ObjectGenerator : MonoBehaviour
{
    // 在 Unity 编辑器中指定的要生成的物体
    public GameObject objectPrefab;
    // 生成的方块数量
    public int numberOfObjectsPerRow = 15;
    // 生成的行数
    public int numberOfRows = 15;
    // 方块之间的间隔
    public float spacing = 5f;

    private Vector3[] vector3s = new Vector3[4] {new Vector3(0,0,0),
    new Vector3(0,90,0),new Vector3(0,180,0),new Vector3(0,270,0)};

    void Start()
    {
        //objectPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //objectPrefab.transform.localScale = new Vector3(4, 1, 4);
        // 生成方块
        GenerateObjects();
    }

    void GenerateObjects()
    {
        //// 确保指定了要生成的物体
        //if (objectPrefab != null)
        //{
        //    // 生成指定数量的方块
        //    for (int row = 0; row < numberOfRows; row++)
        //    {
        //        for (int col = 0; col < numberOfObjectsPerRow; col++)
        //        {
        //            // 计算方块的位置
        //            Vector3 position = new Vector3(col * spacing, 0f, row * spacing);
        //            // 生成方块
        //            Instantiate(objectPrefab, position, Quaternion.identity);
        //        }
        //    }
        //}
        //else
        //{
        //    Debug.LogError("请指定要生成的物体Prefab！");
        //}
        if (objectPrefab != null)
        {
            int num = this.transform.childCount;
            // 生成指定数量的方块
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
            Debug.LogError("请指定要生成的物体Prefab！");
        }

    }
}