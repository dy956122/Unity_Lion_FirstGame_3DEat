using UnityEngine;

public class CameraTrack : MonoBehaviour
{

    #region 欄位 與屬性
    /// <summary>
    /// 玩家變形元件
    /// </summary>
    private Transform player;

    [Header("追蹤速度"), Range(0.1f, 50.5f)]
    public float speed = 1.5f;


    #endregion 欄位 與屬性 結束

    #region 方法
    /// <summary>
    ///  追蹤玩家
    /// </summary>
    private void Track()
    {
        // 以下註解，每個人的距離都不一樣
        // 攝影機 與小明 Y軸 距離  6 - 0.05 = 5.95 
        // 攝影機 與小明 Z軸 距離  -8 - (-2.8) = -5.2
        Vector3 posTrack = player.position;
        posTrack.y += 4.95f;
        posTrack.z += -4.2f;

        // 攝影機座標 = 變形.座標
        Vector3 posCam = transform.position;
        // 攝影機座標 = 三維向量.插值(A點,B點,百分比)
        posCam = Vector3.Lerp(posCam, posTrack, 0.5f * Time.deltaTime * speed);
        //  變形.座標 = 攝影機座標
        transform.position = posCam;
    }
    #endregion 方法 結束


    #region 事件
    private void Start()
    {
        // 小明物件 = 遊戲物件.尋找("物件名稱").變形
        player = GameObject.Find("小明").transform;
    }


    // 延遲更新：會在Update 執行後再執行
    // 建議：需要追蹤座標，要寫在此事件內
    private void LateUpdate()
    {
        Track();
    }





    /* 實驗 Lerp 插值
    public float A = 0;
    public float B = 100;

    public Vector2 v2A = Vector2.zero;
    public Vector2 v2B = Vector2.one * 1000;



    private void Update()
    {
        // Lerp 插值
        A = Mathf.Lerp(A, B, 0.5f);

        v2A = Vector2.Lerp(v2A, v2B, 0.5f);
    }*/

    #endregion 事件 結束
}
