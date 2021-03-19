﻿using UnityEngine;

namespace SuperShaders
{
    [ExecuteInEditMode]
    public class FillEffect : MonoBehaviour
    {
        public bool fill = false;

        public Color color = Color.white;

        private SpriteRenderer spriteRenderer;

        private void OnEnable()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            UpdateEffect(true);
        }

        private void OnDisable()
        {
            UpdateEffect(false);
        }

        private void Update()
        {
            UpdateEffect(true);
        }

        private void UpdateEffect(bool enable)
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();

            spriteRenderer.GetPropertyBlock(mpb);

            mpb.SetFloat("_Fill", enable ? (fill ? 1 : 0) : 0);
            mpb.SetColor("_FillColor", enable ? color : Color.white);

            spriteRenderer.SetPropertyBlock(mpb);
        }
    }
}
