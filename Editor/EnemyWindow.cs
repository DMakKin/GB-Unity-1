using UnityEngine;
using UnityEditor;

namespace DM.Editor
{
    public class EnemyWindow : EditorWindow
    {
        Color enemyColor;

        [MenuItem("GameObject/Enemy Attributes")]
        public static void ShowWindow()
        {
            GetWindow<EnemyWindow>("Enemy Window");
        }

        private void OnGUI()
        {
            GUILayout.Label("Attributes", EditorStyles.boldLabel);

            enemyColor = EditorGUILayout.ColorField("Color", enemyColor);

            if (GUILayout.Button("Change color"))
            {
                ChangeColor();
            }            
        }

        private void ChangeColor()
        {
            foreach (GameObject enemy in Selection.gameObjects)
            {
                Renderer rend = enemy.GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material.color = enemyColor;
                }
            }
        }
    }
}

