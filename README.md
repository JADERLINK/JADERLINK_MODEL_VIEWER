# JADERLINK_MODEL_VIEWER

View the 3d models, from the files: Wavefront OBJ, StudioModelData SMD, Re4 Uhd BIN, Re4 Ps4/Ns BIN, Re4 PS2 BIN, Re4 2007 PMD, and your Re4 Scenario SMD files (PS2/UHD/2007/PS4/NS).

![](https://i.imgur.com/qXUzz8m.png)

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

RE4_PS2_MODEL_VIEWER.exe -> arquivos .BIN (Re4 Ps2) + .TPL, Scenario .SMD + .SMX;

RE4_PS4NS_MODEL_VIEWER.exe -> arquivos .BIN (Re4 Ps4/Ns) + .TPL, Scenario .SMD + .SMX, com suporte a arquivos .PACK;

## Updates

**Update 1.0.5**
<br>Adicionado o visualizador da versão de Ps4/Ns: RE4_PS4NS_MODEL_VIEWER;
<br>Aviso: nessa versão ainda não são suportadas as imagens GNF da versão de Ps4, então elas não serão carregadas do arquivo pack, o suporte será adicionado na próxima versão.

**Update 1.0.4**
<br>Adicionada a opção "Use Texture Nearest/Linear", que alterna a exibição da textura entre "Linear" (desfocado) e "Nearest" (Pixelado), para todas as versões.
<br>Para o UHD, adicionado mais compatibilidade de BINs e TPLs;

**Update 1.0.3**
<br>Melhorado a velocidade do carregamento das imagens nos programas.

**Update 1.0.2**
<br>Adicionado a opção de ativar/desativar a visualização do canal alfa da textura (Todos).
<br>Mudado o entendimento de como é carregado o canal alfa para a versão do UHD.

**Update 1.0.1b**
<br>Reduzido o tempo de carregamento dos arquivos TPL/SMD da versão de PS2.

**Update 1.0.1**
<br>Arrumado alinhamento da matriz de índices (isso evita possíveis bugs);
<br>Adicionado a opção de desligar/ativar as cores de vertices, nos visualizadores;
<br>Ao ativar/desativar a visualização das normals, caso a normal for xyz com valor zero, a normal não será exibida.
<br>Adicionado o visualizador da versão de Ps2: RE4_PS2_MODEL_VIEWER;

## **_MODEL_VIEWER.exe

Para abrir o programa, é necessário que sua placa de vídeo (GPU) tenha o OpenGL versão 3.3 ou superior. Caso sua versão seja inferior à requerida, o programa mostrará uma mensagem de erro.
<br>Aviso: a versão 1.0.* é uma versão de pré-lançamento, então os programas podem conter erros nos quais podem fechar o programa sem aviso.

## Para Desenvolvedores:

**Como compilar a partir do código-fonte:**

Requisitos: Visual Studio 2019 ou 2022, com suporte a Csharp;
<br>O projeto conta com duas .dlls externas que são baixadas via NuGet, as quais são:
<br> OpenTK, versão: 3.3.3
<br> OpenTK.GLControl, versão: 3.3.3
<br> Aviso: as outras dependências já estão presentes no código-fonte.

## Código de terceiro:

[ObjLoader by chrisjansson](https://github.com/chrisjansson/ObjLoader):
Encontra-se em ALL_VIEWER/CjClutter.ObjLoader.Loader, código modificado, as modificações podem ser vistas aqui: [link](https://github.com/JADERLINK/ObjLoader).
<br>[SMD_READER_API by JADERLINK](https://github.com/JADERLINK/SMD_READER_API).
<br>[TGASharpLib by ALEXGREENALEX](https://github.com/ALEXGREENALEX/TGASharpLib).
<br>[DDSReaderSharp by ALEXGREENALEX](https://github.com/ALEXGREENALEX/DDSReaderSharp).
<br>[OpenTK](https://github.com/opentk/opentk/blob/master/LICENSE.md).

-----
**At.te: JADERLINK**
<br>2024-10-06