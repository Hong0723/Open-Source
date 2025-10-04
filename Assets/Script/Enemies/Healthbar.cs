using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image fill;

    private Transform target;
    private Vector3 offset = new Vector3(0f, 0.3f, 0f);

    // 디버그용 노출
    public bool IsConfigured => fill != null;

    private void OnValidate()
    {
        // 에디터에서 프리팹/씬 열자마자 즉시 검증
        if (fill == null)
        {
            Debug.LogError($"[Healthbar] 'Fill(Image)'가 비어있습니다. " +
                           $"Healthbar/Canvas/Background/Fill 의 Image 컴포넌트를 " +
                           $"Healthbar.fill 슬롯에 드래그해 연결하세요. (Prefab: {name})", this);
        }
    }

    public void Setup(Transform followTarget, float max, float current)
    {
        target = followTarget;

        if (fill == null)
        {
            Debug.LogError("[Healthbar] Fill이 null이라 초기화 실패. 체력바가 갱신되지 않습니다.", this);
            return;
        }

        fill.type = Image.Type.Filled;
        fill.fillMethod = Image.FillMethod.Horizontal;
        fill.fillOrigin = (int)Image.OriginHorizontal.Left;

        UpdateHealth(current, max);
    }

    public void UpdateHealth(float current, float max)
    {
        if (fill == null)
        {
            Debug.LogError("[Healthbar] UpdateHealth 호출됐지만 Fill이 null 입니다.", this);
            return;
        }

        fill.fillAmount = (max <= 0f) ? 0f : current / max;
    }

    private void LateUpdate()
    {
        if (target != null) transform.position = target.position + offset;
    }
}
