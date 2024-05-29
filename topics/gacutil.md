# Gacutil
No .NET Framework, a **GAC (Global Assembly Cache) é um local de armazenamento especializado para as bibliotecas compartilhadas (assemblies) que podem ser acessadas por várias aplicações em um sistema.**
- O **Global Assembly Cache** nada mais é do que uma pasta de disco especial onde todos os **Assemblys compartilhados deverão ser colocados.**
- Se o componente não é encontrado no mesmo diretório da aplicação, a aplicação procura-o no GAC.

Se você estiver usando uma versão do .NET Framework que suporta a GAC e deseja adicionar uma biblioteca a ela, você pode seguir os passos abaixo:

**1.** Abra o Prompt de Comando: Pressione `Win + R`, digite `cmd` e pressione Enter para abrir o prompt de comando.

**2.** Registrar o Assembly no GAC: Finalmente, você precisa registrar o assembly no GAC usando o utilitário `gacutil` (que faz parte das ferramentas de desenvolvedor do Visual Studio):
- Navegue até a pasta onde o `gacutil.exe` está localizado. Geralmente, está em algo como `C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools:`
- Registre o assembly no GAC:
```sh
gacutil /i C:\Users\name\source\repos\packages\assembly.dll 

OR

gacutil -i C:\Users\name\source\repos\packages\assembly.dll 
```

**3.** Caso retorne uma mensagem avisando que a assembly não possui uma Strong Name Key, você mesmo pode adicionar uma para ela:
```sh
cd C:\Users\name\source\repos\packages\
& 'C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe' -k KeyPair.snk

& 'C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\sn.exe' -Ra assembly.dll KeyPair.snk

& 'C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\gacutil.exe' /i C:\Users\name\source\repos\packages\assembly.dll
```



