# JADERLINK_MODEL_VIEWER

View the 3d models, from the files: Wavefront OBJ, StudioModelData SMD, RE4 BIN, RE4 PMD, and RE4 Scenario SMD files (For RE4 OG PS2/UHD/2007/PS4/NS/X360/PS3/GC/WII).

![](https://i.imgur.com/HU9q8iM.png)

**Info:**
<br>License: MIT Licence
<br>Language: C#
<br>Platform: Windows / Linux Mono or Wine
<br>Dependency: Microsoft .NET Framework 4.8 or Mono/Wine
<br>Requires openGL 3.3 or higher

**Translate from Portuguese Brazil**

Programas destinados a visualizar modelos 3D dos arquivos:

JADERLINK_MODEL_VIEWER.exe -> Arquivos .OBJ (Wavefront), .SMD (StudioModelData), com suporte a .MTL, e as texturas: DDS, GNF, TGA, PNG, BMP, JPG e JPEG.

RE4_2007_MODEL_VIEWER.exe -> Arquivos .PMD (Re4 2007), Scenario .SMD + .SMX, com suporte a texturas .TGA;

RE4_UHD_MODEL_VIEWER.exe -> arquivos .BIN (Re4 Uhd) + .TPL, Scenario .SMD + .SMX, com suporte a arquivos .PACK e .PACK.YZ2 (texturas: DDS e TGA);

RE4_PS2_MODEL_VIEWER.exe -> arquivos .BIN (Re4 Ps2) + .TPL, Scenario .SMD + .SMX;

RE4_PS4NS_MODEL_VIEWER.exe -> arquivos .BIN (Re4 Ps4/Ns) + .TPL, Scenario .SMD + .SMX, com suporte a arquivos .PACK (texturas: DDS, GNF e TGA);

RE4_GCWII_MODEL_VIEWER.exe -> arquivos .BIN (Re4 Gc/Wii), Scenario .SMD + .SMX;

RE4_X360PS3_MODEL_VIEWER.exe -> arquivos .BIN (Re4 x360/ps3) + .TPL, Scenario .SMD + .SMX, com suporte a arquivos do x360 .PACK e .PACK.YZ2 (sem compressão) (texturas: DDS e TGA), arquivos PACKs do PS3 não são suportados;

## Updates

**Update 1.0.7**
<br>Adicionado suporte parcial para Linux, para Mono e Wine, sendo o Wine recomendado para uso no Linux.
<br>Agora na tool "JADERLINK_MODEL_VIEWER" o "Open OBJ Split", foi dividido em dois botões, que definem em que ordem os grupos são ordenados.
<br>Adicionada a tool "RE4_GCWII_MODEL_VIEWER.exe", pode abrir arquivos BINs e SMDs de cenário, porém essa versão não consegue carregar as texturas;
<br>Adicionado a tool "RE4_X360PS3_MODEL_VIEWER.exe" pode abrir os arquivos BINs + TPLs, SMDs + SMXs, e arquivos PACK da versão X360 e os arquivos PACK do PS3 não podem ser abertos, pois essa versão não tem suporte para imagem GNF, TGA03 e TGA15.
<br>E outras mudanças no código para compatibilidade com Linux.

**Update 1.0.6**
<br>Adicionado suporte para imagem GNF para "RE4_PS4NS_MODEL_VIEWER" e "JADERLINK_MODEL_VIEWER".
<br>Feito algumas melhorias.

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
<br>Aviso: a versão 1.0.* é uma versão de pré-lançamento, então os programas podem conter erros que podem fechar o programa sem aviso.

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
<br>[SMD_READER_LIB by JADERLINK](https://github.com/JADERLINK/SMD_READER_LIB).
<br>[TGASharpLib by ALEXGREENALEX](https://github.com/ALEXGREENALEX/TGASharpLib).
<br>[DDSReaderSharp by ALEXGREENALEX](https://github.com/ALEXGREENALEX/DDSReaderSharp).
<br>[Scarlet by xdaniel (Daniel R.) / DigitalZero Domain](https://github.com/xdanieldzd/Scarlet): Adiciona suporte a texturas GNF.
<br>[OpenTK](https://github.com/opentk/opentk/blob/master/LICENSE.md).

**At.te: JADERLINK**
<br>2025-10-30