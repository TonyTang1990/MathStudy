/*
 * Description:             VectorUsingStudy.cs
 * Author:                  TONYTANG
 * Create Date:             2022/03/17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// VectorUsingStudy.cs
/// 向量点乘和叉乘实战学习
/// </summary>
public class VectorUsingStudy : MonoBehaviour
{
    /// <summary>
    /// 提示文本
    /// </summary>
    [Header("提示文本")]
    public Text TipTxt;

    /// <summary>
    /// 旋转按钮
    /// </summary>
    [Header("旋转按钮")]
    public Button RotateBtn;

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

    /// <summary>
    /// 旋转角度
    /// </summary>
    private float mAngle;

    /// <summary>
    /// 旋转轴
    /// </summary>
    private Vector3 mRotateAxis;

    private void Start()
    {
        RotateBtn.onClick.AddListener(OnRotateBtnClick);
        var cube1Forward = Cube1.transform.forward;
        var cube1ToCube2 = Cube2.transform.position - Cube1.transform.position;
        var vectorDot = Vector3.Dot(cube1Forward, cube1ToCube2);
        var radians = Mathf.Acos(vectorDot / (cube1Forward.magnitude * cube1ToCube2.magnitude));
        mAngle = Mathf.Rad2Deg * radians;
        mRotateAxis = Vector3.Cross(cube1Forward, cube1ToCube2);
        var rotationDirection = mRotateAxis.y > 0 ? "顺时针" : "逆时针";
        TipTxt.text = $"红色表示Cube1,绿色表示Cube2\n" +
                        $"Cube1世界坐标:{Cube1.transform.position.ToString()} 朝向:{Cube1.transform.forward.ToString()}\n" +
                        $"Cube2世界坐标系:{Cube2.transform.position.ToString()} 朝向:{Cube2.transform.forward.ToString()}\n" +
                        $"Cube1朝向:{cube1Forward.ToString()}\n" +
                        $"Cube1到Cube2向量:{cube1ToCube2.ToString()}\n" +
                        $"Cube1朝向 点乘 Cube1到Cube2向量 = {vectorDot}\n" +
                        $"Cube1朝向 叉乘 Cube1到Cube2向量 = {mRotateAxis.ToString()}\n" +
                        $"Cube1看向Cube2旋转方向:{rotationDirection}\n" +
                        $"Cube1看向Cube2旋转角度:{mAngle}";
    }

    /// <summary>
    /// 点击旋转Cube1看向Cube2
    /// </summary>
    public void OnRotateBtnClick()
    {
        Cube1.transform.Rotate(mRotateAxis, mAngle);
        Debug.Log($"Cube1看向Cube2旋转方向:{mRotateAxis} 旋转角度:{mAngle}");
    }
}