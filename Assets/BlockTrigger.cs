using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 추가

public class BlockCollision : MonoBehaviour
{
    public TextMeshProUGUI displayText; // TextMeshProUGUI 타입으로 변경

    void Start()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false); // 처음에는 텍스트를 비활성화
        }
    }

    // 플레이어가 콜라이더에 부딪혔을 때 호출되는 메서드
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (displayText != null)
            {
                //displayText.text = "블록에 올라왔습니다!"; // 원하는 텍스트 설정
                displayText.gameObject.SetActive(true); // 텍스트 활성화
            }
        }
    }

    // 플레이어가 콜라이더에서 나갔을 때 호출되는 메서드
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (displayText != null)
            {
                displayText.gameObject.SetActive(false); // 텍스트 비활성화
            }
        }
    }
}
