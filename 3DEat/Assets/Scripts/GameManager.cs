using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region 欄位與屬性
    [Header("道具")]
    public GameObject[] props;
    [Header("文字介面：道具數量")]
    public Text textcount;
    [Header("文字介面：倒數時間")]
    public Text textTime;
    [Header("文字介面：結束畫面標題")]
    public Text textTitle;
    [Header("結束畫面")]
    public CanvasGroup final;
    


    /// <summary>
    /// 道具總數
    /// </summary>
    private int countTotal;

    /// <summary>
    /// 取得道具數量
    /// </summary>
    private int countProp;

    /// <summary>
    /// 遊戲時間
    /// </summary>
    private float gameTime = 30;



    #endregion 欄位與屬性 結束

    #region 方法

    /// <summary>
    /// 生成道具
    /// </summary>
    /// <param name="Prop">想要生成的道具數量</param>
    /// <param name="count">想要生成的道具數量 + 隨機值 + - 5 </param>
    private int CreateProp(GameObject prop, int count) // 注意：這裡不是 void , 而是 int
    {
        // 取得隨機道具數量 = 指定的數量 + - 5
        int total = count + Random.Range(-5, 5);

        // for 迴圈
        for (int i = 0; i < total; i++)
        {
            // 座標 = (隨機, 1.5 , 隨機)
            Vector3 pos = new Vector3(Random.Range(-9, 9), 1.5f, Random.Range(-9, 9));
            // 生成 (物件, 座標, 角度)
            Instantiate(prop, pos, Quaternion.identity);

        }

        // 傳回 道具數量
        return total;
    }

    /// <summary>
    /// 時間倒數
    /// </summary>
    private void CountTime()
    {
        // 遊戲時間 遞減 一禎的時間
        gameTime -= Time.deltaTime;

        // 更新倒數時間介面 ToString ("f小數點位數")
        textTime.text = "倒數時間：" + gameTime.ToString("f2");
    }

    #endregion 方法 結束


    #region 事件
    private void Start()
    {
        countTotal = CreateProp(props[0], 20); // 道具總數 = 生成道具 (道具一號, 指定數量)
        textcount.text = "道具數量：0 / " + countTotal;

        CreateProp(props[1], 10); //  生成道具(道具二號, 指定數量)

    }

    private void Update()
    {
        CountTime();
    }

    #endregion 事件 結束
}
