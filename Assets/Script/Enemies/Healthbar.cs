using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image fill;

    private Transform target;
    private Vector3 offset = new Vector3(0f, 0.3f, 0f);

    // ����׿� ����
    public bool IsConfigured => fill != null;

    private void OnValidate()
    {
        // �����Ϳ��� ������/�� ���ڸ��� ��� ����
        if (fill == null)
        {
            Debug.LogError($"[Healthbar] 'Fill(Image)'�� ����ֽ��ϴ�. " +
                           $"Healthbar/Canvas/Background/Fill �� Image ������Ʈ�� " +
                           $"Healthbar.fill ���Կ� �巡���� �����ϼ���. (Prefab: {name})", this);
        }
    }

    public void Setup(Transform followTarget, float max, float current)
    {
        target = followTarget;

        if (fill == null)
        {
            Debug.LogError("[Healthbar] Fill�� null�̶� �ʱ�ȭ ����. ü�¹ٰ� ���ŵ��� �ʽ��ϴ�.", this);
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
            Debug.LogError("[Healthbar] UpdateHealth ȣ������� Fill�� null �Դϴ�.", this);
            return;
        }

        fill.fillAmount = (max <= 0f) ? 0f : current / max;
    }

    private void LateUpdate()
    {
        if (target != null) transform.position = target.position + offset;
    }
}
