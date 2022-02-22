/*
 * Description:             CrossMath.cs
 * Author:                  TONYTANG
 * Create Date:             2022/02/21
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CrossMath.cs
/// 叉乘学习
/// 叉乘计算两个向是否平行以及两个向量相对位置(顺时针还是逆时针)
/// 叉乘计算在平面几何里是球两个向量构成的平行四边形面积
/// </summary>
[ExecuteInEditMode]
public class CrossMath : MonoBehaviour
{
    /// <summary>
    /// 起点对象1
    /// </summary>
    [Header("起点对象1")]
    public GameObject Start1Go;

    /// <summary>
    /// 终点对象1
    /// </summary>
    [Header("终点对象1")]
    public GameObject End1Go;

    /// <summary>
    /// 起点对象2
    /// </summary>
    [Header("起点对象2")]
    public GameObject Start2Go;

    /// <summary>
    /// 终点对象2
    /// </summary>
    [Header("终点对象2")]
    public GameObject End2Go;
    
    /// <summary>
    /// 两个向量是否是顺时针
    /// </summary>
    [Header("两个向量是否是顺时针")]
    public bool IsClockWise;

    /// <summary>
    /// 两个向量是否平行
    /// </summary>
    [Header("两个向量是否平行")]
    public bool IsParally;

    /// <summary>
    /// 第一根线向量
    /// </summary>
    private Vector3 Line1Vector = Vector3.zero;

    /// <summary>
    /// 第二根线向量
    /// </summary>
    private Vector3 Line2Vector = Vector3.zero;

    private void Update()
    {
        if (Start1Go != null && End1Go != null & Start2Go != null && End2Go != null)
        {
            Line1Vector = End1Go.transform.position - Start1Go.transform.position;
            Line2Vector = End2Go.transform.position - Start2Go.transform.position;
            var dotValue = Vector3.Cross(Line1Vector.normalized, Line2Vector.normalized);
            IsClockWise = dotValue.y >= 0;
            IsParally = Vector3.Equals(dotValue, Vector3.zero);
        }
    }
}