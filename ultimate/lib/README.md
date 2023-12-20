## 注册OPCDAAuto.dll

将lib目录下的OPCDAAuto.dll拷贝到C:\Windows\SysWOW64和C:\Windows\System32目录下，然后以管理员的方式在Powershell中执行如下命令：

```
REGSVR32 C:\Windows\SysWOW64\OPCDAAuto.dll
REGSVR32 C:\Windows\System32\OPCDAAuto.dll
```