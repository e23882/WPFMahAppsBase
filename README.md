# MahAppBase
我自己常用的WPF專案

### 目前功能:
- NLog
- 桌面通知(Notification)
- Dockable
- MVVM基本建設(ViewModel、Command)
- Interaction
- DI
- try catch 攔截器
---
#### NLog
就Log，Config設定好了，會有紀錄時間跟訊息，依照日期換檔案

---
#### Notification
桌面會彈出來東西通知使用者

---
#### Dockable
可以把視窗從視窗中間拉出來到你想要的地方，或拼回去你想要拚回去的地方

---
#### MVVM基本建設
- 實現INotifyPropertyChanged介面的基礎類別: ViewModelBase
- 實現ICommand類別的基礎類別: RelayCommand

實現MVVM 避免最後同事會寫很多Dispatch.BeginInvoke()，有一天大爆炸壞掉的時候自己要留下來修

---
#### Interaction
有一些沒有Command可以Binding的元件，可以透過這個去實現特定事件綁定Command

---
#### 依賴注入容器
透過DI統一管理ViewModel實例，避免ViewModel被new的到處都是，ViewModel中的類別實例被hook來action去，最後Memory leak時同事會說視窗不能關關了會壞掉但他不修，業務會說不管怎麼做只想看到使用500M以下，我榦你老師

---
#### try catch 攔截器
加了之後，會記錄方法什麼時候開始執行，什麼時候結束，有例外會handle住
```
2025-02-11 16:31:12.4763 [INFO ] Executing function TestInterceptorWorking()
2025-02-11 16:31:12.4763 [INFO ] TestInterceptorWorking() execution completed
```

### 還想再加入的功能
- 透過反射的方式讓DLL能動態並加入功能，但需要不能影響太多效能
- 客製化的DataGrid，實現Scrollbar滑到哪，再載入資料，不要一次載入太多資料讓介面鎖死
- Async Command，執行後可以鎖住避免按多次，執行完可以有callback讓按鈕回復正常

- 我還沒想到

