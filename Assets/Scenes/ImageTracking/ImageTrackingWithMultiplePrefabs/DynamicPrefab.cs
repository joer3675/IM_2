using System;
using System.Text;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Change the prefab for the first image in library at runtime.
    /// </summary>
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class DynamicPrefab : MonoBehaviour
    {
        GameObject m_OriginalPrefab;

        GameObject m_OriginalPrefab1;

        GameObject m_OriginalPrefab2;

        [SerializeField]
        GameObject m_AlternativePrefab;
        [SerializeField]
        GameObject m_AlternativePrefab1;
        [SerializeField]
        GameObject m_AlternativePrefab2;


        public GameObject alternativePrefab
        {
            get => m_AlternativePrefab;
            set => m_AlternativePrefab = value;
        }

        public GameObject alternativePrefab1
        {
            get => m_AlternativePrefab1;
            set => m_AlternativePrefab1 = value;
        }

        public GameObject alternativePrefab2
        {
            get => m_AlternativePrefab2;
            set => m_AlternativePrefab2 = value;
        }



        enum State
        {
            OriginalPrefab,
            ChangeToOriginalPrefab,
            AlternativePrefab,
            ChangeToAlternativePrefab,
            Error
        }

        State m_State;

        string m_ErrorMessage = "";

        void OnGUI()
        {
            var fontSize = 50;
            GUI.skin.button.fontSize = fontSize;
            GUI.skin.label.fontSize = fontSize;

            float margin = 100;

            GUILayout.BeginArea(new Rect(margin * 2, Screen.height - margin, Screen.width - margin * 4, Screen.height - margin * 4));

            switch (m_State)
            {
                case State.OriginalPrefab:
                    {
                        if (GUILayout.Button($"Piktogram"))
                        {
                            Pictogram.setPictogram(true);
                            m_State = State.ChangeToAlternativePrefab;
                            Debug.Log(Pictogram.getPictogramState());

                        }

                        break;
                    }
                case State.AlternativePrefab:
                    {
                        if (GUILayout.Button($"Text"))
                        {
                            Pictogram.setPictogram(false);
                            m_State = State.ChangeToOriginalPrefab;
                            Debug.Log(Pictogram.getPictogramState());

                        }

                        break;
                    }
                case State.Error:
                    {
                        GUILayout.Label(m_ErrorMessage);
                        break;
                    }
            }
            GUILayout.EndArea();
        }

        void SetError(string errorMessage)
        {
            m_State = State.Error;
            m_ErrorMessage = $"Error: {errorMessage}";
        }

        void Update()
        {
            switch (m_State)
            {
                case State.ChangeToAlternativePrefab:
                    {
                        if (!alternativePrefab)
                        {
                            SetError("No alternative prefab is given.");
                            break;
                        }

                        var manager = GetComponent<PrefabImagePairManager>();
                        if (!manager)
                        {
                            SetError($"No {nameof(PrefabImagePairManager)} available.");
                            break;
                        }

                        var library = manager.imageLibrary;
                        if (!library)
                        {
                            SetError($"No image library available.");
                            break;
                        }

                        if (!m_OriginalPrefab)
                            m_OriginalPrefab = manager.GetPrefabForReferenceImage(library[0]);
                        m_OriginalPrefab1 = manager.GetPrefabForReferenceImage(library[1]);
                        m_OriginalPrefab2 = manager.GetPrefabForReferenceImage(library[2]);

                        manager.SetPrefabForReferenceImage(library[0], alternativePrefab);
                        manager.SetPrefabForReferenceImage(library[1], alternativePrefab1);
                        manager.SetPrefabForReferenceImage(library[2], alternativePrefab2);
                        m_State = State.AlternativePrefab;
                        break;
                    }

                case State.ChangeToOriginalPrefab:
                    {
                        if (!m_OriginalPrefab)
                        {
                            SetError("No original prefab is given.");
                            break;
                        }

                        var manager = GetComponent<PrefabImagePairManager>();
                        if (!manager)
                        {
                            SetError($"No {nameof(PrefabImagePairManager)} available.");
                            break;
                        }

                        var library = manager.imageLibrary;
                        if (!library)
                        {
                            SetError($"No image library available.");
                            break;
                        }

                        manager.SetPrefabForReferenceImage(library[0], m_OriginalPrefab);
                        manager.SetPrefabForReferenceImage(library[1], m_OriginalPrefab1);
                        manager.SetPrefabForReferenceImage(library[2], m_OriginalPrefab2);
                        m_State = State.OriginalPrefab;
                        break;
                    }
            }
        }
    }
}
