# JDMonitor

用于监控京东商品价格变化，辅助剁手党


请注意修改程序根目录下的options.json配置文件，目前仅支持通过qq邮箱发送邮件通知。

配置示例
```
{
  "MailOptions": {
    "Sender": "xxx@qq.com",
    "Receiver": "yyy@qq.com",
    "MailHost": "smtp.qq.com",
    "MailPort": 465,
    "MailCode": "12345678"
  },
  "Period": 14400,
  "MaxLogLine": 1024,
  "Headless": true,
  "MaxDegreeOfParallelism": 1,
  "PageLoadTimeout": 60000,
  "UseCssSelector": true
}
```
MailOptions 配置说明

|  项   | 说明  |
|  ----  | ----  |
| Sender  | 发送者邮箱地址 |
| Receiver  | 接收者邮箱地址 |
| MailHost  | qq邮件服务器地址，一般固定为  smtp.qq.com|
| MailPort  | qq邮件服务器端口，一般固定为  465|
| MailCode  | qq邮箱授权码，可登录qq邮箱后台查看|

基本配置项说明

|  项   | 说明  |
|  ----  | ----  |
| Period  |  同步周期 |
| MaxLogLine  |  程序界面中最大日志展示行数 |
| Headless  |  使用使用Headless模式抓取网页 |
| MaxDegreeOfParallelism  |  并行同步任务数，建议为 cpu核数-1或保持为1 |
| PageLoadTimeout  |  页面加载超时时间 |
| UseCssSelector  |  使用css选择器模式定位页面价格等关键元素，如果未false，则表示使用XPath模式，此模式兼容性不是很好 |

示例图
![1](https://github.com/pedoc/JDMonitor/blob/master/Example/main.png)
![2](https://github.com/pedoc/JDMonitor/blob/master/Example/history.png)
