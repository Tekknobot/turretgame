using UnityEngine;

namespace SuperShaders
{
    [ExecuteInEditMode]
    public class ColorSwapEffect : MonoBehaviour
    {
        [Header("Color A")]
        public Color sourceA = Color.blue;
        public Color targetA = Color.red;

        [Header("Color B")]
        public Color sourceB = Color.blue;
        public Color targetB = Color.red;

        [Header("Color C")]
        public Color sourceC = Color.blue;
        public Color targetC = Color.red;

        [Header("Color D")]
        public Color sourceD = Color.blue;
        public Color targetD = Color.red;    

        [Header("Color E")]
        public Color sourceE = Color.blue;
        public Color targetE = Color.red;             

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

            mpb.SetColor("_SourceA", enable ? sourceA : Color.blue);
            mpb.SetColor("_TargetA", enable ? targetA : Color.red);

            mpb.SetColor("_SourceB", enable ? sourceB : Color.blue);
            mpb.SetColor("_TargetB", enable ? targetB : Color.red);

            mpb.SetColor("_SourceC", enable ? sourceC : Color.blue);
            mpb.SetColor("_TargetC", enable ? targetC : Color.red);

            mpb.SetColor("_SourceD", enable ? sourceD : Color.blue);
            mpb.SetColor("_TargetD", enable ? targetD : Color.red);   

            mpb.SetColor("_SourceE", enable ? sourceE : Color.blue);
            mpb.SetColor("_TargetE", enable ? targetE : Color.red);                      

            spriteRenderer.SetPropertyBlock(mpb);
        }
    }
}
