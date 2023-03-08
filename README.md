


# # Mixamo Ragdoll
![Fox Icon](https://i.ibb.co/br7SPBG/q3866-Ct-SP28.jpg)
______________________
Проект с инструментом для быстрого добавления Unity Ragdoll на риг Ragdoll.
Статус: В разработке.
Используется: [Unity 2021.3.11](https://unity3d.com/unity/whats-new/2021.3.11)

Все необходимые файлы находиться в последнем релизе репозитория.

## Как установить?

Открываем  [Releases](https://github.com/IRecsRu/Mixamo-Ragdoll/releases)  выбираем самый новый, и качаем файл [MixamoRagdoll.unitypackage](https://github.com/IRecs/Fox-Audio/releases/download/TestReleases/FoxAudioManager.unitypackage). Распаковываем в проекте.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/2c9J5yG/Picture.png" alt="Picture" border="0"></a>

## Как пользоваться?

Открываем **Assets/Editor/MixamoRagdoll/Resources**
И ищем **MixamoRigNames.asset** или иной экземпляр **MixamoRigNames**

<a href="https://imgbb.com/"><img src="https://i.ibb.co/2ZDJZpg/Picture2.png" alt="Picture2" border="0"></a>
Если его нет то создаем новый Tools/MixamoRagdoll

<a href="https://ibb.co/c6zkFdv"><img src="https://i.ibb.co/Cbxm7Ft/Picture3.png" alt="Picture3" border="0"></a>

## Настраиваем MixamoRigNames

<a href="https://imgbb.com/"><img src="https://i.ibb.co/JscWHpk/Picture4.png" alt="Picture4" border="0"></a>

Поле **Name** не обязательно заполнять.
Дальше идут ключи.
Их иерархия c заполненным примером.

**Pelvis** - Имя поля в **Unity Ragdoll Creator**

Дальше список **string**, код будет искать **GameObject** с таким именем в целевом объекте, если не найдет, приступает к следующим и так далее.

То есть в этом случае, он будет искать **GameObject** имя которого **mixamorig:Hips**.

Если найдет то передаст этот **GameObject** в поле **Pelvis Ragdoll Creator**
Если нет то выдаст ошибку, так как не один ключ не подошел.
Количество ключей неограниченно.

**Всего 13 контейнеров с ключами, столько же полей в Ragdoll Creator.**

Файл **MixamoRigNames** может находиться в любой папке.

## Использование

Размещаем модель на сцене
(Нельзя использовать файлы из **Project**. Только со сцены).
Смотрим имена костей, и проверяем есть ли они в **MixamoRigNames**
Кости **Mixamo **уже заполнены.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/rQhft8m/Picture5.png" alt="Picture5" border="0"></a>

Далее открываем окно **DSOneGames/Tools/Mixamo Ragdoll**

<a href="https://imgbb.com/"><img src="https://i.ibb.co/gPWzDZV/Picture6.png" alt="Picture6" border="0"></a>

Открывается окно **Create Mixamo Ragdoll**

<a href="https://imgbb.com/"><img src="https://i.ibb.co/WG1G4dh/Picture7.png" alt="Picture7" border="0"></a>

**Names** - заполняется автоматически, но его можно изменить.
**Total Mass** - тоже что и в **Ragdoll Creator**.
**Root** - главный **Transform** целевого объекта.

<a href="https://imgbb.com/"><img src="https://i.ibb.co/Rpr3dGg/Picture8.png" alt="Picture8" border="0"></a>

Подходит как **Родительский объект рига**, так и **Hips**.
Главное чтобы, **Root** был выше или равен в иерархии **Hips**.

Нажимаем **Create**.
