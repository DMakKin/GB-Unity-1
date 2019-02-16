using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DM.Editor
{
    [CustomEditor(typeof(CreateEnemy))]
    public class CreateEnemyEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
        CreateEnemy placeForEnemy = (CreateEnemy)target;
            if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
            {
                Ray ray = Camera.current.ScreenPointToRay(new Vector3(Event.current.mousePosition.x,
                    SceneView.currentDrawingSceneView.camera.pixelHeight - Event.current.mousePosition.y));

                if (Physics.Raycast(ray, out var hit))
                {
                    placeForEnemy.InstantiateEnemy(hit.point);
                }
            }
            Selection.activeGameObject = FindObjectOfType<CreateEnemy>().gameObject;
        }
    }
}

