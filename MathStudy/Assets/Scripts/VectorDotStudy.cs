/*
 * Description:             VectorDotStudy.cs
 * Author:                  TONYTANG
 * Create Date:             2022/03/17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// VectorDotStudy.cs
/// 向量点乘学习
/// </summary>
public class VectorDotStudy : MonoBehaviour
{
    /// <summary>
    /// 提示文本
    /// </summary>
    [Header("提示文本")]
    public Text TipTxt;

    /// <summary>
    /// Cube1
    /// </summary>
    [Header("Cube1")]
    public GameObject Cube1;

    /// <summary>
    /// Cube2
    /// </summary>
    [Header("Cube2")]
    public GameObject Cube2;

    /// <summary>
    /// Cube3
    /// </summary>
    [Header("Cube2")]
    public GameObject Cube3;

    /// <summary>
    /// 坐标系长度
    /// </summary>
    [Header("坐标系长度")]
    public float CoordinateSystemLength = 1.0f;

    /// <summary>
    /// Z轴颜色
    /// </summary>
    [Header("Z轴颜色")]
    public Color ForwardAxisColor = Color.blue;

    /// <summary>
    /// X轴颜色
    /// </summary>
    [Header("X轴颜色")]
    public Color RightAxisColor = Color.red;

    /// <summary>
    /// Y轴颜色
    /// </summary>
    [Header("Y轴颜色")]
    public Color UpAxisColor = Color.green;

    /// <summary>
    /// 向量颜色
    /// </summary>
    [Header("向量颜色")]
    public Color VectorColor = Color.yellow;

    private void Start()
    {
        var cube1ToCube2Vector = Cube2.transform.position - Cube1.transform.position;
        var cube1ToCube3Vector = Cube3.transform.position - Cube1.transform.position;
        var vectorDot = Vector3.Dot(cube1ToCube2Vector, cube1ToCube3Vector);
        var angle = Mathf.Acos(vectorDot);
        TipTxt.text = $"红色表示Cube1,绿色表示Cube2,蓝色表示Cube3\n" +
                        $"Cube1世界坐标:{Cube1.transform.position.ToString()} 朝向:{Cube1.transform.forward.ToString()}\n" +
                        $"Cube2世界坐标系:{Cube2.transform.position.ToString()} 朝向:{Cube2.transform.forward.ToString()}\n" +
                        $"Cube3世界坐标系:{Cube3.transform.position.ToString()} 朝向:{Cube3.transform.forward.ToString()}\n" +
                        $"Cube1到Cube2的向量:{cube1ToCube2Vector.ToString()}\n" +
                        $"Cube1到Cube3的向量:{cube1ToCube3Vector.magnitude}\n" +
                        $"1->2 点乘 2->3 = {vectorDot}\n" +
                        "1->2和2->3的夹角:{angle}";
    }
}