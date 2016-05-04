using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeManager : MonoBehaviour {

    /// <summary>
    /// 生成的数字方块放在此对象下
    /// </summary>
    public GameObject grid;

    /// <summary>
    /// 二位数组，存储每个格子是否有数字
    /// </summary>
    private bool[,] Array = new bool[4,4];
    /// <summary>
    /// 存储每个格子所对应的Cube
    /// key = rank * 10 + col
    /// </summary>
    private Dictionary<int, Cube> cubeList = new Dictionary<int, Cube>();

    /// <summary>
    /// 数字方块回收
    /// </summary>
    private List<Cube> cubePrab = new List<Cube>();

    /// <summary>
    /// 上次移动是否完成
    /// </summary>
    private bool isMove = false;

    /// <summary>
    /// 二维数组的行数
    /// </summary>
    private int rank = 0;
    /// <summary>
    /// 二位数组的列数
    /// </summary>
    private int col = 0;

	// Use this for initialization
	void Start ()
    {
        rank = Array.GetLength(0);
        col = Array.GetLength(1);
        clear();
        test();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isMove) { 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft();
        }

        }

    }

    private void test()
    {
        Cube[] childrens = grid.GetComponentsInChildren<Cube>();
        for(int i = 0; i < childrens.Length; i++)
        {
            Cube cu = childrens[i];
            Array[cu.indexRank, cu.indexCol] = true;
            cubeList.Add(getKey(cu.indexRank, cu.indexCol), cu);
        }

    }

    /// <summary>
    ///清除数据
    /// </summary>
    private void clear()
    {
        for(int i = 0; i < rank; i++)
        {
            for (int j = 0; j <col; j++)
            {
                Array[i, j] = false;
            }
        }

        cubeList.Clear();
    }

    /// <summary>
    /// 所有数字向左移动
    /// </summary>
    private void moveLeft()
    {
        for(int i = 1; i < col; i++)//列
        {
            for(int j = 0; j < rank; j++)//行
            {
                int currkey = getKey(j, i);
                bool mul = false;
                int left = 0;
                if (Array[j, i] && cubeList.ContainsKey(currkey))//当前格子有数字
                {
                    for (int index = i - 1; index >= 0; index--)
                    {
                        int lastkey = getKey(j, index);

                        if (Array[j, index] && cubeList.ContainsKey(lastkey))//如果前方格子存在数字
                        {                            
                            if (cubeList[lastkey].currNum == cubeList[currkey].currNum)//当前数字与移动方向前方数字相同，则进行合并
                            {
                                mul = true;
                                left++;
                            }
                            break;
                        }
                        else
                        {
                            left++;
                        }
                    }

                    if (mul)
                    {
                        int lastkey = getKey(j, i - left);
                        cubeList[lastkey].setText(cubeList[lastkey].currNum + cubeList[currkey].currNum);
                        Array[j, i] = false;
                        rescroll(currkey);
                        
                    }
                    else if (left > 0)
                    {
                        int lastkey = getKey(j, i - left);
                        cubeList[currkey].moveUp(-1 * left, 0);
                        Array[j, i - left] = true;
                        Array[j, i] = false;
                        cubeList.Remove(lastkey);
                        cubeList.Add(lastkey, cubeList[currkey]);
                        cubeList.Remove(currkey);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 根据下标获得key
    /// </summary>
    /// <param name="x">行</param>
    /// <param name="y">列</param>
    /// <returns></returns>
    private int getKey(int x, int y)
    {
        return x * 10 + y;
    }

    /// <summary>
    /// 回收预设
    /// </summary>
    /// <param name="currkey"></param>
    private void rescroll(int currkey)
    {
        Cube cu = cubeList[currkey];
        cu.gameObject.SetActive(false);
        cu.init();
        cubePrab.Add(cu);
        cubeList.Remove(currkey);
    }
    
    /// <summary>
    /// 获得0-3内的随机数
    /// </summary>
    /// <returns></returns>
    private int getRandom()
    {
        return Random.Range(0, 3);
    }
}
