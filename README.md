# CalculateFee  
停車費的計算  

## 題目1：  
[題目來源](https://www.evernote.com/shard/s530/client/snv?noteGuid=9e16269c-6476-0e8e-1d0f-6ef712456280&noteKey=8051edac93ec4abe6d78976e209cdc49&sn=https%3A%2F%2Fwww.evernote.com%2Fshard%2Fs530%2Fsh%2F9e16269c-6476-0e8e-1d0f-6ef712456280%2F8051edac93ec4abe6d78976e209cdc49&title=20220506.Q1%2B%25E8%25A8%2588%25E7%25AE%2597%25E5%2581%259C%25E8%25BB%258A%25E5%2588%2586%25E9%2590%2598%25E6%2595%25B8)  
專案：Q01  
測試：Q01.Test  
計算停車分鐘數  

假設計算停車時間的邏輯是不理會秒數，例如 13:10:59 視為是 13:10:00。  
所以停車時間如果是13:10:59 - 13:11:10。  
雖然他只停11秒而已，仍視為停了1分鐘  
  
各位寫好, 請自行測試以下情境是否都正確  

開始|結束時間|正確答案(分鐘數)
--|--|--
09:00:00|09:00:59|0
09:00:00|09:01:59|1
09:00:59|09:01:00|1
09:59:00|10:00:01|1
09:00:00|10:00:59|60

## 題目2：
專案：Q02  
測試：Q02.Test  
  
承上題  
已知停車的時間起迄一定是同一天, 程式裡不必判斷  
已知停車的時間起迄, 大小值一定不會相反, 程式裡不必判斷  
  
需求  
請以以下規則來計算應付的停車費
```
public class Solution{
        // 傳入的是時間起迄, 並非分鐘數
public int CalcFee(DateTime start, DateTime end){ // 傳回應付停車費
// todo
}
// 這裡可以自行加其他需要的 method
}
```

收費規則  
中括號表示有包含該值, 小括號表示沒有包含該值, 例如  
[0, 10] 表示  0<= mins<= 10  
(0, 10) 表示  0< mins < 10  
(0, 10] 表示  0< mins<= 10  
[0, 10) 表示  0<= mins< 10  
  
停車時間總長度若在 [0,10], 免費  
停車時間總長度若在 [11,30], 7元  
停車時間總長度若在 [31,59], 10 元  
停車時間總長度若在[60, 1439] :  
先算有幾小時,每小時收 10元  
若有剩餘分鐘數, 且小於等於 30  分, 加收 7元  
若有剩餘分鐘數, 且大於 30  分, 加收 10元  
一天最多只收 50 元  
  
根據以上規則, 我列了一些範例, 供各位參考, 程式寫完後, 可以用以下數值來比較程式的正確性  

總分鐘數|應收停車費用
--|--
[0, 10]|0
[11,30]|7
[31, 59]|10
60|10, 每一小時10元
[61, 90]|17, 只要超過 60分鐘, 就算每小時10元, 接著再看看剩餘分鐘數, 若小於等於30分, 加收 7元; 若大於30分, 加收10元
[91,119]|20, 只要超過 60分鐘, 就算每小時10元, 接著再看看剩餘分鐘數, 若小於等於30分, 加收 7元; 若大於30分, 加收10元
120|20
[121,150]|前120分收10 * 2 = 20元, 剩餘分鐘數 <=30,加收 7元, 共收 27元
[151, 179]|前120分收10 * 2 = 20元, 剩餘分鐘數 > 30,加收 10元, 共收 30元
....|
[300, 1439]|每天最長停車時間是00:00:00 ~ 23:59:00, 所以每天最長只會停1439分鐘, 每天最多只收 50 元

## 題目3：  
[題目來源](https://www.evernote.com/shard/s530/sh/8e50c58e-405b-2fee-7072-62a7078fa146/67b10ac9342f986961e9d644361ef14d)  
  
承上題  

### 限制  
停車的時間起迄不一定是同一天  
在 CalcFeeForMultiDays() 必需檢查輸入時間的大小關係, start 必需小於 end  
  
### 需求  
請以以下規則來計算應付的停車費  
傳回型別是 IEnumerable<SingleDayFee> 不是 int  
```
public class Solution{  
        // 傳入的是時間起迄, 並非分鐘數  
public IEnumerable<SingleDayFee> CalcFeeForMultiDays(DateTime start, DateTime end){ // 傳回每天應付停車費的集合  
// todo
}
// 這裡可以自行加其他需要的 method
}

// 單日停車資訊
public class SingleDayFee{
    public DateTime StartTime{get;set;} // 精確到分鐘的入場時間
    public DateTime EndTime{get;set;} // 精確到分鐘的離場時間
    public int Fee{get;set;} // 本日應收取費用
}
```

### 進階題
在本題要求傳回型別是 IEnumerable<SingleDayFee>  
只是為了簡化程式, 如果各位能力所及, 可以改寫成傳回 ParkingFee 型別, client 會更方便使用  
  
ParkingFee 要不要繼承其他類別, 可以自行決定  
為了方便測試, 寫這題的朋友, method 命名請採用 CalcParkingFee()  
```
public class Solution{
        // 傳入的是時間起迄, 並非分鐘數
public ParkingFee CalcParkingFee(DateTime start, DateTime end){ // 傳回每天應付停車費
// todo
}
// 這裡可以自行加其他需要的 method
}

public class ParkingFee{
    public IEnumerable<SingleDayFee> Items{get; private set;}
    public int TotalFee{get;}
}

// 單日停車資訊
public class SingleDayFee{
    public DateTime StartTime{get;set;} // 精確到分鐘的入場時間
    public DateTime EndTime{get;set;} // 精確到分鐘的離場時間
    public int Fee{get;set;} // 本日應收取費用
}
```

### 收費規則  
如果停車時間沒有跨越一天, 就按 Q2 規則計算即可, 傳回的集合裡,包含一筆記錄  
如果停車時間有跨越一天以上  
先根據入場/離場時間, 切割成多筆單日停車時間  
再逐筆計算每天應付費用  

### 範例
範例 1 - 沒有跨天  
直接套 Q2 的計算邏輯  
  
範例 2 - 跨1天,時間極短  
2002/5/1 23:49:00 ~  2002/5/2 00:10:59  
由於切割成二天之後, 每一天停車時間都小於或等於10, 因此二天都不必付費  
傳回的集合包含二筆記錄, 金額都是零元  
  
範例 3 - 跨1天,必需付費  
2002/5/1 23:48:00 ~  2002/5/2 00:11:59  
切割成二天之後  
第一天停11分鐘  
第二天停11分鐘  
所以二天都要付費  
  
範例 4 - 跨2天以上,必需付費  
2002/5/1 23:48:00 ~  2002/5/3 00:11:59  
切割成二天之後  
第一天停11分鐘  
第二天停 23小時 59分鐘  
第二天停11分鐘  
所以三天都要付費  