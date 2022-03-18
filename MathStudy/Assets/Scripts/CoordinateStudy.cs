/*
 * Description:             CoordinateStudy.cs
 * Author:                  TONYTANG
 * Create Date:             2022/03/11
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// CoordinateStudy.cs
/// 坐标系学习
/// </summary>
public class CoordinateStudy : MonoBehaviour
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

    private void Start()
    {
        var cube1RelativeCube2Pos = Cube2.transform.InverseTransformPoint(Cube1.transform.position);
        var cube2RelativeCube1Pos = Cube1.transform.InverseTransformPoint(Cube2.transform.position);
        TipTxt.text = $"红色表示Cube1,绿色表示Cube2\n" +
                        $"Cube1世界坐标:{Cube1.transform.position.ToString()} 旋转角度:{Cube1.transform.eulerAngles.ToString()}\n" +
                        $"Cube2世界坐标系:{Cube2.transform.position.ToString()} 旋转角度:{Cube2.transform.eulerAngles.ToString()}\n" +
                        $"Cube1相对Cube2的坐标为:{cube1RelativeCube2Pos.ToString()}\n" +
                        $"Cube2相对Cube1的坐标为:{cube2RelativeCube1Pos.ToString()}";
    }
}