/*
 * Description:             VectorUsingStudyEditor.cs
 * Author:                  TONYTANG
 * Create Date:             2022/03/17
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// VectorUsingStudyEditor.cs
/// VectorUsingStudy的Editor绘制
/// </summary>
[CustomEditor(typeof(VectorUsingStudy))]
public class VectorUsingStudyEditor : Editor
{
    /// <summary>
    /// Cube1属性
    /// </summary>
    SerializedProperty mCube1Property;

    /// <summary>
    /// Cube2属性
    /// </summary>
    SerializedProperty mCube2Property;

    /// <summary>
    /// Cube3属性
    /// </summary>
    SerializedProperty mCube3Property;

    /// <summary>
    /// 坐标系长度属性
    /// </summary>
    SerializedProperty mCoordinateSystemLengthProperty;

    /// <summary>
    /// Z轴颜色属性
    /// </summary>
    SerializedProperty mForwardAxisColorProperty;

    /// <summary>
    /// X轴颜色属性
    /// </summary>
    SerializedProperty mRightAxisColorProperty;

    /// <summary>
    /// Y轴颜色
    /// </summary>
    SerializedProperty mUpAxisColorProperty;

    /// <summary>
    /// 向量颜色
    /// </summary>
    SerializedProperty mVectorColorProperty;

    /// <summary>
    /// Cube1
    /// </summary>
    private GameObject mCube1;

    /// <summary>
    /// Cube2
    /// </summary>
    private GameObject mCube2;

    /// <summary>
    /// Cube3
    /// </summary>
    private GameObject mCube3;

    protected void OnEnable()
    {
        mCube1Property = serializedObject.FindProperty("Cube1");
        mCube2Property = serializedObject.FindProperty("Cube2");
        mCube3Property = serializedObject.FindProperty("Cube3");
        mCoordinateSystemLengthProperty = serializedObject.FindProperty("CoordinateSystemLength");
        mForwardAxisColorProperty = serializedObject.FindProperty("ForwardAxisColor");
        mRightAxisColorProperty = serializedObject.FindProperty("RightAxisColor");
        mUpAxisColorProperty = serializedObject.FindProperty("UpAxisColor");
        mVectorColorProperty = serializedObject.FindProperty("VectorColor");
    }

    protected virtual void OnSceneGUI()
    {
        InitData();
        DrawCubeInfo();
        DrawWorldCoordinateSystem();
        DrawVectorInfo();
    }

    /// <summary>
    /// 初始化数据
    /// </summary>
    private void InitData()
    {
        mCube1 = mCube1Property?.objectReferenceValue != null ? mCube1Property.objectReferenceValue as GameObject : null;
        mCube2 = mCube2Property?.objectReferenceValue != null ? mCube2Property.objectReferenceValue as GameObject : null;
        mCube3 = mCube3Property?.objectReferenceValue != null ? mCube3Property.objectReferenceValue as GameObject : null;
    }

    /// <summary>
    /// 绘制Cube信息
    /// </summary>
    private void DrawCubeInfo()
    {
        HandlesUtilities.DrawColorLable(mCube1.transform.position, "Cube1", Color.red);
        HandlesUtilities.DrawColorLable(mCube2.transform.position, "Cube2", Color.red);
        HandlesUtilities.DrawColorLable(mCube3.transform.position, "Cube3", Color.red);
    }

    /// <summary>
    /// 绘制世界坐标系
    /// </summary>
    private void DrawWorldCoordinateSystem()
    {
        HandlesUtilities.DrawColorLable(Vector3.zero, "世界坐标系", Color.red);
        if (Event.current.type == EventType.Repaint)
        {
            Handles.color = mForwardAxisColorProperty.colorValue;
            Handles.ArrowHandleCap(1, Vector3.zero,
                                    Quaternion.LookRotation(Vector3.forward),
                                    mCoordinateSystemLengthProperty.floatValue, EventType.Repaint);

            Handles.color = mRightAxisColorProperty.colorValue;
            Handles.ArrowHandleCap(1, Vector3.zero,
                                    Quaternion.LookRotation(Vector3.right),
                                    mCoordinateSystemLengthProperty.floatValue, EventType.Repaint);

            Handles.color = mUpAxisColorProperty.colorValue;
            Handles.ArrowHandleCap(1, Vector3.zero,
                                    Quaternion.LookRotation(Vector3.up),
                                    mCoordinateSystemLengthProperty.floatValue, EventType.Repaint);
        }
    }

    /// <summary>
    /// 绘制相关向量
    /// </summary>
    private void DrawVectorInfo()
    {
        if (Event.current.type == EventType.Repaint)
        {
            if (mCube1 != null && mCube2 != null && mCube3 != null)
            {
                var cube1Forward = mCube1.transform.forward;
                var cube1ToCube2 = mCube2.transform.position - mCube1.transform.position;
                var vectorDot = Vector3.Dot(cube1Forward, cube1ToCube2);
                var radians = Mathf.Acos(vectorDot / (cube1Forward.magnitude * cube1ToCube2.magnitude));
                var angle = Mathf.Rad2Deg * radians;
                var vectorCross = Vector3.Cross(cube1Forward, cube1ToCube2);
                vectorCross = (angle <= Mathf.Epsilon && angle >= -Mathf.Epsilon) ? cube1Forward : vectorCross;
                Handles.color = mVectorColorProperty.colorValue;
                Handles.ArrowHandleCap(1, mCube1.transform.position,
                                        Quaternion.LookRotation(cube1Forward),
                                        mCoordinateSystemLengthProperty.floatValue, EventType.Repaint);
                Handles.ArrowHandleCap(1, mCube1.transform.position,
                                        Quaternion.LookRotation(cube1ToCube2),
                                        mCoordinateSystemLengthProperty.floatValue, EventType.Repaint);
                Handles.ArrowHandleCap(1, mCube1.transform.position,
                                        Quaternion.LookRotation(vectorCross),
                                        mCoordinateSystemLengthProperty.floatValue, EventType.Repaint);
                HandlesUtilities.DrawColorLable(mCube1.transform.position, $"夹角:{angle}", Color.green);
            }
        }
    }
}