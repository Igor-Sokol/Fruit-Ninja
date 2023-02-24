using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Blur
{
    public class UIBlur : MonoBehaviour
    {
        private static readonly int ColorId = Shader.PropertyToID("_Color");
        private static readonly int IntensityId = Shader.PropertyToID("_Intensity");
        private static readonly int MultiplierId = Shader.PropertyToID("_Multiplier");
        
        private Material _material;

        [SerializeField] private Image image;
        [SerializeField] private Color color = Color.white;
        [SerializeField, Range(0f, 1f)] private float intensity;
        [SerializeField, Range(0f, 1f)] private float multiplier = 0.15f;
        [SerializeField] private bool autoUpdate;

        public Color Color { get => color; set { color = value; UpdateColor(); } }
        public float Intensity { get => intensity; set { intensity = Mathf.Clamp01(value); UpdateIntensity(); } }
        public float Multiplier { get => multiplier; set { multiplier = Mathf.Clamp01(value); UpdateMultiplier(); } }

        public void UpdateBlur()
        {
            SetBlur(Color, Intensity, Multiplier);
        }

        public void SetBlur(Color newColor, float newIntensity, float newMultiplier)
        {
            Color = newColor;
            Intensity = newIntensity;
            Multiplier = newMultiplier;
        }

        private void Awake()
        {
            SetComponents();
            SetBlur(Color, Intensity, multiplier);
        }

        private void Update()
        {
            if (autoUpdate)
            {
                UpdateColor();
                UpdateIntensity();
                UpdateMultiplier();
            }
        }

        private void SetComponents()
        {
            _material = FindMaterial();
        }

        private Material FindMaterial()
        {
            Material material = image.material;
            return material;
        }

        private void UpdateColor()
        {
            _material.SetColor(ColorId, Color);
        }

        private void UpdateIntensity()
        {
            _material.SetFloat(IntensityId, Intensity);
        }

        private void UpdateMultiplier()
        {
            _material.SetFloat(MultiplierId, Multiplier);
        }

        #region Editor
#if UNITY_EDITOR
        private void OnValidate()
        {
            UpdateBlurInEditor();
        }

        private void UpdateBlurInEditor()
        {
            Material material = FindMaterial();

            material.SetColor(ColorId, Color);
            material.SetFloat(IntensityId, Intensity);
            material.SetFloat(MultiplierId, Multiplier);

            EditorUtility.SetDirty(material);
        }
#endif
        #endregion
    }
}