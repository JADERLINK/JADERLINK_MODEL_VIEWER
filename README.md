# JADERLINK_MODEL_VIEWER

View the 3d models, from the files: .obj, .smd, Re4 Uhd .BIN, Re4 PS2 .BIN, Re4 2007 .PMD, and your Re4 .SMD scenario files (PS2/UHD/2007).

![](https://i.imgur.com/tL1reYS.png)

**Info:**
<br>License: MIT Licence
<br>Linguage: C#
<br>Platform: Windows
<br>Dependency: Microsoft .NET Framework 4.8
<br>Requires openGL 3.3 or higher

**Translate from Portuguese Brazil**

Programas destinados a visualizar modelos 3D dos arquivos:

JADERLINK_MODEL_VIEWER.exe -> Arquivos .OBJ (Wavefront), .SMD (StudioModelData), com suporte a .MTL, e as texturas: DDS, TGA, PNG, BMP e JPG.

RE4_2007_MODEL_VIEWER.exe -> Arquivos .PMD (Re4 2007), Scenario .SMD + .SMX, com suporte a texturas .TGA;

RE4_UHD_MODEL_VIEWER.exe -> arquivos .BIN (Re4 Uhd) + .TPL, Scenario .SMD + .SMX, com suporte a arquivos .PACK e PACK.YZ2;

RE4_PS2_MODEL_VIEWER.exe -> arquivos .BIN (Re4 PS2) + .TPL, Scenario .SMD + .SMX;

**Update 1.0.1**
<br>Arrumado alinhamento da matriz de índices (isso evita possíveis bugs);
<br>Adicionado a opção de desligar/ativar as cores de vertices, nos visualizadores;
<br>Ao ativar/desativar a visualização das normals, caso a normal for xyz com valor zero, a normal não será exibida.
<br>Adicionado o visualizador de ps2: RE4_PS2_MODEL_VIEWER;

# **_MODEL_VIEWER.exe

Para abrir o programa, é necessário que sua placa de vídeo (GPU) tenha o OpenGL versão 3.3 ou superior. Caso sua versão seja inferior à requerida, o programa mostrará uma mensagem de erro.
<br>Aviso: a versão 1.0.1 é uma versão de pré-lançamento, então os programas podem conter erros nos quais podem fechar o programa sem aviso.

# Para Desenvolvedores:

**Como compilar a partir do código-fonte:**

Requisitos: Visual Studio 2019 ou 2022, com suporte a Csharp;
<br>O projeto conta com duas .dlls externas que são baixadas via NuGet, as quais são:
<br> OpenTK, versão: 3.3.3
<br> OpenTK.GLControl, versão: 3.3.3
<br> Aviso: as outras dependências já estão presentes no código-fonte.

# Código de terceiro:

[ObjLoader by chrisjansson](https://github.com/chrisjansson/ObjLoader):
Encontra-se em ALL_VIEWER/CjClutter.ObjLoader.Loader, código modificado, as modificações podem ser vistas aqui: [link](https://github.com/JADERLINK/ObjLoader).
<br>[SMD_READER_API by JADERLINK](https://github.com/JADERLINK/SMD_READER_API).
<br>[TGASharpLib by ALEXGREENALEX](https://github.com/ALEXGREENALEX/TGASharpLib).
<br>[DDSReaderSharp by ALEXGREENALEX](https://github.com/ALEXGREENALEX/DDSReaderSharp).
<br>[OpenTK](https://github.com/opentk/opentk/blob/master/LICENSE.md).

-----
**At.te: JADERLINK**
<br>2024-05-04