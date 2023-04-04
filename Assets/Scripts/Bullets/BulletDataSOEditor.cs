using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObject;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BulletDataSO))]
public class BulletDataSOEditor : Editor
{
    private static List<Type> dataCompTypes = new List<Type>();

    private BulletDataSO _dataSo;

    private bool showAddComponentButtons;

    private void OnEnable()
    {
        _dataSo = target as BulletDataSO;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        showAddComponentButtons = EditorGUILayout.Foldout(showAddComponentButtons, "Add Components");

        if (showAddComponentButtons)
        {
            foreach (var dataCompType in dataCompTypes)
            {
                if (GUILayout.Button(dataCompType.Name))
                {
                    var comp = Activator.CreateInstance(dataCompType) as ComponentData;

                    if (comp == null) return;
                    
                    comp.InitializeAttackData();
                    
                    _dataSo.AddData(comp);
                }
            }
        }
    }

    [DidReloadScripts]
    private static void OnRecompile()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var types = assemblies.SelectMany(assembly => assembly.GetTypes());
        var filteredTypes = types.Where(
            type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass
        );
        dataCompTypes = filteredTypes.ToList();
    }
}
